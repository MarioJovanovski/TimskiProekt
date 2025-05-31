using HrApp.DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Repository.Interface
{
    public interface IGeneratedDocumentRepository
    {
        Task<IEnumerable<GeneratedDocument>> GetAllAsync();
        Task<GeneratedDocument> GetByIdAsync(Guid id);
        Task<IEnumerable<GeneratedDocument>> GetByEmployeeIdAsync(Guid employeeId);
        Task<IEnumerable<GeneratedDocument>> GetByTemplateIdAsync(Guid templateId);
        Task<GeneratedDocument> AddAsync(GeneratedDocument document);
        Task DeleteAsync(Guid id);
    }
}
