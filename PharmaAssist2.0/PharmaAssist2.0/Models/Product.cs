using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int ManagerId { get; set; }

        public int CategoryId { get; set; }

        public string Image { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public HttpPostedFileBase Imagefile { get; set; }
        [Required]
        public string Genericname { get; set; }
        [Required]
        public string Brandname { get; set; }

        [Required]
        public string Introduction { get; set; }
        [Required]
        public string AdultDose { get; set; }
        [Required]
        public string ChildDose { get; set; }
        [Required]
        public string RenalDose { get; set; }
        [Required]
        public string Administration { get; set; }
        [Required]
        public string Contraindictions { get; set; }

        [Required]
        public string SideEffect { get; set; }
        [Required]
        public string Warnning { get; set; }
        [Required]
        public string PregnancyLactation { get; set; }
        [Required]
        public string TherapeticClass { get; set; }
        [Required]
        public string ModeofAction { get; set; }
        [Required]
        public string Interaction { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        public double Power { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}