using RequestTrackerModelLibery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>

    {
        protected readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> DeleteByKey(int key)
        {
            var request = await GetByKey(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<Request> GetByKey(int key)
        {
            var request = await _context.Requests
            .Include(r => r.RequestSolutions)
            .FirstOrDefaultAsync(r => r.RequestNumber == key);
            return request;
        }

        public async Task<IList<Request>> GetAll()
        {
            var requests = await _context.Requests
                .Include(r => r.RaisedByEmployee)  // Eager loading of RaisedByEmployee
                .Include(r => r.RequestSolutions)  // Eager loading of RequestSolutions
                    .ThenInclude(rs => rs.SolvedByEmployee)  // Eager loading of SolvedByEmployee for each RequestSolution
                .ToListAsync();
            return requests;
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await GetByKey(entity.RequestNumber);
            if (request != null)
            {
                _context.Entry<Request>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<IList<Request>> GetAllRequestByEmployeeId(int employeeId)
        {
            var requests = await _context.Requests.Where(e => e.RequestRaisedBy == employeeId).ToListAsync();
            return requests;
        }


    }
}
