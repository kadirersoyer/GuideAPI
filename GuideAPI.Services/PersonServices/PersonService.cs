using GuideAPI.Mapper;
using GuideAPI.Models.Person;
using GuideAPI.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuideAPI.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly IAutoMapper autoMapper;
        private readonly IUnitofWork unitofWork;
        private readonly Repositories.IRepository<GuideAPI.Entities.Entities.Person> personRepository;

        public PersonService(IUnitofWork unitofWork, IAutoMapper autoMapper)
        {
            this.autoMapper = autoMapper;
            this.unitofWork = unitofWork;
            this.personRepository = unitofWork.GetRepository<GuideAPI.Entities.Entities.Person>();
        }
        public PersonDto AddPerson(PersonDto personDto)
        {
            var entity = autoMapper.Map<PersonDto, GuideAPI.Entities.Entities.Person>(personDto);
            personRepository.Add(entity);
            unitofWork.Save();
            return autoMapper.Map<GuideAPI.Entities.Entities.Person, PersonDto>(entity);
        }

        public void DeletePerson(int personId)
        {
            personRepository.Delete(personId);
            unitofWork.Save();
        }

        public List<PersonDto> GetPersonList()
        {
            var entities = personRepository.GetList();
            var mappedEntities = autoMapper.MapCollection<GuideAPI.Entities.Entities.Person, PersonDto>(
                entities);

            return mappedEntities;
        }

        public PersonDto UpdatePerson(PersonDto personDto)
        {
            var entity = autoMapper.Map<PersonDto, GuideAPI.Entities.Entities.Person>(personDto);
            personRepository.Update(entity);
            unitofWork.Save();
            return autoMapper.Map<GuideAPI.Entities.Entities.Person, PersonDto>(entity);
        }
    }
}
