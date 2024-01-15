namespace EmployeesAPI.Models.DTOs
{
    public class AddProjectRequestDto
    {
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string mainTechnologyUsed { get; set; }
        public string projectDeadline { get; set; }
        public string? projectImageUrl { get; set; }

    }
}
