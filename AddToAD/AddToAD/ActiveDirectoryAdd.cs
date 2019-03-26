using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddToAD
{
    class ActiveDirectoryAdd
    {
        public struct UserInfo
        {
            //LDAP fields in Active Directory ---- You can add more here, such as "mail", "proxyAddresses", and "telephoneNumber"..
            //sAMAccountName & username are required for creating a user.
            public string username;  //UserName,  THIS IS REQUIRED
            public string sAMAccountName; //SAMA account, THIS IS REQUIRED
            public string givenName; //First Name
            public string sn; //Last Name
        }
        private void CreateADUser(string FirstName, string LastName, uint PhoneNumber)
        {
            

        }
    }
}
