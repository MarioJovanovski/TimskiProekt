using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Service.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResponseDto>> GetAllAsync();
        Task<DepartmentResponseDto> GetByIdAsync(Guid id);
        Task<DepartmentResponseDto> AddAsync(DepartmentRequestDto dto);
        Task UpdateAsync(Guid id, DepartmentRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
