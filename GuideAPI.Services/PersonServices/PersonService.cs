using GuideAPI.Mapper;
using GuideAPI.Models.Person;
using GuideAPI.Models.Report;
using GuideAPI.Repositories.UnitOfWork;
using GuideAPI.Services.AsyncDataServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuideAPI.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly IRabbitmqService rabbitmqService;
        private readonly IAutoMapper autoMapper;
        private readonly IUnitofWork unitofWork;
        private readonly Repositories.IRepository<GuideAPI.Entities.Entities.Person> personRepository;

        public PersonService(IUnitofWork unitofWork, IAutoMapper autoMapper, IRabbitmqService rabbitmqService)
        {
            this.rabbitmqService = rabbitmqService;
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

        public void MakeReportLocationRequest()
        {
            var requestMessage = new ReportDto
            {
                ReportStatus = Domain.Report.ReportStatus.Preparing,
                RequestDate = DateTime.Now
            };

            var factory = rabbitmqService.CreateConnectionFactory();
            // Create Connection 
            using (var connection = factory.CreateConnection())
            {
                using (var channel = rabbitmqService.GetChannel(factory))
                {
                    rabbitmqService.DeclareQueue(channel, JsonConvert.SerializeObject(requestMessage), "createreport", "createreport");
                }
            }
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
