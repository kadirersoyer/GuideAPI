using GuideAPI.Models.Person;
using GuideAPI.Services.PersonServices;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;

namespace PersonWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        /// <summary>
        ///  Return Person List
        /// </summary>
        /// <returns></returns>

        [HttpGet("person-list")]
        public IActionResult GetAllPersons()
        {
            var persons = _personService.GetPersonList();
            return Ok(persons);
        }

        /// <summary>
        ///  Add Person
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        [HttpPost("add-person")]
        public IActionResult AddPerson([FromBody] PersonDto personDto)
        {
            var addedPerson = _personService.AddPerson(personDto);
            return Ok(addedPerson);
        }


        /// <summary>
        ///  Update Person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personDto"></param>
        /// <returns></returns>
        [HttpPut("update-person/{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] PersonDto personDto)
        {
            var updatedPerson = _personService.UpdatePerson(personDto);
            return (Ok(updatedPerson));
        }


        /// <summary>
        ///  Delete Person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-person/{id}")]
        public IActionResult DeletePerson(int id)
        {
            try
            {
                _personService.DeletePerson(id);
                return Ok(new { message = "Person Deleted", status = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message, status = false });
            }
        }

        /// <summary>
        ///  Make Report Request
        /// </summary>
        /// <returns></returns>
        [HttpGet("make-report-request")]
        public IActionResult MakeReportRequest()
        {
            try
            {
                _personService.MakeReportLocationRequest();
                return Ok(new { message = "Report Request Created", status = true });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, status = false });
            }
        }
    }
}
