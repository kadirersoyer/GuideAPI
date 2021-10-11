using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Mapper
{
    public class AutoMapper : IAutoMapper
    {
        private IMapper mapper = null;
        public AutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProfileMapper>();
            });

            mapper = config.CreateMapper();
        }
        public IReturn Map<ISource, IReturn>(ISource source)
        {
            var entity = mapper.Map<IReturn>(source);
            return entity;
        }

        public List<IReturn> MapCollection<ISouce, IReturn>(ICollection<ISouce> souces)
        {
            var entities = mapper.Map<List<IReturn>>(souces);
            return entities;
        }
    }
}
