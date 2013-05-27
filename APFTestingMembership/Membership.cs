using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;
using System.Web.Security;


namespace APFTestingMembership
{
    public class Membership
    {
        public int RegisterAdministrator(string username, string password)
        {
            return 0;
        }

        public int RegisterExaminer(string username, string password)
        {
            if (WebSecurity.UserExists(username))
            {
                return -1;
            }
            
            
            WebSecurity.CreateUserAndAccount(username, password);
            Roles.AddUsersToRole(new string[] { username }, "Examiner");
            return WebSecurity.GetUserId(username);
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return WebSecurity.ChangePassword(username, oldPassword, newPassword);
        }

        public bool DeleteExaminer(string username)
        {
            Roles.RemoveUserFromRole(username, "Examiner");
            return System.Web.Security.Membership.DeleteUser(username, true);
        }

        public bool Login(string username, string password, bool rememberMe = false)
        {
            if (username == null || password == null)
            {
                return false;
            }
            
            return WebSecurity.Login(username, password, rememberMe);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }
    }
}
