using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class ConsumerRepository : Repository<Consumer>
    {
        public Consumer GetbyLogin(int id)
        {
            return this.contex.Consumers.Where(x => x.LoginId == id).FirstOrDefault();
        }
    }
}