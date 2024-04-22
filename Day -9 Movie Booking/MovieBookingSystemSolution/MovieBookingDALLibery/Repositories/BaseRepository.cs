using MovieBookingDALLibery.Interfaces;

namespace MovieBookingDALLibery.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected Dictionary<int, T> _data;
        public BaseRepository()
        {
            _data = new Dictionary<int, T>();
        }
        private int GetNextId()
        {
            if (_data.Count == 0)
                return 1;

            int maxKey = _data.Keys.Max();
            return maxKey + 1;
        }
        public virtual T Add(T entity)
        {
            int id = GetNextId();

            dynamic dynamicEntity = entity;
            dynamicEntity.SetId(id);
            if (!_data.ContainsKey(id))
            {
                _data.Add(id, entity);
                return _data[id];
            }

            else
                throw new DuplicateWaitObjectException($"Entity with id {id} already exists.");
        }

        public bool Delete(int id)
        {
            if (_data.ContainsKey(id))
            {
                _data.Remove(id);
                return true;
            }
            else
                throw new KeyNotFoundException($"Entity with id {id} not found.");
        }

        public virtual List<T> GetAll()
        {
            return _data.Values.ToList();
        }

        public virtual T GetById(int id)
        {
            if (_data.ContainsKey(id))
                return _data[id];
            else
                throw new InvalidOperationException($"Entity with id {id} not found.");
        }

        public T Update(T entity)
        {
            dynamic dynamicEntity = entity;
            int id = dynamicEntity.Id;

            if (_data.ContainsKey(id))
            {
                _data[id] = entity;
                return _data[id];
            }
            else
                throw new KeyNotFoundException($"Entity with id {id} not found.");
        }
    }
}
