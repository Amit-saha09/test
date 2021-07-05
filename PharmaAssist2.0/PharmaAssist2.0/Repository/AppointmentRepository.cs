using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class AppointmentRepository : Repository<Appointment>
    {
        public List<Appointment> GetConsumerById(int id)
        {
            return this.contex.Appointments.Where(x => x.ConsumerId == id).ToList();
        }
        public List<Appointment> GetDoctorById(int id)
        {
            return this.contex.Appointments.Where(x => x.DoctorId == id).ToList();
        }
    }
}