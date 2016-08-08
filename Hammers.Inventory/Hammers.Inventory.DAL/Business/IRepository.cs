using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammers.Inventory.DAL.Business
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        List<T> GetAll();
        T GetById(int? id);
    }
}
