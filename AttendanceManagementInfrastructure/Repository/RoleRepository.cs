using AttendanceManagementInfrastructure.Dbcontext;
using AttendenceManagementDomain.Entity;
using AttendenceManagementDomain.Interface.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceManagementInfrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AttendanceDbContext _context;

        public RoleRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRolesAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}

