using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto> GetByIdAsync(Guid id);
        Task<UserResponseDto> GetByEmailAsync(string email);
        Task<UserResponseDto> AddAsync(UserRequestDto dto);
        Task UpdateAsync(Guid id, UserRequestDto dto);
        Task DeleteAsync(Guid id);
    }
}
