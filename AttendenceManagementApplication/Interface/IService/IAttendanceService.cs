using AttendenceManagementApplication.DTO.AttendanceDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.Interface.IService
{
    public interface IAttendanceService
    {
        Task<IEnumerable<AttendanceReadDTO>> GetAllAttendanceAsync();
        Task<AttendanceReadDTO?> GetAttendanceByIdAsync(int id);
        Task CreateAttendanceAsync(AttendanceCreateDTO dto);
        Task UpdateAttendanceAsync(AttendanceUpdateDTO dto);
        Task DeleteAttendanceAsync(int id);
    }
}
