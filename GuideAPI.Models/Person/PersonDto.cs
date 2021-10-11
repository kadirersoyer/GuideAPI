using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Models.Person
{
    public class PersonDto: BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public ICollection<PersonInformationDto> Informations { get; set; } = new List<PersonInformationDto>();
    }
}
