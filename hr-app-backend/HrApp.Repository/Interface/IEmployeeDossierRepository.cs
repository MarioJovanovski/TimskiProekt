using HrApp.DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Repository.Interface
{
    public interface IEmployeeDossierRepository
    {
        Task<IEnumerable<EmployeeDossier>> GetAllAsync();
        Task<EmployeeDossier> GetByIdAsync(Guid id);
        Task<EmployeeDossier> GetByEmployeeIdAsync(Guid employeeId);
        Task<EmployeeDossier> AddAsync(EmployeeDossier dossier);
        Task UpdateAsync(EmployeeDossier dossier);
        Task DeleteAsync(Guid id);
    }
}
