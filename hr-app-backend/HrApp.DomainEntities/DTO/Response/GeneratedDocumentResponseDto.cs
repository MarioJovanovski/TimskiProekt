using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.DomainEntities.DTO.Response
{
    public class GeneratedDocumentResponseDto
    {
        public Guid DocumentID { get; set; }
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Guid TemplateID { get; set; }
        public string TemplateName { get; set; }
        public string ContentPreview { get; set; } // First 100 chars
        public DateTime GeneratedDate { get; set; }
        public List<AssetResponseDto> Assets { get; set; }
        public string DocumentType { get; set; }
        public string Content { get; set; }

       
        
        
    }
}
