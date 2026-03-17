using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Presencehub.Domain.Entity
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public string FullName { get; set; }

        public DateOnly DOB { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Department { get; set; }

        public int Year { get; set; }

        public User User { get; set; }
    }
}
