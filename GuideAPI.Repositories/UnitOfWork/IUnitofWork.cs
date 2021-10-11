using GuideAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Repositories.UnitOfWork
{
    public interface IUnitofWork: IDisposable
    {
        /// <summary>
        ///  Commit to db
        /// </summary>
        void Save();

        /// <summary>
        ///  Get Repository Of Generic Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> GetRepository<T>() where T : BaseEntity;
    }
}
