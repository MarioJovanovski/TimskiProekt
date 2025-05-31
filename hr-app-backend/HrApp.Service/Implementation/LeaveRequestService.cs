using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using HrApp.DomainEntities.Models;
using HrApp.Repository.Interface;
using HrApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Service.Implementation
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;

        public LeaveRequestService(
            ILeaveRequestRepository repository,
            IEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<LeaveRequestResponseDto>> GetAllAsync()
        {
            var requests = await _repository.GetAllAsync();
            return requests.Select(MapToDto);
        }

        public async Task<LeaveRequestResponseDto> GetByIdAsync(Guid id)
        {
            var request = await _repository.GetByIdAsync(id);
            return request == null ? null : MapToDto(request);
        }

        public async Task<IEnumerable<LeaveRequestResponseDto>> GetByEmployeeIdAsync(Guid employeeId)
        {
            var requests = await _repository.GetByEmployeeIdAsync(employeeId);
            return requests.Select(MapToDto);
        }

        public async Task<IEnumerable<LeaveRequestResponseDto>> GetPendingRequestsAsync()
        {
            var requests = await _repository.GetPendingRequestsAsync();
            return requests.Select(MapToDto);
        }

        public async Task<LeaveRequestResponseDto> CreateAsync(LeaveRequestRequestDto dto)
        {
            // Validate date range first
            if (dto.EndDate <= dto.StartDate)
            {
                throw new ArgumentException("End date must be after start date");
            }

            // Validate employee exists
            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            var leaveRequest = new LeaveRequest
            {
                EmployeeID = dto.EmployeeID,
                StartDate = dto.StartDate.Date, // Ensure time portion is removed
                EndDate = dto.EndDate.Date,
                LeaveType = dto.LeaveType,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            var created = await _repository.AddAsync(leaveRequest);
            return await GetByIdAsync(created.RequestID);
        }

        public async Task ApproveRequestAsync(Guid id)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) throw new ArgumentException("Leave request not found");

            request.Status = "Approved";
            await _repository.UpdateAsync(request);
        }

        public async Task RejectRequestAsync(Guid id)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) throw new ArgumentException("Leave request not found");

            request.Status = "Rejected";
            await _repository.UpdateAsync(request);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        private LeaveRequestResponseDto MapToDto(LeaveRequest request)
        {
            return new LeaveRequestResponseDto
            {
                RequestID = request.RequestID,
                EmployeeID = request.EmployeeID,
                EmployeeName = $"{request.Employee?.FirstName} {request.Employee?.LastName}",
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                LeaveType = request.LeaveType,
                Status = request.Status,
                CreatedAt = request.CreatedAt
            };
        }
    }
}
