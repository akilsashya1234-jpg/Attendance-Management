using AttendenceManagementApplication.DTO.RoleDTO;
using AttendenceManagementDomain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.Mapper
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleReadDTO>();
            CreateMap<RoleCreateDTO, Role>();
            CreateMap<RoleUpdateDTO, Role>();
        }
    }

}
