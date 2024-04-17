using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentDALLibery
{
    public class Repository<K, T> : IRepository<K, T> where T : class, IEntity<K>
    {
        private readonly Dictionary<K, T> _entities;

        public Repository()
        {
            _entities = new Dictionary<K, T>();
        }

        public T Add(T item)
        {
            if (_entities.ContainsValue(item))
            {
                return null;
            }
            var id = GenerateId();
            item.Id = id;
            _entities.Add(id, item);
            return item;
        }

        public T Delete(K key)
        {
            if (_entities.ContainsKey(key))
            {
                var entity = _entities[key];
                _entities.Remove(key);
                return entity;
            }
            return null;
        }

        public T Get(K key)
        {
            return _entities.ContainsKey(key) ? _entities[key] : null;
        }

        public List<T> GetAll()
        {
            return _entities.Values.ToList();
        }

        public T Update(T item)
        {
            if (_entities.ContainsKey(item.Id))
            {
                _entities[item.Id] = item;
                return item;
            }
            return null;
        }

        private K GenerateId()
        {
            if (_entities.Count == 0)
                return default(K); 
            dynamic id = _entities.Keys.Max();
            return id + 1;
        }
    }
}
