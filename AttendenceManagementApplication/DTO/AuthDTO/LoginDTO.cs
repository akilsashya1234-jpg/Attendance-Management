using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.DTO.AuthDTO
{
    public class LoginDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
