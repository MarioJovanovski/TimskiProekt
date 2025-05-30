using HrApp.DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(Guid id);
        Task<Department> AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(Guid id);
    }
}
