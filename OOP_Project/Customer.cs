using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Customer : Users
    {

        public List<String> gamesList { get; set; }

    public Customer( string Name, string PhoneNumber, string EmailAddress, string Password, String Role) : base( Name, PhoneNumber, EmailAddress, Password, Role)
        {
        }


        public void printList(List<String> gamesList)
        {
          for(int i = 0; i < gamesList.Count; i++) {

                Console.WriteLine($"choose {i}: {gamesList[i]}");

            }
        }

        public void choose(int option)
        {
            switch (option)
            {
                case 0: 
                break;

               

            }

        }
    }
}
