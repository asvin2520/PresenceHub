using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presencehub.Domain.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        
        public string UserName { get; set; }

        
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Role Role { get; set; }

        public UserDetails UserDetails { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}