using AttendanceManagementInfrastructure.Dbcontext;
using AttendenceManagementDomain.Entity;
using AttendenceManagementDomain.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceManagementInfrastructure.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceDbContext _context;

        public AttendanceRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendanceAsync()
        {
            return await _context.Attendances
                .Include(a => a.User)
                .Include(a => a.RecordedUser)
                .ToListAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.User)
                .Include(a => a.RecordedUser)
                .FirstOrDefaultAsync(a => a.AttendanceId == id);
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceId == id);

            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }
    }
}
