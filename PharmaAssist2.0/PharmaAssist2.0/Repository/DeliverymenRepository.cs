using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class DeliverymenRepository : Repository<DeliveryMen>
    {
        public List<DeliveryMen> GetAdminsByName(string name)
        {
            return this.contex.DeliveryMens.Where(x => x.Name.Contains(name)).ToList();
        }

    }
}