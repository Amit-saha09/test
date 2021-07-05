using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class OrderRepository:Repository<Order>

    {
        public Order GetId(int id, string invoice)
        {
            var p = new Order();
            p = this.contex.Orders.Where(x => x.InvoiceNumber == invoice && x.ConsumerId == id).FirstOrDefault() ;
            return p;
        }
    }
}