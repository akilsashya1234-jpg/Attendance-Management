using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.DTO.AttendanceDTO
{
    public class AttendanceReadDTO
    {
        public int AttendanceId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }

        public int RecordedBy { get; set; }
        public string? RecordedByUserName { get; set; }

        public DateTime Date { get; set; }
        public string? Status { get; set; }
        public string? Course { get; set; }
    }
}
