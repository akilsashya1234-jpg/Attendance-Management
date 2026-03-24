using AttendenceManagementApplication.DTO.AuthDTO;
using AttendenceManagementApplication.DTO.UserDTO;
using AttendenceManagementApplication.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AttendenceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ✅ GET ALL USERS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Fetching all users");

                var users = await _service.GetAllUsersAsync();

                _logger.LogInformation("Fetched {Count} users", users.Count());

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching users");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // ✅ GET USER BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Fetching user with ID {Id}", id);

                var user = await _service.GetUserByIdAsync(id);

                if (user == null)
                {
                    _logger.LogWarning("User not found with ID {Id}", id);
                    return NotFound("User not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching user with ID {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // ✅ LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                _logger.LogInformation("Login attempt for user {UserName}", dto.UserName);

                var result = await _service.Login(dto);

                if (result == null)
                {
                    _logger.LogWarning("Invalid login attempt for user {UserName}", dto.UserName);
                    return Unauthorized("Invalid username or password");
                }

                _logger.LogInformation("User {UserName} logged in successfully", dto.UserName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during login for user {UserName}", dto.UserName);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // ✅ CREATE USER
        //[HttpPost]
        //public async Task<IActionResult> CreateUser(UserCreateDTO dto)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Creating user {UserName}", dto.UserName);

        //        await _service.CreateUserAsync(dto);

        //        _logger.LogInformation("User {UserName} created successfully", dto.UserName);

        //        return Ok("User Created Successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error while creating user {UserName}", dto.UserName);
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        // ✅ UPDATE USER
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO dto)
        {
            try
            {
                _logger.LogInformation("Updating user ID {Id}", dto.Id);

                await _service.UpdateUserAsync(dto);

                _logger.LogInformation("User ID {Id} updated successfully", dto.Id);

                return Ok("User Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating user ID {Id}", dto.Id);
                return StatusCode(500, "Internal Server Error");
            }
        }

        // ✅ DELETE USER
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation("Deleting user ID {Id}", id);

                await _service.DeleteUserAsync(id);

                _logger.LogInformation("User ID {Id} deleted successfully", id);

                return Ok("User Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting user ID {Id}", id);
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDTO dto)
        {
            try
            {
                _logger.LogInformation("Register attempt");

                var result = await _service.Register(dto);

                if (result == null)
                {
                    _logger.LogWarning("User already exists");
                    return BadRequest("User already exists");
                }

                _logger.LogInformation("User registered successfully");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during registration");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
    
}