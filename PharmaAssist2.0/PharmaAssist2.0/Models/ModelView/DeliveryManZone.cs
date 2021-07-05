using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models.ModelView
{
    public class DeliveryManZone
    {
        public DeliveryMan DeliveryMan { get; set; }
        public List<Zone> Zones { get; set; }
        public DeliveryManZone()
        {
            Zones = new List<Zone>();
        }
    }
}