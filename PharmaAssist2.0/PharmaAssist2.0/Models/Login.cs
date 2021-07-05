using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }

        public int  RegistrationStatus { get; set; }

        public int LoginStatus { get; set; }

        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Consumer> Consumers { get; set; }
        public virtual ICollection<ProblemComment> ProblemComments { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<DeliveryMan> DeliveryMens { get; set; }
    }
}