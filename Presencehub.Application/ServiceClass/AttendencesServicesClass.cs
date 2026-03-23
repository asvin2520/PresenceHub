using AutoMapper;
using Presencehub.Application.Dto;
using Presencehub.Application.ServiceInterface;
using Presencehub.Domain.Entity;
using Presencehub.Domain.RepoInterface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Presencehub.Application.ServiceClass
{
    public class AttendencesServicesClass : IAttendenceServicesInterface
    {
        private readonly IAttendenceRepoInterface attendenceRepoInterface;
        private readonly IMapper mapper;

        public AttendencesServicesClass(IAttendenceRepoInterface attendenceRepoInterface,IMapper mapper)
        {
            this.attendenceRepoInterface = attendenceRepoInterface;
            this.mapper = mapper;
        }

        public async Task<int> AddUser(AttendanceDto attendanceDto)
        {
           var atten =mapper.Map<Attendance>(attendanceDto);
            return await attendenceRepoInterface.AddUser(atten);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await attendenceRepoInterface.DeleteUser(id);
        }

        public async Task<IList<AttendanceDto>>GetAllUser()
        {
            var atten =await attendenceRepoInterface.GetAllUser();
            return mapper.Map<IList<AttendanceDto>>(atten);
        }

        public async Task<AttendanceDto> GetUserById(int id)
        {
            var atten = await attendenceRepoInterface.GetUserById(id);
            return mapper.Map<AttendanceDto>(atten);
        }

        public async Task<int> UpdateUser(AttendanceDto attendanceDto)
        {
            var atten = mapper.Map<Attendance>(attendanceDto);
            return await attendenceRepoInterface.UpdateUser(atten);
        }
    }
}
