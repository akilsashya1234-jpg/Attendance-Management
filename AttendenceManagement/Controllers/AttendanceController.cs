using AttendenceManagementApplication.DTO.AttendanceDTO;
using AttendenceManagementApplication.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendenceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAttendanceAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetAttendanceByIdAsync(id);

            if (result == null)
                return NotFound("Attendance not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AttendanceCreateDTO dto)
        {
            await _service.CreateAttendanceAsync(dto);
            return Ok("Attendance Created Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update(AttendanceUpdateDTO dto)
        {
            await _service.UpdateAttendanceAsync(dto);
            return Ok("Attendance Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAttendanceAsync(id);
            return Ok("Attendance Deleted Successfully");
        }
    }
}
