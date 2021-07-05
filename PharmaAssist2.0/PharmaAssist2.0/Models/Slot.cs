using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class Slot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}