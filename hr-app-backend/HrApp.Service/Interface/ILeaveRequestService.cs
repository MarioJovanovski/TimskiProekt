using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Service.Interface
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequestResponseDto>> GetAllAsync();
        Task<LeaveRequestResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<LeaveRequestResponseDto>> GetByEmployeeIdAsync(Guid employeeId);
        Task<IEnumerable<LeaveRequestResponseDto>> GetPendingRequestsAsync();
        Task<LeaveRequestResponseDto> CreateAsync(LeaveRequestRequestDto dto);
        Task ApproveRequestAsync(Guid id);
        Task RejectRequestAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
