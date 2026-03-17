using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Presencehub.Domain.Entity
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateOnly Date { get; set; }

        public string Status { get; set; }

        public int RecordedBy { get; set; }
        public User RecordedByUser { get; set; }
    }
}