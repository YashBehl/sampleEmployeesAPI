using EmployeesAPI.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        //sample code for getting list of projects
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projects = new List<Project>
            {
                new Project
                {
                    projectID = Guid.NewGuid(),
                    projectName = "Face Recognition",
                    projectDescription = "App recognising faces",
                    projectDeadline = "02/15/2024",
                    mainTechnologyUsed = "Python"
                },
                new Project
                {
                    projectID = Guid.NewGuid(),
                    projectName = "E commerce website",
                    projectDescription = "Shopping Site",
                    projectDeadline = "03/15/2024",
                    mainTechnologyUsed = "Python"
                }
            };
            return Ok(projects);
        }
    }
}
