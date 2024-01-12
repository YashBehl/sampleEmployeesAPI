namespace EmployeesAPI.Models.Domain
{
    public class Employee
    {
        public Guid employeeID { get; set; }
        public string employeeName { get; set; }
        public string employeeEmail { get; set; }
        public string employeePhoneNumber { get; set; }
        public int employeeAge { get; set; }


        public Guid DepartmentdepartmentID { get; set; }
        public Guid ProjectprojectID { get; set; }


        // Navigation properties
        public Department Department { get; set; }
        public Project Project { get; set; }

        
    }
}
