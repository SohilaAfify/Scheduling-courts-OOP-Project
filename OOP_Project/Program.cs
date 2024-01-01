namespace OOP_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Customer cust = new Customer(1, "Sohila", 0123456, "example@gmail.com", "123","Customer");
            bool isCustomer=true;
            for (int i = 1; i<=3; i++)
            {

                
                Console.WriteLine("Enter you name");
                String userName = Console.ReadLine();
                Console.WriteLine("Enter you email");
                String userEmail = Console.ReadLine();
                Console.WriteLine("Enter you password");
                String userPassword = Console.ReadLine();
                Console.WriteLine("Enter you role");
                String Userrole = Console.ReadLine();
                isCustomer = cust.Login(userName, userEmail, userPassword, Userrole);
                Console.WriteLine(isCustomer);
                Console.WriteLine("\n \n");

                if (i == 3 && isCustomer== false) {
                    Console.WriteLine("Try again later");
                        }
                if (isCustomer == true) { break; }
            }
             if (isCustomer == true)
            {

                Console.WriteLine("Welcome to E7gazli <3");
                var gamesList = new List<string>()
                    {
                        "Football",
                        "Tennis",
                        "Vollyball",
                        "Padel"
                    };
                cust.printList(gamesList);

                Console.WriteLine("\n \nChoose an option");
                int option = int.Parse(Console.ReadLine());


                var footBallList = new List<string>()
                    {
                        "court 1",
                        "court 2",
                        "court 3",
                        "court 4"
                    };


                Football football = new Football(1, "Football", 200, footBallList);
                


                cust.choose(option);
            }
        }
    }
}
