using GuideAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        /// <summary>
        ///  Add Entity To DB
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Add(T t);

        /// <summary>
        ///  Update Entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Update(T t);

        /// <summary>
        ///  Get Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        ///  Delete Entity
        /// </summary>
        /// <param name="id"></param>
        void Delete(object id);

        /// <summary>
        ///  Get Queryable
        /// </summary>
        IQueryable<T> Queryable { get; }

        /// <summary>
        ///  FilterData
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IList<T> Filter(Expression<Func<T, bool>> expression);

        /// <summary>
        ///  Get All list
        /// </summary>
        /// <returns></returns>
        IList<T> GetList();
    }
}
