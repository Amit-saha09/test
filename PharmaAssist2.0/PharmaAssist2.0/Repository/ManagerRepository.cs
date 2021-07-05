using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
	public class ManagerRepository : Repository<Manager>
    {
        public Manager GetManagerByEmail(string email)
        {
            return this.contex.Managers.Where(x => x.Email == email).FirstOrDefault();
        }

        public Manager GetManagerById(int id)
        {
            return this.contex.Managers.Where(x => x.Id == id).FirstOrDefault();
        }
    }
	}
