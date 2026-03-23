using System;
using System.Collections.Generic;
using System.Text;

namespace Presencehub.Application.Dto
{
    public class PostDto
    {
        public int Id { get; set; }


        public string UserName { get; set; }


        public string Password { get; set; }


        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }
        public string FullName { get; set; }

        public DateOnly DOB { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }

        public int Year { get; set; }
    }
}
