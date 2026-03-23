using Presencehub.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Presencehub.Application.Dto
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }

       
        public int UserId { get; set; }

       

        public DateOnly Date { get; set; }

        public string? Status { get; set; }

       
        public int RecordedBy { get; set; }

        
    }
}
