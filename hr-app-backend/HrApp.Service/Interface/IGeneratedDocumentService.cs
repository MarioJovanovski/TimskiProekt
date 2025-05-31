using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Service.Interface
{
    public interface IGeneratedDocumentService
    {
        Task<IEnumerable<GeneratedDocumentResponseDto>> GetAllAsync();
        Task<GeneratedDocumentResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<GeneratedDocumentResponseDto>> GetByEmployeeIdAsync(Guid employeeId);
        Task<IEnumerable<GeneratedDocumentResponseDto>> GetByTemplateIdAsync(Guid templateId);
        Task<GeneratedDocumentResponseDto> GenerateDocumentAsync(GeneratedDocumentRequestDto dto);
        Task DeleteAsync(Guid id);
        Task<string> GetDocumentContentAsync(Guid id);
    }
}
