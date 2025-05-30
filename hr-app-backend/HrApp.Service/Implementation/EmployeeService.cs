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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(e => new EmployeeResponseDto
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                HireDate = e.HireDate,
                Position = e.Position,
                DepartmentID = e.DepartmentID,
                DepartmentName = e.Department?.Name,
                ManagerID = e.ManagerID,
                ManagerName = e.Manager != null ? $"{e.Manager.FirstName} {e.Manager.LastName}" : null,
                MentorID = e.MentorID,
                MentorName = e.Mentor != null ? $"{e.Mentor.FirstName} {e.Mentor.LastName}" : null
            });
        }

        public async Task<EmployeeResponseDto> GetByIdAsync(Guid id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return null;

            return new EmployeeResponseDto
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                HireDate = e.HireDate,
                Position = e.Position,
                DepartmentID = e.DepartmentID,
                DepartmentName = e.Department?.Name,
                ManagerID = e.ManagerID,
                ManagerName = e.Manager != null ? $"{e.Manager.FirstName} {e.Manager.LastName}" : null,
                MentorID = e.MentorID,
                MentorName = e.Mentor != null ? $"{e.Mentor.FirstName} {e.Mentor.LastName}" : null
            };
        }

        public async Task<EmployeeResponseDto> AddAsync(EmployeeRequestDto dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                HireDate = dto.HireDate,
                Position = dto.Position,
                DepartmentID = dto.DepartmentID,
                ManagerID = dto.ManagerID,
                MentorID = dto.MentorID
            };

            var created = await _repository.AddAsync(employee);
            return await GetByIdAsync(created.EmployeeID);
        }

        public async Task UpdateAsync(Guid id, EmployeeRequestDto dto)
        {
            var employee = new Employee
            {
                EmployeeID = id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                HireDate = dto.HireDate,
                Position = dto.Position,
                DepartmentID = dto.DepartmentID,
                ManagerID = dto.ManagerID,
                MentorID = dto.MentorID
            };

            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
