using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.DTO.UserDTO
{
    public class UserUpdateDTO
    {
        // 🔸 User fields
        public int Id { get; set; }          // required for update
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }

        // 🔸 Userdetails fields
        public string Fullname { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
