using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presencehub.Domain.Entity
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }

        public DateOnly Date { get; set; }

        public string? Status { get; set; }

        [ForeignKey("RecordedByUser")]
        public int RecordedBy { get; set; }

        public User? RecordedByUser { get; set; }
    }
}