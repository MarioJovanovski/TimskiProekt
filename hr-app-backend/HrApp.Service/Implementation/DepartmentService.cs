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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();
            return departments.Select(d => new DepartmentResponseDto
            {
                DepartmentID = d.DepartmentID,
                Name = d.Name,
                Description = d.Description
            });
        }

        public async Task<DepartmentResponseDto> GetByIdAsync(Guid id)
        {
            var d = await _repository.GetByIdAsync(id);
            if (d == null) return null;
            return new DepartmentResponseDto
            {
                DepartmentID = d.DepartmentID,
                Name = d.Name,
                Description = d.Description
            };
        }

        public async Task<DepartmentResponseDto> AddAsync(DepartmentRequestDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Description = dto.Description
            };
            var created = await _repository.AddAsync(department);
            return new DepartmentResponseDto
            {
                DepartmentID = created.DepartmentID,
                Name = created.Name,
                Description = created.Description
            };
        }

        public async Task UpdateAsync(Guid id, DepartmentRequestDto dto)
        {
            var department = new Department
            {
                DepartmentID = id,
                Name = dto.Name,
                Description = dto.Description
            };
            await _repository.UpdateAsync(department);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
