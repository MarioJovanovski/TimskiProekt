using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.DTO.Response
{
    public class DepartmentResponseDto
    {
        public Guid DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
