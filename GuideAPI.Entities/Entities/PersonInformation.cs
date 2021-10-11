using GuideAPI.Domain.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Entities.Entities
{
    [Table(name: "PersonInformation", Schema = "dbo")]
    public class PersonInformation : BaseEntity
    {
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public InformationType InformationType { get; set; }
        public string Content { get; set; }
    }
}
