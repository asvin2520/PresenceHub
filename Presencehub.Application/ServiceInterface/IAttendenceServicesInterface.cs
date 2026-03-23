using Presencehub.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Application.ServiceInterface
{
    public interface IAttendenceServicesInterface
    {
        Task<int> AddUser(AttendanceDto attendanceDto);
        Task<int> UpdateUser(AttendanceDto attendanceDto);
        Task<int> DeleteUser(int id);
        Task<IList<AttendanceDto>> GetAllUser();
        Task<AttendanceDto> GetUserById(int id);
    }
}
