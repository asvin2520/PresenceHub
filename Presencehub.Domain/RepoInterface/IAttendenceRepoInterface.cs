using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Domain.RepoInterface
{
    public interface IAttendenceRepoInterface
    {
        Task<int> AddUser(Attendance attendance);
        Task<int> UpdateUser(Attendance attendance);
        Task<int> DeleteUser(int id);
        Task<IList<Attendance>> GetAllUser();
        Task<Attendance> GetUserById(int id);
    }
}
