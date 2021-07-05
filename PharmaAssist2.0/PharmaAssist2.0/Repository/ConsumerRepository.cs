using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class ConsumerRepository : Repository<Consumer>
    {
        public Consumer GetConsumerByEmail(string email)
        {
            return this.contex.Consumers.Where(x => x.Email == email).FirstOrDefault();
        }

        public Consumer GetConsumerById(int id)
        {
            return this.contex.Consumers.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}