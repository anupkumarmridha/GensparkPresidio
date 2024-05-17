using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories.Classes
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context;
        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> DeleteByKey(int key)
        {
            var requestSolution = await GetByKey(key);
            if (requestSolution != null)
            {
                _context.RequestSolutions.Remove(requestSolution);
                await _context.SaveChangesAsync();
            }
            return requestSolution;
        }

        public async Task<RequestSolution> GetByKey(int key)
        {
            var requestSolution = _context.RequestSolutions.SingleOrDefault(e => e.SolutionId == key);
            return requestSolution;
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var requestSolution = await GetByKey(entity.SolutionId);
            if (requestSolution != null)
            {
                _context.Entry<RequestSolution>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return requestSolution;
        }
    }
}
