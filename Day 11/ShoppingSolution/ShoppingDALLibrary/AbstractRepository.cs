using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = new List<T>();
        public virtual async Task<T> Add(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
            items.Add(item);
            return await Task.FromResult(item);
        }
        public virtual async Task<List<T>> GetAll()
        {
            //items.Sort();
            return await Task.FromResult(items.ToList());
        }

        public abstract Task<T> Delete(K key);
        public abstract Task<T> GetByKey(K key);

        public abstract Task<T> Update(T item);

    }
}
