using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ConsumerId { get; set; }
        [Required]
        public int SlotId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual Consumer Consumer { get; set; }
        public virtual Slot Slot { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}