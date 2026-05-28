using ProjectFlow.Application.DTOs;
using ProjectFlow.Domain.Entities;

namespace ProjectFlow.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Add(UserInsertDto dto);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto?> GetById(Guid id);
        Task<UserDto?> Update(UserDto dto);
        Task<UserDto?> Remove(Guid id);
        Task<string> Login(LoginDto dto);

    }
}