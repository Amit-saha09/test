using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class DeliveryManRepository:Repository<DeliveryMan>
    {
        public List<DeliveryMan> GetByName(string name)
        {
            return this.contex.DeliveryMens.Where(e=>e.Name.Contains(name)).ToList();
        }
    }
}