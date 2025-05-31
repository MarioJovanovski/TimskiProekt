using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.DTO.Response
{
    public class EmployeeDossierResponseDto
    {
        public Guid DossierID { get; set; }
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set; } // Will be populated from Employee entity
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public string EmploymentType { get; set; }
    }
}
