using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    // https://localhost:portnumer/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: https://localhost:portnumer/api/employees

        [HttpGet]
        public IActionResult GetAllEmployees() 
        {
            string[] employeeNames = new string[] { "Yash", "Arun", "Kunal", "Arjun" };
            
            return Ok(employeeNames);
        }

    }
}
