using ABC_Invoicing.DAL;
using ABC_Invoicing.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ABC_Invoicing.UoW
{
    public class UnitofWork : IUnitOfWork
    {
        private readonly DbContext context = null;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitofWork(DbContext context)
        {
            this.context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repo = new Repository<T>(context);
            repositories.Add(typeof(T), repo);

            return repo;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}