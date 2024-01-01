using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Users
    {
 
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        

        public Users( string Name, string PhoneNumber, string EmailAddress, String Password, String Role)
        {
          
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.EmailAddress = EmailAddress;
            this.Password = Password;
            this.Role = Role;
        }


        public bool Login(String name, string EmailAddress, String Password, String Role)
        {

            bool isUser = false;
            if (this.Name == name && this.EmailAddress == EmailAddress && this.Password == Password && this.Role == Role)
            {
                isUser = true;
            }
            else
            {
                isUser = false;
            }

            return isUser;

        }


       
    }
}
