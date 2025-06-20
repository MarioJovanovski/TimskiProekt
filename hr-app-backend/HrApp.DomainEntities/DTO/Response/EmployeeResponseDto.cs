using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.DTO.Response
{
    public class EmployeeResponseDto
    {
        public Guid EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public Guid? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Guid? ManagerID { get; set; }
        public string ManagerName { get; set; }
        public Guid? MentorID { get; set; }
        public string MentorName { get; set; }
        public string ApplicationUserId { get; set; }

        public List<AssetResponseDto> Assets { get; set; } = [];
        public List<LeaveRequestResponseDto> LeaveRequests { get; set; } = [];
        public List<GeneratedDocumentResponseDto> GeneratedDocuments{ get; set; } = [];


    }
}
