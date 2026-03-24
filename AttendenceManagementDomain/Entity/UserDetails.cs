using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AttendenceManagementDomain.Entity
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string? Gender { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Department { get; set; } = string.Empty;
        public int Year { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }
    }
}
