using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class AppointmentRepository : Repository<Appointment>
    {
        /*public Appointment GetConsumerById(int id)
        {
            return this.contex.Appointments.Where(x => x.ConsumerId == id).FirstOrDefault();
        }*/
    }
}