using GuideAPI.Context;
using GuideAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly GuideAPIContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(GuideAPIContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> Queryable => dbSet;

        public T Add(T t)
        {
            dbContext.Add(t);
            return t;
        }

        public void Delete(object id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
                dbContext.Remove(entity);
        }

        public IList<T> Filter(Expression<Func<T, bool>> expression)
        {
            var filteredData = dbSet.Where(expression).ToList();
            return filteredData;
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public IList<T> GetList()
        {
            var entities = dbSet.ToList();
            return entities;
        }

        public T Update(T t)
        {
            dbSet.Attach(t);
            dbContext.Entry(t).State = EntityState.Modified;
            return t;
        }
    }
}
