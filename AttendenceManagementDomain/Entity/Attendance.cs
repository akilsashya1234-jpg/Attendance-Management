using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AttendenceManagementDomain.Entity
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int UserId { get; set; }
        public int RecordedBy { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; } = string.Empty;
        public string? Course { get; set; } = string.Empty;

        //[ForeignKey("UserId")]
        public User? User { get; set; }

        //[ForeignKey("RecordedBy")]
        public User? RecordedUser { get; set; }
    }
}
