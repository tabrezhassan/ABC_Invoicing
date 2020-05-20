using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ABC_Invoicing.Repository
{
    public interface IRepository<T>
    {
        T GetById(Func<T,bool> id);
        //IEnumerable<T> GetAll(Func<T, bool> id = null);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
