using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.DTO.RoleDTO
{
    public class RoleUpdateDTO
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
