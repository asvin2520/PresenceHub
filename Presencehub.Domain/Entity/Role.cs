using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presencehub.Domain.Entity
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}