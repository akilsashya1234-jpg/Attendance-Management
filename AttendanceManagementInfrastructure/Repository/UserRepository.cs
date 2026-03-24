//using AttendanceManagementInfrastructure.Dbcontext;
//using AttendenceManagementDomain.Entity;
//using AttendenceManagementDomain.Interface.IRepository;
//using Microsoft.EntityFrameworkCore;
////using AutoMapper;
////using log4net;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace AttendanceManagementInfrastructure.Repository
//{
//    public class UserService : IUserRepository
//    {
//        public class UserRepository : IUserRepository
//        {
//            private readonly AttendanceDbContext _context;

//            public UserRepository(AttendanceDbContext context)
//            {
//                _context = context;
//            }

//            public async Task<IEnumerable<User>> GetAllUsersAsync()
//            {
//                return await _context.Users
//                    .Include(u => u.UserDetails)
//                    .Include(u => u.Role)
//                    .ToListAsync();
//            }

//            public async Task<User?> GetUserByIdAsync(int id)
//            {
//                return await _context.Users
//                    .Include(u => u.UserDetails)
//                    .Include(u => u.Role)
//                    .FirstOrDefaultAsync(u => u.Id == id);
//            }

//            public async Task AddUserAsync(User user)
//            {
//                await _context.Users.AddAsync(user);
//                await _context.SaveChangesAsync();
//            }

//            public async Task UpdateUserAsync(User user)
//            {
//                _context.Users.Update(user);

//                if (user.UserDetails != null)
//                {
//                    if (user.UserDetails.Id == 0)
//                        await _context.UsersDetails.AddAsync(user.UserDetails);
//                    else
//                        _context.UsersDetails.Update(user.UserDetails);
//                }

//                await _context.SaveChangesAsync();
//            }

//            public async Task DeleteUserAsync(int id)
//            {
//                var user = await _context.Users
//                    .Include(u => u.UserDetails)
//                    .FirstOrDefaultAsync(u => u.Id == id);

//                if (user != null)
//                {
//                    if (user.UserDetails != null)
//                        _context.UsersDetails.Remove(user.UserDetails);

//                    _context.Users.Remove(user);
//                    await _context.SaveChangesAsync();
//                }
//            }
//        }
//    }
//}


using AttendanceManagementInfrastructure.Dbcontext;
using AttendenceManagementDomain.Entity;
using AttendenceManagementDomain.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementInfrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AttendanceDbContext _context;

        public UserRepository(AttendanceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.UserDetails)
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.UserDetails)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);

            if (user.UserDetails != null)
            {
                if (user.UserDetails.Id == 0)
                    await _context.UsersDetails.AddAsync(user.UserDetails);
                else
                    _context.UsersDetails.Update(user.UserDetails);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.UserDetails)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                if (user.UserDetails != null)
                    _context.UsersDetails.Remove(user.UserDetails);

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> Login(User user)
        {
           return await _context.Users.Include(x=>x.Role).FirstOrDefaultAsync(x=>x.UserName==user.UserName && x.PasswordHash==user.PasswordHash);
            
        }

        public async Task<User> Register(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}