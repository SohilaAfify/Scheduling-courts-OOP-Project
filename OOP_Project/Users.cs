using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        

        public Users(int id, string Name, int PhoneNumber, string EmailAddress, String Password, String Role)
        {
            this.Id = id;
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
