using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammers.Inventory.DAL.Business
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly InventoryContext DbContext;
        private readonly DbSet<T> dbSet;
        public Repository()
        {
            if (DbContext == null)
            {
                DbContext = new InventoryContext();
                dbSet = DbContext.Set<T>();
            }
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return dbSet.Find(id);
        }

        public void Update(T item)
        {
            DbContext.Entry<T>(item).State = EntityState.Modified;
        }
    }
}
