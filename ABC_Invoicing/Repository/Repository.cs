using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using ABC_Invoicing.DAL;

namespace ABC_Invoicing.Repository
{
    public class Repository<T> : IRepository<T> where T:class 
    {

        public DbContext context;
        public DbSet<T> dbset;
        public Repository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public Repository()
        {
            
        }


        public T GetById(Func<T, bool> id) //(int id)
        {
            return dbset.First(id);
            //return dbset.Find(id);
        }

        //public IEnumerable<T> GetAll(Func<T, bool> id = null)
        //{
        //    if (id != null)
        //    {
        //        return dbset.Where(id);
        //    }

        //    return dbset.AsEnumerable();
        //}

        public IQueryable<T> GetAll()
        {
            return dbset;
        }

        public void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}