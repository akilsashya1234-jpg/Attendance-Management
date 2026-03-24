using AttendenceManagementApplication.DTO.AttendanceDTO;
using AttendenceManagementApplication.Interface.IService;
using AttendenceManagementDomain.Entity;
using AttendenceManagementDomain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;

        public AttendanceService(IAttendanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AttendanceReadDTO>> GetAllAttendanceAsync()
        {
            var attendanceList = await _repository.GetAllAttendanceAsync();

            return attendanceList.Select(a => new AttendanceReadDTO
            {
                AttendanceId = a.AttendanceId,
                UserId = a.UserId,
                UserName = a.User != null ? a.User.UserName : null,
                RecordedBy = a.RecordedBy,
                RecordedByUserName = a.RecordedUser != null ? a.RecordedUser.UserName : null,
                Date = a.Date,
                Status = a.Status,
                Course = a.Course
            });
        }

        public async Task<AttendanceReadDTO?> GetAttendanceByIdAsync(int id)
        {
            var a = await _repository.GetAttendanceByIdAsync(id);

            if (a == null)
                return null;

            return new AttendanceReadDTO
            {
                AttendanceId = a.AttendanceId,
                UserId = a.UserId,
                UserName = a.User != null ? a.User.UserName : null,
                RecordedBy = a.RecordedBy,
                RecordedByUserName = a.RecordedUser != null ? a.RecordedUser.UserName : null,
                Date = a.Date,
                Status = a.Status,
                Course = a.Course
            };
        }

        public async Task CreateAttendanceAsync(AttendanceCreateDTO dto)
        {
            var attendance = new Attendance
            {
                UserId = dto.UserId,
                RecordedBy = dto.RecordedBy,
                Date = dto.Date,
                Status = dto.Status,
                Course = dto.Course
            };

            await _repository.AddAttendanceAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(AttendanceUpdateDTO dto)
        {
            var existingAttendance = await _repository.GetAttendanceByIdAsync(dto.AttendanceId);

            if (existingAttendance == null)
                throw new Exception("Attendance record not found");

            existingAttendance.UserId = dto.UserId;
            existingAttendance.RecordedBy = dto.RecordedBy;
            existingAttendance.Date = dto.Date;
            existingAttendance.Status = dto.Status;
            existingAttendance.Course = dto.Course;

            await _repository.UpdateAttendanceAsync(existingAttendance);
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var existingAttendance = await _repository.GetAttendanceByIdAsync(id);

            if (existingAttendance == null)
                throw new Exception("Attendance record not found");

            await _repository.DeleteAttendanceAsync(id);
        }
    }
}
