using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AttendenceManagementDomain.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("RoleID")]
        public Role? Role { get; set; }

        //public ICollection<UserDetails> UserDetails { get; set; } = new List<UserDetails>();
        public UserDetails? UserDetails { get; set; }
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Attendance> RecordedBy { get; set; } = new List<Attendance>();
        public ICollection<Attendance> RecordedAttendances { get; set; } = new List<Attendance>();
    }
}
