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
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _repository;

        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AssetResponseDto>> GetAllAsync()
        {
            var assets = await _repository.GetAllAsync();
            return assets.Select(MapToDto);
        }

        public async Task<AssetResponseDto> GetByIdAsync(Guid id)
        {
            var asset = await _repository.GetByIdAsync(id);
            return asset == null ? null : MapToDto(asset);
        }

        public async Task<AssetResponseDto> GetBySerialNumberAsync(string serialNumber)
        {
            var asset = await _repository.GetBySerialNumberAsync(serialNumber);
            return asset == null ? null : MapToDto(asset);
        }

        public async Task<IEnumerable<AssetResponseDto>> GetByEmployeeIdAsync(Guid employeeId)
        {
            var assets = await _repository.GetByEmployeeIdAsync(employeeId);
            return assets.Select(MapToDto);
        }

        public async Task<AssetResponseDto> CreateAsync(AssetRequestDto dto)
        {
            var asset = new Asset
            {
                EmployeeID = dto.EmployeeID,
                Name = dto.Name,
                Description = dto.Description,
                SerialNumber = dto.SerialNumber,
                IsActive = dto.IsActive
            };

            var created = await _repository.AddAsync(asset);
            return await GetByIdAsync(created.AssetID);
        }

        public async Task UpdateAsync(Guid id, AssetRequestDto dto)
        {
            var asset = new Asset
            {
                AssetID = id,
                EmployeeID = dto.EmployeeID,
                Name = dto.Name,
                Description = dto.Description,
                SerialNumber = dto.SerialNumber,
                IsActive = dto.IsActive,
                AssignmentDate = DateTime.UtcNow // Maintain original assignment date
            };

            await _repository.UpdateAsync(asset);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        private AssetResponseDto MapToDto(Asset asset)
        {
            return new AssetResponseDto
            {
                AssetID = asset.AssetID,
                EmployeeID = asset.EmployeeID,
                EmployeeName = $"{asset.Employee?.FirstName} {asset.Employee?.LastName}",
                Name = asset.Name,
                Description = asset.Description,
                SerialNumber = asset.SerialNumber,
                AssignmentDate = asset.AssignmentDate,
                IsActive = asset.IsActive
            };
        }
    }
}
