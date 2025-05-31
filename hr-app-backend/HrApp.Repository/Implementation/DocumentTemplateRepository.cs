using HrApp.DomainEntities.Models;
using HrApp.Repository.Interface;
using HrAppWebApplication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Repository.Implementation
{
    public class DocumentTemplateRepository : IDocumentTemplateRepository
    {
        private readonly HrAppDbContext _context;

        public DocumentTemplateRepository(HrAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentTemplate>> GetAllAsync()
        {
            return await _context.DocumentTemplates
                .Include(t => t.GeneratedDocuments)
                .OrderBy(t => t.TemplateName)
                .ToListAsync();
        }

        public async Task<DocumentTemplate> GetByIdAsync(Guid id)
        {
            return await _context.DocumentTemplates
                .Include(t => t.GeneratedDocuments)
                .FirstOrDefaultAsync(t => t.TemplateID == id);
        }

        public async Task<DocumentTemplate> GetByNameAsync(string templateName)
        {
            return await _context.DocumentTemplates
                .FirstOrDefaultAsync(t => t.TemplateName == templateName);
        }

        public async Task<IEnumerable<DocumentTemplate>> GetByTypeAsync(string templateType)
        {
            return await _context.DocumentTemplates
                .Where(t => t.TemplateType == templateType)
                .ToListAsync();
        }

        public async Task<DocumentTemplate> AddAsync(DocumentTemplate template)
        {
            template.TemplateID = Guid.NewGuid();
            _context.DocumentTemplates.Add(template);
            await _context.SaveChangesAsync();
            return template;
        }

        public async Task UpdateAsync(DocumentTemplate template)
        {
            _context.Entry(template).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var template = await _context.DocumentTemplates.FindAsync(id);
            if (template != null)
            {
                _context.DocumentTemplates.Remove(template);
                await _context.SaveChangesAsync();
            }
        }
    }
}
