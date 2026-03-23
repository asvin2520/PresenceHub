using Microsoft.EntityFrameworkCore;
using Presencehub.Domain.Entity;
using Presencehub.Domain.RepoInterface;
using Presencehub.Infrastructure.Dbcontextclass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Infrastructure.RepositoryClass
{
    public class UserRepoClass : IUserRepoInterface
    {
        private readonly PresencehubDbContextClass dbContext;

        public UserRepoClass(PresencehubDbContextClass dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddUser(User user)
        {
            await dbContext.Users.AddAsync(user);

            try
            {
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            var res = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
                return 0;

            dbContext.Users.Remove(res);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAllUser()
        {
            return await dbContext.Users.Include(x=>x.UserDetails).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await dbContext.Users
                .Include(x => x.UserDetails)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        
        public async Task<int> UpdateUser(User user)
        {
            var existing = await dbContext.Users
                .Include(x => x.UserDetails)
                .FirstOrDefaultAsync(x => x.Id == user.Id);

            if (existing == null)
                return 0;

            dbContext.Entry(existing).CurrentValues.SetValues(user);

            if (existing.UserDetails != null && user.UserDetails != null)
            {
                dbContext.Entry(existing.UserDetails).CurrentValues.SetValues(user.UserDetails);
            }

            return await dbContext.SaveChangesAsync();
        }
        public async Task<User?> LoginUser(string username, string password)
        {
            return await dbContext.Users
                .Include(x => x.UserDetails)
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }

    }
}
