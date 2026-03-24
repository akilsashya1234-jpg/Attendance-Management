using AttendenceManagementApplication.DTO.RoleDTO;
using AttendenceManagementApplication.Interface.IService;
using AttendenceManagementDomain.Entity;
using AttendenceManagementDomain.Interface.IRepository;
using AutoMapper;
using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendenceManagementApplication.Service
{
    public class RoleService : IServiceRole
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;
        private static readonly ILog log = LogManager.GetLogger(typeof(RoleService));

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleReadDTO>> GetAllRolesAsync()
        {
            log.Info("Getting all roles");
            var roles = await _repository.GetAllRolesAsync();
            return _mapper.Map<IEnumerable<RoleReadDTO>>(roles);
        }

        public async Task<RoleReadDTO?> GetRoleById(int id)
        {
            log.Info($"Getting role by id: {id}");
            var role = await _repository.GetRolesAsync(id);

            if (role == null)
                return null;

            return _mapper.Map<RoleReadDTO>(role);
        }

        public async Task CreateRole(RoleCreateDTO dto)
        {
            log.Info("Creating role");

            var role = _mapper.Map<Role>(dto);
            await _repository.AddRoleAsync(role);
        }

        public async Task UpdateRole(RoleUpdateDTO dto)
        {
            log.Info($"Updating role with id: {dto.RoleID}");

            var existingRole = await _repository.GetRolesAsync(dto.RoleID);
            if (existingRole == null)
                throw new Exception("Role not found");

            _mapper.Map(dto, existingRole);
            await _repository.UpdateRoleAsync(existingRole);
        }

        public async Task DeleteRole(int id)
        {
            log.Info($"Deleting role with id: {id}");

            var existingRole = await _repository.GetRolesAsync(id);
            if (existingRole == null)
                throw new Exception("Role not found");

            await _repository.DeleteRoleAsync(id);
        }
    }
}
