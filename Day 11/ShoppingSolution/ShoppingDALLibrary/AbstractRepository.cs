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
        public virtual T Add(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
            items.Add(item);
            return item;
        }
        public virtual ICollection<T> GetAll()
        {
            //items.Sort();
            return items.ToList<T>();
        }

        public abstract T Delete(K key);
        public abstract T GetByKey(K key);

        public abstract T Update(T item);

    }
}
