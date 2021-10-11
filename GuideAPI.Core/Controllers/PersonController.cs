using GuideAPI.Services.PersonServices;
using Microsoft.AspNetCore.Mvc;

namespace GuideAPI.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public PersonController(IPersonService personService)
        {

        }
    }
}
