using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.Models
{
    public class Asset
    {
        public Guid AssetID { get; set; }

        public Guid EmployeeID { get; set; }
       
        public Employee Employee { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public DateTime AssignmentDate { get; set; }
        public bool IsActive { get; set; }
    }
}
