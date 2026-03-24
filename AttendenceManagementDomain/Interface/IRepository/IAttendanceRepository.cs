using AttendenceManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementDomain.Interface.IRepository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAttendanceAsync();
        Task<Attendance?> GetAttendanceByIdAsync(int id);
        Task AddAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
    }
}
