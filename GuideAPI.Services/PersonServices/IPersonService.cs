using GuideAPI.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Services.PersonServices
{
    public interface IPersonService
    {
        /// <summary>
        ///  Add Person
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        PersonDto AddPerson(PersonDto personDto);

        /// <summary>
        ///  Update Person
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        PersonDto UpdatePerson(PersonDto personDto);

        /// <summary>
        ///  Delete Person
        /// </summary>
        /// <param name="personDto"></param>
        void DeletePerson(int personId);

        /// <summary>
        ///  Get All Persons
        /// </summary>
        /// <returns></returns>
        List<PersonDto> GetPersonList();
    }
}
