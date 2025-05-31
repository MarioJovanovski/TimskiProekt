using HrApp.DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Repository.Interface
{
    public interface IDocumentTemplateRepository
    {
        Task<IEnumerable<DocumentTemplate>> GetAllAsync();
        Task<DocumentTemplate> GetByIdAsync(Guid id);
        Task<DocumentTemplate> GetByNameAsync(string templateName);
        Task<IEnumerable<DocumentTemplate>> GetByTypeAsync(string templateType);
        Task<DocumentTemplate> AddAsync(DocumentTemplate template);
        Task UpdateAsync(DocumentTemplate template);
        Task DeleteAsync(Guid id);
    }
}
