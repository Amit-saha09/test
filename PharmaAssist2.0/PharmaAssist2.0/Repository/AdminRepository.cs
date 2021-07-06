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

        public bool InsertAdmin(Admin user)
        {
            try
            {
                this.contex.Admins.Add(user);



                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Admin GetAdmin(int id)
        {
            return this.contex.Admins.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
