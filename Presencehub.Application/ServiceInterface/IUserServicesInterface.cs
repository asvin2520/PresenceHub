using Presencehub.Application.Dto;
using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Application.ServiceInterface
{
    public interface IUserServicesInterface
    {
        Task<int> AddUser(PostDto userDto);
        Task<int> UpdateUser(PostDto userDto);
        Task<int> DeleteUser(int id);
        Task<IList<PostDto>> GetAllUser();
        Task<PostDto> GetUserById(int id);
        Task<User> LoginUser(LoginDto login);
    }
}
