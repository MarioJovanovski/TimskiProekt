using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.DTO.Request
{
    public class EmployeeDossierRequestDto
    {
        [Required]
        public Guid EmployeeID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(100)]
        public string EmergencyContact { get; set; }

        [Required]
        [RegularExpression("Full-Time|Part-Time|Contract", ErrorMessage = "Invalid employment type")]
        public string EmploymentType { get; set; }
    }
}
