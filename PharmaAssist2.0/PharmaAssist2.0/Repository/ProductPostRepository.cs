using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class ProductPostRepository: Repository<Product>
    {
        public List<Product> GetByName(string name)
        {
            return this.contex.Products.Where(e => e.Name.Contains(name)).ToList();
        }
    }
}