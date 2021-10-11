using AutoMapper;
using GuideAPI.Entities.Entities;
using GuideAPI.Models.Person;
using GuideAPI.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Person, PersonDto>().ReverseMap().MaxDepth(5);
            CreateMap<PersonInformation, PersonInformationDto>().ReverseMap().MaxDepth(5);
            CreateMap<Report, ReportDto>().ReverseMap().MaxDepth(5);
        }
    }
}
