namespace EmployeesAPI.Models.DTOs
{
    public class ProjectDto
    {
        public Guid projectID { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string mainTechnologyUsed { get; set; }
        public string projectDeadline { get; set; }
        public string? projectImageUrl { get; set; }
        
    }
}
