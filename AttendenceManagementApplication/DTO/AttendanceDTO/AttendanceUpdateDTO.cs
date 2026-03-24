using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.DTO.AttendanceDTO
{
    public class AttendanceUpdateDTO
    {
        public int AttendanceId { get; set; }
        public int UserId { get; set; }
        public int RecordedBy { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; } = string.Empty;
        public string? Course { get; set; } = string.Empty;
    }
}
