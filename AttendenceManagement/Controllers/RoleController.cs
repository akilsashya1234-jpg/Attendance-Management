using AttendenceManagementApplication.DTO.RoleDTO;
using AttendenceManagementApplication.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IServiceRole _service;

        public RoleController(IServiceRole service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _service.GetRoleById(id);

            if (role == null)
                return NotFound("Role not found");

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDTO dto)
        {
            await _service.CreateRole(dto);
            return Ok("Role Created Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleUpdateDTO dto)
        {
            await _service.UpdateRole(dto);
            return Ok("Role Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _service.DeleteRole(id);
            return Ok("Role Deleted Successfully");
        }
    }
}
