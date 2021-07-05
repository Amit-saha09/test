using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected PharmaAssistDB contex = new PharmaAssistDB();
        public void Delete(T entity)
        {
            this.contex.Set<T>().Remove(entity);
            this.contex.SaveChanges();
        }

        public void Delete(int Id)
        {
            this.contex.Set<T>().Remove(Get(Id));
            this.contex.SaveChanges();
        }

        public T Get(int Id)
        {
            return this.contex.Set<T>().Find(Id);
        }

        public List<T> GetAll()
        {
            return this.contex.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            this.contex.Set<T>().Add(entity);
            this.contex.SaveChanges();
        }

        public void Update(T entity)
        {
            this.contex.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.contex.SaveChanges();
        }
    }
}