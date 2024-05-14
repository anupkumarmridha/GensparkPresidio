using DoctorAppoinmentAPI.Contexts;
using DoctorAppoinmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppoinmentAPI.Repositories.Classes
{
    public class BaseRepository<K, T> : IRepository<K, T> where T : class
    {
        protected readonly DoctorAppoinmentDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DoctorAppoinmentDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(K id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> Add(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(K id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new InvalidOperationException($"{id} not found.");
            }
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
