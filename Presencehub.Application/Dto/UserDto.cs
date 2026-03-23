using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Presencehub.Application.Dto
{
    public class UserDto
    {
        
        public int Id { get; set; }

       
        public string UserName { get; set; }

      
        public string Password { get; set; }

        
        public string Email { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }
        public UserDetailsDto UserDetails { get; set; }
    }
}
