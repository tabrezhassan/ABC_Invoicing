using ABC_Invoicing.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Invoicing.UoW
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;

        void SaveChanges();
    }
}
