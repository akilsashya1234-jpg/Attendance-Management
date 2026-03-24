//using AttendenceManagementApplication.DTO.UserDTO;
//using AttendenceManagementDomain.Entity;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace AttendenceManagementApplication.Mapper
//{
//    //public class UserProfile : Profile
//    //{
//    //    public UserProfile()
//    //    {
//    //        CreateMap<User, UserReadDTO>();
//    //        CreateMap<UserCreateDTO, User>();
//    //        CreateMap<UserUpdateDTO, User>();
//    //    }
//    //}

//    public class UserProfile : Profile
//    {
//        public UserProfile()
//        {
//            //CreateMap<User, UserReadDTO>()
//            //    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
//            //    //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
//            //    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleID))
//            //    .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.FullName : string.Empty))
//            //    .ForMember(dest => dest.DOB, opt => opt.MapFrom(src => src.UserDetails != null ? DateOnly.FromDateTime(src.UserDetails.DOB) : default))
//            //    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Gender : string.Empty))
//            //    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.PhoneNumber : string.Empty))
//            //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Address : string.Empty))
//            //    .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Department : string.Empty))
//            //    .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Year : 0));

//            //    CreateMap<UserCreateDTO, User>()
//            //        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
//            //        .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
//            //        .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleId))
//            //        .ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => new UserDetails
//            //        {
//            //            FullName = src.Fullname,
//            //            DOB = src.DOB.ToDateTime(TimeOnly.MinValue),
//            //            Gender = src.Gender,
//            //            PhoneNumber = src.Phone,
//            //            Address = src.Address,
//            //            Department = src.Department,
//            //            Year = src.Year
//            //        }));

//            //    CreateMap<UserUpdateDTO, User>()
//            //        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
//            //        .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
//            //        .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleId))
//            //        .ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => new UserDetails
//            //        {
//            //            FullName = src.Fullname,
//            //            DOB = src.DOB.ToDateTime(TimeOnly.MinValue),
//            //            Gender = src.Gender,
//            //            PhoneNumber = src.Phone,
//            //            Address = src.Address,
//            //            Department = src.Department,
//            //            Year = src.Year
//            //        }));
//            //}
//        }
//    }
//}


using AttendenceManagementApplication.DTO.UserDTO;
using AttendenceManagementDomain.Entity;
using AutoMapper;

namespace AttendenceManagementApplication.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleID))
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.FullName : string.Empty))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Gender : string.Empty))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.PhoneNumber : string.Empty))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Address : string.Empty))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Department : string.Empty))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.UserDetails != null ? src.UserDetails.Year : 0));

            CreateMap<UserCreateDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => new UserDetails
                {
                    FullName = src.Fullname,
                    Gender = src.Gender,
                    PhoneNumber = src.Phone,
                    Address = src.Address,
                    Department = src.Department,
                    Year = src.Year
                }));

            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => new UserDetails
                {
                    Id = 0,
                    FullName = src.Fullname,
                    Gender = src.Gender,
                    PhoneNumber = src.Phone,
                    Address = src.Address,
                    Department = src.Department,
                    Year = src.Year
                }));
        }
    }
}