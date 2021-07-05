using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class AdminRepository : Repository<Admin>
    {
        public List<Admin> GetAdminsByName(string name)
        {
            return this.contex.Admins.Where(x => x.Name.Contains(name)).ToList();
        }

    }
}