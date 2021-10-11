using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Mapper
{
    public interface IAutoMapper
    {
        /// <summary>
        ///  Map Source To Target
        /// </summary>
        /// <typeparam name="ISource"></typeparam>
        /// <typeparam name="IReturn"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        IReturn Map<ISource, IReturn>(ISource source);


        /// <summary>
        ///  Map Collection List
        /// </summary>
        /// <typeparam name="ISouce"></typeparam>
        /// <typeparam name="IReturn"></typeparam>
        /// <param name="souces"></param>
        /// <returns></returns>
        List<IReturn> MapCollection<ISouce, IReturn>(ICollection<ISouce> souces);
    }
}
