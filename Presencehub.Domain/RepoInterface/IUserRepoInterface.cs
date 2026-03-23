using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Domain.RepoInterface
{
    public interface IUserRepoInterface
    {
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(int id);
        Task<IList<User>> GetAllUser();
        Task<User> GetUserById(int id);
        Task<User> LoginUser(string username, string password);

    }
}
