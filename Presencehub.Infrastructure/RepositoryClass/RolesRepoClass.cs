using Microsoft.EntityFrameworkCore;
using Presencehub.Domain.Entity;
using Presencehub.Domain.RepoInterface;
using Presencehub.Infrastructure.Dbcontextclass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Infrastructure.RepositoryClass
{
    public class RolesRepoClass : IRolesRepoInterface
    {
        private readonly PresencehubDbContextClass dbContext;

        public RolesRepoClass(PresencehubDbContextClass dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddRole(Role role)
        {
            await dbContext.Roles.AddAsync(role);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteRole(int id)
        {
            var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.RoleId == id);

            if (role != null)
            {
                dbContext.Roles.Remove(role);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Role>> GetAllRoles()
        {
            return await dbContext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await dbContext.Roles.FindAsync(id);
        }

        public async Task<int> UpdateRole(Role role)
        {
            dbContext.Roles.Update(role);
            return await dbContext.SaveChangesAsync();
        }
    }
}