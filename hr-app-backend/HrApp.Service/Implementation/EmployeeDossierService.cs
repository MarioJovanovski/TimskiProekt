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
    public class EmployeeDossierService : IEmployeeDossierService
    {
        private readonly IEmployeeDossierRepository _repository;

        public EmployeeDossierService(IEmployeeDossierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDossierResponseDto>> GetAllAsync()
        {
            var dossiers = await _repository.GetAllAsync();
            return dossiers.Select(d => MapToDto(d));
        }

        public async Task<EmployeeDossierResponseDto> GetByIdAsync(Guid id)
        {
            var dossier = await _repository.GetByIdAsync(id);
            return dossier == null ? null : MapToDto(dossier);
        }

        public async Task<EmployeeDossierResponseDto> GetByEmployeeIdAsync(Guid employeeId)
        {
            var dossier = await _repository.GetByEmployeeIdAsync(employeeId);
            return dossier == null ? null : MapToDto(dossier);
        }

        public async Task<EmployeeDossierResponseDto> CreateAsync(EmployeeDossierRequestDto dto)
        {
            // Check if employee already has a dossier
            var existingDossier = await _repository.GetByEmployeeIdAsync(dto.EmployeeID);
            if (existingDossier != null)
            {
                throw new InvalidOperationException($"Employee with ID {dto.EmployeeID} already has a dossier");
            }

            var dossier = new EmployeeDossier
            {
                EmployeeID = dto.EmployeeID,
                BirthDate = dto.BirthDate,
                Address = dto.Address,
                EmergencyContact = dto.EmergencyContact,
                EmploymentType = dto.EmploymentType
            };

            var created = await _repository.AddAsync(dossier);
            return await GetByIdAsync(created.DossierID);
        }

        public async Task UpdateAsync(Guid id, EmployeeDossierRequestDto dto)
        {
            var dossier = new EmployeeDossier
            {
                DossierID = id,
                EmployeeID = dto.EmployeeID,
                BirthDate = dto.BirthDate,
                Address = dto.Address,
                EmergencyContact = dto.EmergencyContact,
                EmploymentType = dto.EmploymentType
            };

            await _repository.UpdateAsync(dossier);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        private EmployeeDossierResponseDto MapToDto(EmployeeDossier dossier)
        {
            return new EmployeeDossierResponseDto
            {
                DossierID = dossier.DossierID,
                EmployeeID = dossier.EmployeeID,
                EmployeeName = $"{dossier.Employee?.FirstName} {dossier.Employee?.LastName}",
                BirthDate = dossier.BirthDate,
                Address = dossier.Address,
                EmergencyContact = dossier.EmergencyContact,
                EmploymentType = dossier.EmploymentType
            };
        }
    }
}
