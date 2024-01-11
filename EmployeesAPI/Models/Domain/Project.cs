namespace EmployeesAPI.Models.Domain
{
    public class Project
    {
        public Guid projectID { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public string mainTechnologyUsed { get; set; }
        public DateTime projectDeadline{ get; set; }
        public string? projectImageUrl { get; set; }
    }
}
