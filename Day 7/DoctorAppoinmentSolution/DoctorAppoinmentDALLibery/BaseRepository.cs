using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    public abstract class BaseRepository<K, T> : IRepository<K, T> where T : class
    {
        protected readonly Dictionary<K, T> _data;

        public BaseRepository()
        {
            _data = new Dictionary<K, T>();
        }

        public abstract K GenerateId();

        public virtual List<T> GetAll()
        {
            return new List<T>(_data.Values);
        }

        public virtual T Get(K key)
        {
            return _data.ContainsKey(key) ? _data[key] : null;
        }

        public virtual T Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var id = GenerateId();
            // You might want to add additional validation here if needed

            _data.Add(id, item);
            return item;
        }

        public virtual T Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            // You might want to add additional validation here if needed

            _data[GetKey(item)] = item;
            return item;
        }

        public virtual T Delete(K key)
        {
            if (_data.ContainsKey(key))
            {
                var entity = _data[key];
                _data.Remove(key);
                return entity;
            }
            return null;
        }

        protected abstract K GetKey(T item);
    }
}
