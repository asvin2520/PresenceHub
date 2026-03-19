using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Domain.RepoInterface
{
    public interface IRolesRepoInterface
    {
        Task<int> AddRole(Role role);
        Task<int> UpdateRole(Role role);
        Task<int> DeleteRole(int id);
        Task<IList<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
    }
}
