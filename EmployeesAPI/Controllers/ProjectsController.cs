using EmployeesAPI.Data;
using EmployeesAPI.Models.Domain;
using EmployeesAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly EmployeesDbContext dbContext;

        public ProjectsController(EmployeesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //code for getting list of projects from database
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            // getting data from database
            var projectsDomain = dbContext.Projects.ToList();

            // mapping domain models to dtos
            var projectsDto = new List<ProjectDto>();
            foreach (var project in projectsDomain) 
            {
                projectsDto.Add(new ProjectDto()
                {
                    projectID = project.projectID,
                    projectName = project.projectName,
                    projectDescription = project.projectDescription,
                    mainTechnologyUsed = project.mainTechnologyUsed,
                    projectDeadline = project.projectDeadline,
                    projectImageUrl = project.projectImageUrl
                });
            }

            // returning dtos
            return Ok(projectsDto);
        }


        //getting single project deatils by its id

        [HttpGet]
        [Route("(id:Guid)")]
        public IActionResult GetProjectByID(Guid id)
        {
            var projectDomain = dbContext.Projects.FirstOrDefault(x => x.projectID == id);

            if (projectDomain == null)
            {
                return NotFound();
            }

            var projectDto = new ProjectDto
            {
                projectID = projectDomain.projectID,
                projectName = projectDomain.projectName,
                projectDescription = projectDomain.projectDescription,
                mainTechnologyUsed = projectDomain.mainTechnologyUsed,
                projectDeadline = projectDomain.projectDeadline,
                projectImageUrl = projectDomain.projectImageUrl
            };

            return Ok(projectDto); 
        }



        [HttpPost]
        public IActionResult Create([FromBody] AddProjectRequestDto addProjectRequestDto)
        {
            // mapping the dto to domain model
            var projectDomainModel = new Project
            {
                projectName = addProjectRequestDto.projectName,
                projectDescription = addProjectRequestDto.projectDescription,
                projectDeadline = addProjectRequestDto.projectDeadline,
                mainTechnologyUsed = addProjectRequestDto.mainTechnologyUsed,
                projectImageUrl = addProjectRequestDto.projectImageUrl
            };


            // using domain model to create a Project in the database
            dbContext.Projects.Add(projectDomainModel);
            dbContext.SaveChanges();

            // mapping domain model back to dto
            var projectDto = new ProjectDto
            {
                projectID = projectDomainModel.projectID,
                projectName = projectDomainModel.projectName,
                projectDescription = projectDomainModel.projectDescription,
                mainTechnologyUsed = projectDomainModel.mainTechnologyUsed,
                projectDeadline = projectDomainModel.projectDeadline,
                projectImageUrl = projectDomainModel.projectImageUrl
            };

            return CreatedAtAction(nameof(GetProjectByID), new { id = projectDto.projectID }, projectDto);
        }
    }
}
