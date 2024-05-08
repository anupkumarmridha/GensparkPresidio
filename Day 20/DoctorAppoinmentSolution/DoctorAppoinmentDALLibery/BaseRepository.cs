using DoctorAppoinmentModelLibery.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppoinmentDALLibery
{
    public abstract class BaseRepository<K, T> : IRepository<K, T> where T : class
    {
        protected readonly DBDoctorAppoinmentContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(DBDoctorAppoinmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = _context.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return _entities.ToList();
        }

        public virtual T Get(K key)
        {
            return _entities.Find(key);
        }

        public virtual T Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _entities.Add(item);
            _context.SaveChanges();
            return item;
        }

        public virtual T Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _entities.Update(item);
            _context.SaveChanges();
            return item;
        }

        public virtual T Delete(K key)
        {
            var entity = _entities.Find(key);
            if (entity != null)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
            return entity;
        }

        protected abstract K GetKey(T item);
    }
}
