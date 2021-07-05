using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Totalprice { get; set; }

        public int ConsumerId { get; set; }

       
    }
}