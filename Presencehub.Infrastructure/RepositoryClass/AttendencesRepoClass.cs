using Microsoft.EntityFrameworkCore;
using Presencehub.Domain.Entity;
using Presencehub.Domain.RepoInterface;
using Presencehub.Infrastructure.Dbcontextclass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Infrastructure.RepositoryClass
{
    public class AttendencesRepoClass : IAttendenceRepoInterface
    {
        private readonly PresencehubDbContextClass dbContext;

        public AttendencesRepoClass(PresencehubDbContextClass dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddUser(Attendance attendance)
        {
            await dbContext.Attendances.AddAsync(attendance);

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
            var res = await dbContext.Attendances.FirstOrDefaultAsync(x => x.AttendanceId == id);

            if (res == null)
                return 0;

            dbContext.Attendances.Remove(res);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IList<Attendance>> GetAllUser()
        {
            return await dbContext.Attendances.ToListAsync();
        }

        public async Task<Attendance>GetUserById(int id)
        {
            return await dbContext.Attendances
               .FirstOrDefaultAsync(x => x.AttendanceId == id);
        }

        public async Task<int> UpdateUser(Attendance attendance)
        {
            var existing = await dbContext.Attendances.FindAsync(attendance.AttendanceId);

            if (existing == null)
                return 0;

            dbContext.Entry(existing).CurrentValues.SetValues(attendance);

            return await dbContext.SaveChangesAsync();
        }
    }
}
