using AttendenceManagementApplication.DTO.AuthDTO;
using AttendenceManagementApplication.DTO.UserDTO;
using AttendenceManagementApplication.Interface.IService;
using AttendenceManagementDomain.Entity;
using AttendenceManagementDomain.Interface.IRepository;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AttendenceManagementApplication.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration config;
        private static readonly ILog log = LogManager.GetLogger(typeof(UserService));

        public UserService(IUserRepository repository, IMapper mapper,IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            this.config = config;
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _repository.GetAllUsersAsync();
                log.Info("Getting all users");
                return _mapper.Map<IEnumerable<UserReadDTO>>(users);
            }
            catch (Exception ex)
            {
                log.Error("Error while getting all users", ex);
                throw;
            }
        }

        public async Task<UserReadDTO?> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _repository.GetUserByIdAsync(id);

                if (user == null)
                    return null;

                log.Info($"Getting user by id: {id}");
                return _mapper.Map<UserReadDTO>(user);
            }
            catch (Exception ex)
            {
                log.Error($"Error while getting user by id: {id}", ex);
                throw;
            }
        }

        public async Task CreateUserAsync(UserCreateDTO dto)
        {
            try
            {
                log.Info("Creating user");

                var user = _mapper.Map<User>(dto);
                user.CreatedAt = DateTime.UtcNow;

                if (user.UserDetails != null)
                {
                    user.UserDetails.User = user;
                }

                await _repository.AddUserAsync(user);
            }
            catch (Exception ex)
            {
                log.Error("Error while creating user", ex);
                throw;
            }
        }


        public async Task UpdateUserAsync(UserUpdateDTO dto)
        {
            //    try
            //    {
            //        log.Info($"Updating user with id: {dto.Id}");

            //        var existingUser = await _repository.GetUserByIdAsync(dto.Id);
            //        if (existingUser == null)
            //            throw new Exception("User not found");

            //        _mapper.Map(dto, existingUser);

            //        if (existingUser.UserDetails != null)
            //        {
            //            existingUser.UserDetails.UserID = existingUser.Id;
            //        }

            //        await _repository.UpdateUserAsync(existingUser);
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error($"Error while updating user with id: {dto.Id}", ex);
            //        throw;
            //    }
            try
            {
                log.Info($"Updating user with id: {dto.Id}");

                var existingUser = await _repository.GetUserByIdAsync(dto.Id);
                if (existingUser == null)
                    throw new Exception("User not found");

                // update main user table
                existingUser.UserName = dto.UserName;
                existingUser.Email = dto.Email;
                existingUser.PasswordHash = dto.Password;
                existingUser.RoleID = dto.RoleId;

                // update userdetails table
                if (existingUser.UserDetails == null)
                {
                    existingUser.UserDetails = new UserDetails();
                }

                existingUser.UserDetails.UserID = existingUser.Id;
                existingUser.UserDetails.FullName = dto.Fullname;
                existingUser.UserDetails.Gender = dto.Gender;
                existingUser.UserDetails.PhoneNumber = dto.Phone;
                existingUser.UserDetails.Address = dto.Address;
                existingUser.UserDetails.Department = dto.Department;
                existingUser.UserDetails.Year = dto.Year;

                await _repository.UpdateUserAsync(existingUser);
            }
            catch (Exception ex)
            {
                log.Error($"Error while updating user with id: {dto.Id}", ex);
                throw;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                log.Info($"Deleting user with id: {id}");

                var existingUser = await _repository.GetUserByIdAsync(id);
                if (existingUser == null)
                    throw new Exception("User not found");

                await _repository.DeleteUserAsync(id);
            }
            catch (Exception ex)
            {
                log.Error($"Error while deleting user with id: {id}", ex);
                throw;
            }
        }

        public async Task<LoginResponseDTO> Login(LoginDTO dto)
        {
            var data = new User
            {
                UserName = dto.UserName,
                PasswordHash = dto.Password
            };

            var result = await _repository.Login(data);

            if (result == null)
            {
                return null;
            }
            var claims = new List<Claim>
{
    new Claim(ClaimTypes.Name, result.UserName),
    new Claim(ClaimTypes.Role, result.Role.RoleName),
    new Claim("Id", result.Id.ToString())
};

            // 🔥 Read JWT settings
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 🔥 Create Token
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            // 🔥 Return with token
         

            var responsedata = new LoginResponseDTO
            {
                UserId = result.Id,
                Role = result.Role.RoleName,
                Token = jwt

            };

            return responsedata;
        }

        public async Task<UserCreateDTO> Register(UserCreateDTO data)
        {
            var result = new User
            {
                Id = data.Id,
                UserName = data.UserName,
                PasswordHash = data.Password,
                Email = data.Email,
                RoleID = data.RoleId,
                UserDetails = new UserDetails
                {
                    FullName = data.Fullname,
                    DOB = data.DOB,
                    Gender = data.Gender,
                    PhoneNumber = data.Phone,
                    Address = data.Address,
                    Department = data.Department,
                    Year = data.Year



                }
            };
            var datareturn=await _repository.Register(result);
            var actualdata = new UserCreateDTO {

                Id = datareturn.Id,
                UserName = datareturn.UserName,
                Password = datareturn.PasswordHash,
                Email = datareturn.Email,
                RoleId= datareturn.RoleID,
               
                
                    Fullname = datareturn.UserDetails.FullName,
                    //DOB = datareturn.UserDetails.DOB,
                    Gender = datareturn.UserDetails.Gender,
                    Phone = datareturn.UserDetails.PhoneNumber,
                    Address = datareturn.UserDetails.Address,
                    Department = datareturn.UserDetails.Department,
                    Year = datareturn.UserDetails.Year



                


            };
            return actualdata;
    } } 

}
