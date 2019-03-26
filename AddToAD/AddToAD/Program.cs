using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddToAD
{
    class Program
    {
        static void Main(string[] args)
        {   
            Employee.EmployeeInfo User = new Employee.EmployeeInfo { FirstName = "Test", LastName = "Test" };
            ActiveDirectoryAdd.CreateADUser(User.FirstName, User.LastName);
        }
    }
}
