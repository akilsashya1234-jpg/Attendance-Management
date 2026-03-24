using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AttendenceManagementDomain.Entity
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
