using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PieShopHRM.Shared;

namespace PieShopHRM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DummyEmployeeController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        
        public IActionResult GetAllEmployees()
        {
            return Ok(new[]
            {
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Shishir" ,
                    LastName = "Mishra",
                    Email = "shishir28@gmail.com"
                }
            });
        }
    }
}