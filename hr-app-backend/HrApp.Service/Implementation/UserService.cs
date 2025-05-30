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
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                EmployeeID = u.EmployeeID,
                EmployeeName = u.Employee != null ? $"{u.Employee.FirstName} {u.Employee.LastName}" : null
            });
        }

        public async Task<UserResponseDto> GetByIdAsync(Guid id)
        {
            var u = await _repository.GetByIdAsync(id);
            if (u == null) return null;

            return new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                EmployeeID = u.EmployeeID,
                EmployeeName = u.Employee != null ? $"{u.Employee.FirstName} {u.Employee.LastName}" : null
            };
        }

        public async Task<UserResponseDto> GetByEmailAsync(string email)
        {
            var u = await _repository.GetByEmailAsync(email);
            if (u == null) return null;

            return new UserResponseDto
            {
                Id = u.Id,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                EmployeeID = u.EmployeeID,
                EmployeeName = u.Employee != null ? $"{u.Employee.FirstName} {u.Employee.LastName}" : null
            };
        }

        public async Task<UserResponseDto> AddAsync(UserRequestDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                EmployeeID = dto.EmployeeID
            };

            var created = await _repository.AddAsync(user);
            return await GetByIdAsync(created.Id);
        }

        public async Task UpdateAsync(Guid id, UserRequestDto dto)
        {
            var user = new User
            {
                Id = id,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                EmployeeID = dto.EmployeeID
            };

            await _repository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
