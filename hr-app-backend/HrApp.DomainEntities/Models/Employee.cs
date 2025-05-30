using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.Models
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }

        public Guid? DepartmentID { get; set; }
        public Department Department { get; set; }

        public Guid? ManagerID { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Subordinates { get; set; }

        public Guid? MentorID { get; set; }
        public Employee Mentor { get; set; }
        public ICollection<Employee> Mentees { get; set; }

        public EmployeeDossier EmployeeDossier { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        public ICollection<Asset> Assets { get; set; }
        public ICollection<GeneratedDocument> GeneratedDocuments { get; set; }
    }
}
