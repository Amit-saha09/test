using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string InvoiceNumber { get; set; }
        public int? ProductId { get; set; }

        public int Quantity { get; set; }   
        public int ConsumerId { get; set; } 

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Consumer Consumer { get; set; }
    }
}