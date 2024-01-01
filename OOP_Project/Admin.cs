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

        public Admin(int id, string Name, int PhoneNumber, string EmailAddress, string Password, String Role) : base(id, Name, PhoneNumber, EmailAddress, Password, Role)
        {
        }
    }
}
