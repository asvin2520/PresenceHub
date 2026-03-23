using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Presencehub.Application.Dto;
using Presencehub.Application.ServiceInterface;
using Presencehub.Domain.Entity;
using Presencehub.Domain.RepoInterface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Presencehub.Application.ServiceClass
{
    public class UserServicesClass : IUserServicesInterface
    {
        private readonly IUserRepoInterface userRepoInterface;
        private readonly IMapper mapper;


        public UserServicesClass(IUserRepoInterface userRepoInterface, IMapper mapper)
        {
            this.userRepoInterface = userRepoInterface;
            this.mapper = mapper;

        }

        public async Task<int> AddUser(PostDto postDto)
        {
            var user = new User
            {
                UserName = postDto.UserName,
                Password = postDto.Password,
                Email = postDto.Email,
                CreatedAt = postDto.CreatedAt,
                RoleId = postDto.RoleId,

                UserDetails = new UserDetails
                {
                    FullName = postDto.FullName,
                    DOB = postDto.DOB,
                    Gender = postDto.Gender,
                    PhoneNumber = postDto.PhoneNumber,
                    Address = postDto.Address,
                    Department = postDto.Department,
                    Year = postDto.Year
                }
            };

            return await userRepoInterface.AddUser(user);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await userRepoInterface.DeleteUser(id);
        }

        public async Task<IList<PostDto>> GetAllUser()
        {
            var res = await userRepoInterface.GetAllUser();
            return mapper.Map<IList<PostDto>>(res);
        }


        public async Task<PostDto> GetUserById(int id)
        {
            var res = await userRepoInterface.GetUserById(id);
            return mapper.Map<PostDto>(res);
        }

        public async Task<int> UpdateUser(PostDto userDto)
        {
            var res = mapper.Map<User>(userDto);
            return await userRepoInterface.UpdateUser(res);
        }
        public async Task<User> LoginUser(LoginDto login)
        {
            return await userRepoInterface.LoginUser(login.UserName, login.Password);
        }



    }
 }
