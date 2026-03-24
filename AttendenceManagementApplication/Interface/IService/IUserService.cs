using AttendenceManagementApplication.DTO.AuthDTO;
using AttendenceManagementApplication.DTO.UserDTO;
using AttendenceManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.Interface.IService
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
        Task<UserReadDTO?> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserCreateDTO dto);
        Task UpdateUserAsync(UserUpdateDTO dto);
        Task DeleteUserAsync(int id);
        Task<LoginResponseDTO> Login(LoginDTO dto);
        Task<UserCreateDTO> Register(UserCreateDTO dto);


       
    }
}
