using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Service.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllAsync();
        Task<EmployeeResponseDto> GetByIdAsync(Guid id);
        Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto dto);
        Task UpdateAsync(Guid id, EmployeeRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
