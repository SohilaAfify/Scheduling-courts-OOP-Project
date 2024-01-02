using System.Text.Json;
using System.Xml.Linq;


namespace OOP_Project
{
    internal class Program
    {
        static List<Customer> LoadCustomers()
        {
            List<Customer> customers;

            try
            {
                if (File.Exists(@"C:\Users\sohila\Desktop\Users.json"))
                {
                    string json = File.ReadAllText(@"C:\Users\sohila\Desktop\Users.json");
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

        static void SaveCustomers(List<Customer> customers)
        {
            try
            {
                string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(@"C:\Users\sohila\Desktop\Users.json", json);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error saving JSON data: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {

            Admin admin = new Admin("Admin", "0123456", "Admin@gmail.com", "123", "Admin");
            var cust = LoadCustomers();

            bool isCustomer = false;

            bool isAdmin = false;

            for (; ; )
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                string option1 = Console.ReadLine(); ;

                if (option1 == "1") // Register
                {
                    Console.WriteLine("Enter your username");
                    string userName = Console.ReadLine();

                    Console.WriteLine("Enter your phone number");
                    string userPhoneNumber = Console.ReadLine();

                    Console.WriteLine("Enter your Email");
                    string userEmail = Console.ReadLine();


                    Console.WriteLine("Enter your password");
                    string userPassword = Console.ReadLine();

                    Console.WriteLine("Enter your role");
                    string userRole = Console.ReadLine();

                    cust.Add(new Customer(userName, userPhoneNumber, userEmail, userPassword, userRole));
                    
                    SaveCustomers(cust);
                }
                else if (option1 == "2") // Login
                {
                    for (int i0 = 1; i0 <= 3; i0++)

                    {
                        Console.WriteLine("Enter your name");
                        string userName = Console.ReadLine(); ;
                        Console.WriteLine("Enter you email");
                        String userEmail = Console.ReadLine();
                        Console.WriteLine("Enter you password");
                        String userPassword = Console.ReadLine();
                        Console.WriteLine("Enter you role");
                        String Userrole = Console.ReadLine();

                        if(Userrole == "customer")
                        {
                            foreach (var customer in cust)
                            {
                                isCustomer = customer.Login(userName, userEmail, userPassword, Userrole);
                                if (isCustomer == true)
                                {
                                    break;
                                }
                            }
                        }else if(Userrole ==  "Admin")
                        {
                           isAdmin =  admin.Login(userName, userEmail, userPassword, Userrole);
                        }


                        isAdmin = admin.Login(userName, userEmail, userPassword, Userrole);
                        
                        Console.WriteLine("\n \n");

                        if ( (i0 == 3 && isCustomer == false) || (i0 == 3 && isAdmin == false))
                        {
                            Console.WriteLine("Try again later");
                        }
                        if (isCustomer == true || isAdmin == true) {
                            
                            if(isCustomer)
                            {
                                Console.WriteLine("Hello Customer");
                            }else
                            {
                                Console.WriteLine("Hello Admin");
                            }
                        }
                    }
                }

            }

        }

    }
}