using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models.ModelView
{
    public class DoctorSpecialist
    {
        public Doctor Doctor { get; set; }
        public List<Specialist> Specialists { get; set; }
        public DoctorSpecialist()
        {
            Specialists = new List<Specialist>();
        }
    }
}