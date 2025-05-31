using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.DTO.Request
{
    public class LeaveRequestRequestDto
    {
        [Required]
        public Guid EmployeeID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } // No more attribute here

        [Required]
        [RegularExpression("Vacation|Sick|Parental|Unpaid", ErrorMessage = "Invalid leave type")]
        public string LeaveType { get; set; }


    }
}
