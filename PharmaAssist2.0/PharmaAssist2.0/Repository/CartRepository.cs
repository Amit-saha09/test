using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class CartRepository:Repository<Cart>
    {
        public List<Cart> ShowCart(int id)
        {
            return this.contex.Carts.Where(x => x.ConsumerId==id).ToList();
        }
        public Cart Check(int id, int ProductId)
        {
             var p = new Cart();
            p = this.contex.Carts.Where(x => x.ConsumerId == id && x.ProductId==ProductId).FirstOrDefault();
            return p;
        }
    }
}