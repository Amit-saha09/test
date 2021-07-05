using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        
        public int DoctorId { get; set; }
        [Required]
        public string Image { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public HttpPostedFileBase Imagefile { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}