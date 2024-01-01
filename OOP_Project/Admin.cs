using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Admin : Users
    {

        public List<String> gamesList { get; set; }

        public Admin( string Name, String PhoneNumber, string EmailAddress, string Password, String Role) : base(Name, PhoneNumber, EmailAddress, Password, Role)
        {
        }
    }
}
