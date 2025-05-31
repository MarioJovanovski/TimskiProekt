using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Service.Interface
{
    public interface IEmployeeDossierService
    {
        Task<IEnumerable<EmployeeDossierResponseDto>> GetAllAsync();
        Task<EmployeeDossierResponseDto> GetByIdAsync(Guid id);
        Task<EmployeeDossierResponseDto> GetByEmployeeIdAsync(Guid employeeId);
        Task<EmployeeDossierResponseDto> CreateAsync(EmployeeDossierRequestDto dto);
        Task UpdateAsync(Guid id, EmployeeDossierRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
