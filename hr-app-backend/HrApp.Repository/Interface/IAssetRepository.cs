using HrApp.DomainEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Repository.Interface
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset> GetByIdAsync(Guid id);
        Task<Asset> GetBySerialNumberAsync(string serialNumber);
        Task<IEnumerable<Asset>> GetByEmployeeIdAsync(Guid employeeId);
        Task<Asset> AddAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(Guid id);
    }
}
