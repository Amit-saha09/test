using PharmaAssist2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Repository
{
    public class LoginRepository : Repository<Login>
    {
        public Login Getregistared(string q)
        {
           
               var p = this.contex.Logins.Where(x => x.Email == q).FirstOrDefault();
                return p;


        }
        public Login Getthat(string q)
        {
            var p = this.contex.Logins.Where(x => x.Email == q).FirstOrDefault();
            return p;

        }

        public void UpdateLoginStatus(int id, int status)
        {
            Login user = this.contex.Logins.Where(x => x.Id == id).FirstOrDefault();

            user.LoginStatus = status;

            this.Update(user);
        }

        public Login GetUser(Login user)
        {
            var p = this.contex.Logins.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
            return p;
        }

        public List<Login> GetPendings(string usertype)
        {

            var p = this.contex.Logins.Where(x => x.Type.Equals(usertype) && x.RegistrationStatus == 3).ToList();
            return p;
        }

        public void ApproveUserRegistration(int id)
        {
            Login user = this.contex.Logins.Where(x => x.Id == id).FirstOrDefault();

            user.LoginStatus = 1;

            user.RegistrationStatus = 1;

            this.Update(user);
        }

        public void RejectUserUserRegistration(int id)
        {
            Login user = this.contex.Logins.Where(x => x.Id == id).FirstOrDefault();

            user.LoginStatus = 2;

            user.RegistrationStatus = 2;

            this.Update(user);
        }

        public void AproveAllPendingDoctors()
        {
            using (var p2 = new PharmaAssistDB())
            {
                int e = p2.Database.ExecuteSqlCommand("UPDATE Logins SET LoginStatus = '1', RegistrationStatus = '1' WHERE RegistrationStatus = '3' AND Type = 'Doctor';");
            }
        }
    }
}
    