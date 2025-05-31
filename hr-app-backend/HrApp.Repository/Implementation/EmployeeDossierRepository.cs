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
    public class EmployeeDossierRepository : IEmployeeDossierRepository
    {
        private readonly HrAppDbContext _context;

        public EmployeeDossierRepository(HrAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDossier>> GetAllAsync()
        {
            return await _context.EmployeeDossiers
                .Include(d => d.Employee)
                .ToListAsync();
        }

        public async Task<EmployeeDossier> GetByIdAsync(Guid id)
        {
            return await _context.EmployeeDossiers
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(d => d.DossierID == id);
        }

        public async Task<EmployeeDossier> GetByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.EmployeeDossiers
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(d => d.EmployeeID == employeeId);
        }

        public async Task<EmployeeDossier> AddAsync(EmployeeDossier dossier)
        {
            _context.EmployeeDossiers.Add(dossier);
            await _context.SaveChangesAsync();
            return dossier;
        }

        public async Task UpdateAsync(EmployeeDossier dossier)
        {
            _context.Entry(dossier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dossier = await _context.EmployeeDossiers.FindAsync(id);
            if (dossier != null)
            {
                _context.EmployeeDossiers.Remove(dossier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
