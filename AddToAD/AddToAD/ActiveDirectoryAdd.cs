using System;
using System.Collections.Generic;
using System.DirectoryServices;
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
            public string displayName; //display Name
            public string username; //UserName,  THIS IS REQUIRED
            public string sAMAccountName; //SAMA account, THIS IS REQUIRED
            public string givenName; //First Name
            public string sn; //Last Name
        }
        public static void CreateADUser(string FirstName, string LastName)
        {
            UserInfo newUserInfo;
            newUserInfo.displayName = FirstName + "." + LastName;
            newUserInfo.username = FirstName + "." + LastName;
            newUserInfo.sAMAccountName = FirstName + "." + LastName;
            newUserInfo.givenName = FirstName;
            newUserInfo.sn = LastName;
            DirectoryEntry adUserFolder = new DirectoryEntry("LDAP://", "username", "password"); // Using "LDAP: // ENTER DOMAIN CONTROLLER IP/CN=Users,DC=DOMAIN NAME,DC=com", username, password *\
            if (adUserFolder.SchemaEntry.Name == "container")
            {
                DirectoryEntry newUser = adUserFolder.Children.Add("CN=" + newUserInfo.username, "User");
                try
                {
                    newUser.Properties["sAMAccountName"].Value = newUserInfo.sAMAccountName;
                    newUser.Properties["givenName"].Value = newUserInfo.givenName;
                    newUser.Properties["sn"].Value = newUserInfo.sn;
                    newUser.Properties["displayName"].Value = newUserInfo.displayName;
                    newUser.CommitChanges();
                    newUser.Invoke("setpassword", "Password123"); //sets password to Password123
                    newUser.Properties["userAccountControl"].Value = 0x0200; //value to set account to enabled
                    newUser.Properties["pwdLastSet"][0] = 0; //sets password to expire
                    newUser.CommitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("See LDAP Connection string");
                Console.ReadKey();
            }
        }
    }
}
