using Presencehub.Application.Dto;
using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Application.ServiceInterface
{
    public interface IRoleServicesInterface
    {
        Task<int> AddRole(RoleDto roleDto);
        Task<int> UpdateRole(RoleDto roleDto);
        Task<int> DeleteRole(int id);
        Task<IList<RoleDto>> GetAllRoles();
        Task<RoleDto> GetRoleById(int id);

    }
}
