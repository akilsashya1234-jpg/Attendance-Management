using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.DTO.AuthDTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
       
        public string Role { get; set; } = string.Empty;
        //public UserDetailsReadDTO? UserDetails { get; set; }
    }
}
