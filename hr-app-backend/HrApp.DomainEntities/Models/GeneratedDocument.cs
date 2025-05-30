using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.Models
{
    public class GeneratedDocument
    {
        public Guid DocumentID { get; set; }

        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public Guid TemplateID { get; set; }
        public DocumentTemplate DocumentTemplate { get; set; }

        public string Content { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string AssetIDs { get; set; }  // JSON array string e.g. "[1,5,8]"
    }
}
