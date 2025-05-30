using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.DTO.Request
{
    public class UserRequestDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Guid EmployeeID { get; set; }
    }
}
