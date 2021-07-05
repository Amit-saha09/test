using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class ManagerRepository : Repository<Manager>
    {
        public List<Manager> GetManagerByName(string name)
        {
            return this.contex.Managers.Where(x => x.Name.Contains(name)).ToList();
        }
        public Manager GetManagerByEmail(string email)
        {
            return this.contex.Managers.Where(x => x.Email.Contains(email)).FirstOrDefault();
        }

    }
}