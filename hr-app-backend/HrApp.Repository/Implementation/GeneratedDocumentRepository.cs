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
    public class GeneratedDocumentRepository : IGeneratedDocumentRepository
    {
        private readonly HrAppDbContext _context;

        public GeneratedDocumentRepository(HrAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GeneratedDocument>> GetAllAsync()
        {
            return await _context.GeneratedDocuments
                .Include(d => d.Employee)
                .Include(d => d.DocumentTemplate)
                .OrderByDescending(d => d.GeneratedDate)
                .ToListAsync();
        }

        public async Task<GeneratedDocument> GetByIdAsync(Guid id)
        {
            return await _context.GeneratedDocuments
                .Include(d => d.Employee)
                .Include(d => d.DocumentTemplate)
                .FirstOrDefaultAsync(d => d.DocumentID == id);
        }

        public async Task<IEnumerable<GeneratedDocument>> GetByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.GeneratedDocuments
                .Where(d => d.EmployeeID == employeeId)
                .Include(d => d.DocumentTemplate)
                .OrderByDescending(d => d.GeneratedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<GeneratedDocument>> GetByTemplateIdAsync(Guid templateId)
        {
            return await _context.GeneratedDocuments
                .Where(d => d.TemplateID == templateId)
                .Include(d => d.Employee)
                .OrderByDescending(d => d.GeneratedDate)
                .ToListAsync();
        }

        public async Task<GeneratedDocument> AddAsync(GeneratedDocument document)
        {
            document.GeneratedDate = DateTime.UtcNow;
            document.DocumentID = Guid.NewGuid();

            _context.GeneratedDocuments.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task DeleteAsync(Guid id)
        {
            var document = await _context.GeneratedDocuments.FindAsync(id);
            if (document != null)
            {
                _context.GeneratedDocuments.Remove(document);
                await _context.SaveChangesAsync();
            }
        }
    }
}
