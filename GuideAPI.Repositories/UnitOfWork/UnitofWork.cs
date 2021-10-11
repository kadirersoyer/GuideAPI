using GuideAPI.Context;
using GuideAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Repositories.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly GuideAPIContext dbContext;

        private static Dictionary<string, object> repositories = new Dictionary<string, object>();
        private bool disposedValue;

        public UnitofWork(GuideAPIContext dbContext)
        {
            this.dbContext = dbContext;
        }
      

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;

            if (!repositories.TryGetValue(key,out object repo))
            {
                // Return New Repository
                return new Repository<T>(dbContext);
            }
            return repo as IRepository<T>;
            
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitofWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
