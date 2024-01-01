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

        static void SaveCustomers(List<Customer> customers)
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
        static void Main(string[] args)
        {

            //Customer cust = new Customer(1, "Sohila", 0123456, "example@gmail.com", "123", "Customer");
            //bool isCustomer = true;

            List<Customer> cust = LoadCustomers();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Enter your name");
                string userName = Console.ReadLine();

                Console.WriteLine("Enter your phone number");
                string userPhoneNumber = Console.ReadLine();

                Console.WriteLine("Enter your Email");
                string userEmail = Console.ReadLine();

                Console.WriteLine("Enter your password");
                string userPassword = Console.ReadLine();

                Console.WriteLine("Enter your role");
                string userRole = Console.ReadLine();



                // Add a new Customer to the list
                cust.Add(new Customer(userName, userPhoneNumber, userEmail, userPassword, userRole));



                // Save the updated list of customers
                SaveCustomers(cust);

            Console.WriteLine("Customer data saved successfully!");
            Console.ReadLine(); // Keep the console window open
        }

        //if (i == 3 && isCustomer== false) {
        //    Console.WriteLine("Try again later");
        //        }
        //if (isCustomer == true) { break; }
    }
    // if (isCustomer == true)
    //{

    //    Console.WriteLine("Welcome to E7gazli <3");
    //    var gamesList = new List<string>()
    //        {
    //            "Football",
    //            "Tennis",
    //            "Vollyball",
    //            "Padel"
    //        };
    //    cust.printList(gamesList);

    //    Console.WriteLine("\n \nChoose an option");
    //    int option = int.Parse(Console.ReadLine());


    //var footBallList = new List<string>()
    //    {
    //        "court 1",
    //        "court 2",
    //        "court 3",
    //        "court 4"
    //    };


    //Football football = new Football(1, "Football", 200, footBallList);



    //cust.choose(option);
}
        }
    

