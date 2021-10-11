using GuideAPI.Domain.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Models.Person
{
    public class PersonInformationDto: BaseDto
    {
        public int PersonId { get; set; }
        public PersonDto Person { get; set; }
        public InformationType InformationType { get; set; }
        public string Content { get; set; }
    }
}
