using AttendenceManagementDomain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementDomain.Interface.IRepository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRolesAsync(int id);
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
    }
}
