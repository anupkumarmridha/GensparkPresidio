using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Models.DBModels;
using EmployeeRequestTrackerAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories.Classes
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;
        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> DeleteByKey(int key)
        {
            var solutionFeedback = await GetByKey(key);
            if (solutionFeedback != null)
            {
                _context.SolutionFeedbacks.Remove(solutionFeedback);
                await _context.SaveChangesAsync();
            }
            return solutionFeedback;
        }

        public async Task<SolutionFeedback> GetByKey(int key)
        {
            var solutionFeedback = _context.SolutionFeedbacks.SingleOrDefault(e => e.SolutionId == key);
            return solutionFeedback;
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.SolutionFeedbacks.ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var solutionFeedback = await GetByKey(entity.SolutionId);
            if (solutionFeedback != null)
            {
                _context.Entry<SolutionFeedback>(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
