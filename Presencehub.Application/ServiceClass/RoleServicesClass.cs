using AutoMapper;
using Presencehub.Application.Dto;
using Presencehub.Application.ServiceInterface;
using Presencehub.Domain.Entity;
using Presencehub.Domain.RepoInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Application.ServiceClass
{
    public class RoleServicesClass : IRoleServicesInterface
    {
        private readonly IRolesRepoInterface rolesRepoInterface;
        private readonly IMapper mapper;

        public RoleServicesClass(IRolesRepoInterface rolesRepoInterface,IMapper mapper)
        {
            this.rolesRepoInterface = rolesRepoInterface;
            this.mapper = mapper;
        }

        public async Task<int> AddRole(RoleDto roleDto)
        {
            var role=mapper.Map<Role>(roleDto);
            return await rolesRepoInterface.AddRole(role);
        }

        public async Task<int> DeleteRole(int id)
        {
            return await rolesRepoInterface.DeleteRole(id);
        }

        public async Task<IList<RoleDto>> GetAllRoles()
        {
            var role = await rolesRepoInterface.GetAllRoles();
            return mapper.Map<IList<RoleDto>>(role);
        }

       public async Task<RoleDto> GetRoleById(int id)
        {
            var role=await rolesRepoInterface.GetRoleById(id);
            return mapper.Map<RoleDto>(role);
        }

        public async Task<int> UpdateRole(RoleDto roleDto)
        {
            var role = mapper.Map<Role>(roleDto);
            return await rolesRepoInterface.UpdateRole(role);
        }
    }
}
