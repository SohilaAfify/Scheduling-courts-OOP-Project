using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Customer : Users
    {


        public Customer()
        {     
        }
        public Customer( string Name, string PhoneNumber, string EmailAddress, string Password, String Role) : base( Name, PhoneNumber, EmailAddress, Password, Role)
        {
        }


       public static void SaveCustomers(List<Customer> customers)
        {
            try
            {
                string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(@"C:\json\filename.json", json);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error saving JSON data: {ex.Message}");
            }
        }

        public static List<Customer> LoadCustomers()
        {
            List<Customer> customers;

            try
            {
                if (File.Exists(@"C:\json\filename.json"))
                {
                    string json = File.ReadAllText(@"C:\json\filename.json");
                    customers = JsonSerializer.Deserialize<List<Customer>>(json);

                    if (customers == null)
                        customers = new List<Customer>();
                }
                else
                {
                    customers = new List<Customer>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error loading JSON data: {ex.Message}");
                customers = new List<Customer>();
            }

            return customers;
        }


    }
}
