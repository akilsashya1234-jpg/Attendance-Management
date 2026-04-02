using AttendenceManagementApplication.DTO.RoleDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.Interface.IService
{
    public interface IServiceRole
    {
        Task<IEnumerable<RoleReadDTO>> GetAllRolesAsync();
        Task<RoleReadDTO?> GetRoleById(int id);
        Task CreateRole(RoleCreateDTO dto);
        Task UpdateRole(RoleUpdateDTO dto);
        Task DeleteRole(int id);
    }
}
