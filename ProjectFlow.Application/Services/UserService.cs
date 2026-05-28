using Microsoft.VisualBasic;
using ProjectFlow.Application.DTOs;
using ProjectFlow.Application.Interfaces;
using ProjectFlow.Domain.Entities;
using ProjectFlow.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace ProjectFlow.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService( ITokenService tokenService , IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Add(UserInsertDto dto)
        {
            var user = new User(
                dto.Name,
                dto.Email,
                dto.Password,
                dto.RoleId
            );

            await _userRepository.Add(user);
            await _userRepository.SaveChanges();

            return new UserDto
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.UserName,
                Email = u.Email,
                RoleId = u.RoleId
            });
        }

        public async Task<UserDto?> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByEmail(dto.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Credenciales inválidas");

            if (user.PasswordHash != dto.Password) ///user.PasswordHash != dto.Password  cundo ek problmes de emcriptar
                throw new UnauthorizedAccessException("Credenciales inválidas");

            return _tokenService.CreateToken(user);
        }
        public async Task<UserDto?> Remove(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) return null;

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                RoleId = user.RoleId
            };

            await _userRepository.Delete(user);
            await _userRepository.SaveChanges();

            return userDto;
        }

        public async Task<UserDto?> Update(UserDto dto)
        {
            var user = await _userRepository.GetById(dto.Id);
            if (user == null) return null;

            // ✅ DTO → ENTITY
            user.UserName = dto.Name;
            user.Email = dto.Email;
            user.RoleId = dto.RoleId;
            user.DateUpdate = DateTime.Now;

            await _userRepository.SaveChanges();

            return new UserDto
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
    }
}