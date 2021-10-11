using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Entities.Entities
{
    [Table(name: "Person", Schema = "dbo")]
    public class Person : BaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string Company { get; set; }
        public ICollection<PersonInformation> Informations { get; set; } = new List<PersonInformation>();
    }
}
