using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models.ModelView
{
    public class ProductCategory
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public ProductCategory()
        {
            Categories = new List<Category>();
        }
    }
}