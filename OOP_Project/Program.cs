using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using static OOP_Project.Program;



namespace OOP_Project
{
    internal class Program
    {
        private const string DataFilePath = @"C:\json\Court.json";
        private const string DataFilePath1 = @"C:\json\try.json";
        private static Customer loggedInCustomer;
        private static Sport selectedSport;
        private static Court selectedCourt;


       
        // Display available data
        private static void DisplayAvailableCourts(List<Court> courts)
        {
            HashSet<string> displayedCourts = new HashSet<string>();

            Console.WriteLine("Available Courts:");

            foreach (var court in courts)
            {
                string courtName = court.Name;

                // Check if the court name has been displayed before
                if (!displayedCourts.Contains(courtName))
                {
                    Console.WriteLine($"{courtName}");
                    displayedCourts.Add(courtName);
                }
            }

            // Display the court indices for selection
            for (int i = 0; i < displayedCourts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {displayedCourts.ElementAt(i)}");
            }
        }
        public static void GenerateMonthCalendar(int year, int month)
        {
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine(firstDayOfMonth.ToString("MMMM yyyy"));
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            for (int i = 0; i < startDayOfWeek; i++)
            {
                Console.Write("    ");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                Console.Write($"{day,3}");

                if ((startDayOfWeek + day) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
        
        private static SportsFacility LoadData()
        {
            try
            {
                if (File.Exists(DataFilePath))
                {
                    string jsonData = File.ReadAllText(DataFilePath);

                    if (!string.IsNullOrWhiteSpace(jsonData))
                    {
                        return JsonSerializer.Deserialize<SportsFacility>(jsonData);
                    }
                    else
                    {
                        Console.WriteLine("JSON file is empty.");
                    }
                }
                else
                {
                    Console.WriteLine("JSON file does not exist.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            // Handle the case when the file doesn't exist, is empty, or deserialization fails
            Console.WriteLine("Creating a new instance of SportsFacility.");
            return new SportsFacility();
        }


        private static void SaveData(SportsFacility sportsFacility)
        {
            string jsonData = JsonSerializer.Serialize(sportsFacility, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, jsonData);
            Console.WriteLine("Data saved successfully.");
        }
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

            List<Day> days = new List<Day>();
            // Load the data from the JSON file
            string json = File.ReadAllText(@"C:\json\try.json");
            days = JsonSerializer.Deserialize<List<Day>>(json);


            SportsFacility sportsFacility = LoadData();

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
                        Console.WriteLine("Enter your role");
                        string Userrole = Console.ReadLine();


                        if (Userrole == "customer")
                        {
                            foreach (var customer in cust)
                            {
                                isCustomer = customer.Login(userName, userEmail, userPassword, Userrole);
                                if (isCustomer)
                                {
                                    break;
                                }
                            }
                        }
                        else if (Userrole == "Admin")
                        {
                            isAdmin = admin.Login(userName, userEmail, userPassword, Userrole);
                        }

                        // Remove the following line since it's already inside the if-else block
                        // isAdmin = admin.Login(userName, userEmail, userPassword, Userrole);

                        Console.WriteLine("\n \n");

                        if ((i0 == 3 && isCustomer == false) || (i0 == 3 && isAdmin == false))
                        {
                            Console.WriteLine("Try again later");
                        }
                        if (isCustomer == true || isAdmin == true)
                        {
                            if (isCustomer)
                            {
                                Console.WriteLine("List of Sports:");
                                sportsFacility.DisplaySports();

                                // Let the customer choose a sport
                                Console.Write("Enter the number of the sport you want to choose: ");
                                int sportIndex = int.Parse(Console.ReadLine()) - 1;

                                if (sportIndex >= 0 && sportIndex < sportsFacility.Sports.Count)
                                {
                                    selectedSport = sportsFacility.Sports[sportIndex];
                                    Console.WriteLine($"You selected the sport: {selectedSport.Name}");

                                    // Display available courts for the selected sport
                                    DisplayAvailableCourts(selectedSport.Courts);

                                    // Let the customer choose a court
                                    Console.Write("Enter the number of the court you want to choose: ");
                                    int courtIndex = int.Parse(Console.ReadLine()) - 1;

                                    if (courtIndex >= 0 && courtIndex < selectedSport.Courts.Count)
                                    {
                                        selectedCourt = selectedSport.Courts[courtIndex];
                                        Console.WriteLine($"You selected the court: {selectedCourt.Name}");

                                        while (true)
                                        {
                                            Console.WriteLine("1. Display Calendar");
                                            Console.WriteLine("2. Logout");

                                            string customerOption = Console.ReadLine();

                                            switch (customerOption)
                                            {
                                                case "1": // Display Calendar
                                                          // Display the month calendar
                                                    GenerateMonthCalendar(DateTime.Now.Year, DateTime.Now.Month);

                                                    // Display available dates for the selected court
                                                    Console.WriteLine("Available Dates:");
                                                    foreach (var court in selectedSport.Courts)
                                                    {
                                                        Console.Write($"{court.MonthDay} ");
                                                    }

                                                    Console.WriteLine("\nPlease enter a date (choose from the available dates):");

                                                    // Validate the entered date
                                                    int selectedDay;
                                                    while (true)
                                                    {
                                                        if (int.TryParse(Console.ReadLine(), out selectedDay))
                                                        {
                                                            if (selectedSport.Courts.Any(court => court.MonthDay == selectedDay))
                                                            {
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid date. Please choose from the available dates.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter a valid number.");
                                                        }
                                                    }

                                                    var selectedCourt = selectedSport.Courts.First(court => court.MonthDay == selectedDay);

                                                    Console.WriteLine($"Available Times for {selectedCourt.MonthDay}:");

                                                    for (int i = 0; i < selectedCourt.Times.Count; i++)
                                                    {
                                                        Console.WriteLine($"{selectedCourt.Times[i]} - {(selectedCourt.IsReserved[i] ? "Not Available" : "Available")}");
                                                    }

                                                    Console.WriteLine("Please enter the time slot (choose from the available times):");

                                                    // Validate the entered time slot
                                                    int selectedTimeSlot;
                                                    while (true)
                                                    {
                                                        if (int.TryParse(Console.ReadLine(), out selectedTimeSlot))
                                                        {
                                                            if (selectedTimeSlot >= 1 && selectedTimeSlot <= selectedCourt.Times.Count)
                                                            {
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid time slot. Please choose from the available times.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid input. Please enter a valid number.");
                                                        }
                                                    }

                                                    // Adjust the index to match the zero-based indexing of the lists
                                                    int timeEntry = selectedTimeSlot - 1;

                                                    if (!selectedCourt.IsReserved[timeEntry])
                                                    {
                                                        Console.WriteLine($"You have successfully reserved the court {selectedCourt.Times[timeEntry]}");
                                                        selectedCourt.IsReserved[timeEntry] = true;

                                                        // Exit the loop after successful reservation
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("This time is not available");
                                                    }
                                                    break;

                                                case "2": // Logout
                                                    SaveData(sportsFacility); // Save changes before logout
                                                    Console.WriteLine("Logout successful!");
                                                    return;

                                                default:
                                                    Console.WriteLine("Invalid option. Please try again.");
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid court selection!");
                                        return;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid sport selection!");
                                    return;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hello Admin");

                                while (true)
                                {
                                    Console.WriteLine("1. Add Court");
                                    Console.WriteLine("2. Delete Court");
                                    Console.WriteLine("3. Logout");

                                    string adminOption = Console.ReadLine();

                                    switch (adminOption)
                                    {
                                        case "1": // Add Court
                                            Console.WriteLine("List of Sports:");
                                            sportsFacility.DisplaySports();

                                            Console.Write("Enter the number of the sport you want to choose: ");
                                            int sportIndex = int.Parse(Console.ReadLine()) - 1;

                                            if (sportIndex >= 0 && sportIndex < sportsFacility.Sports.Count)
                                            {
                                                Sport chosenSport = sportsFacility.Sports[sportIndex];

                                                Console.Write("Enter the name of the court: ");
                                                string courtName = Console.ReadLine();

                                                // Load the available dates from try.json
                                                List<Day> availableDates;
                                                string tryJson = File.ReadAllText(@"C:\json\try.json");
                                                availableDates = JsonSerializer.Deserialize<List<Day>>(tryJson);

                                                // Use the available month days from try.json
                                                foreach (var availableDate in availableDates)
                                                {
                                                    Court newCourt = new Court(
                                                        courtName,
                                                        availableDate.MonthDay,
                                                        new List<bool>(availableDate.IsReserved),
                                                        new List<string>(availableDate.Times)
                                                    );

                                                    chosenSport.AddCourt(newCourt);
                                                    Console.WriteLine("Court added successfully!");

                                                    // Save the updated data to the specific court
                                                    string courtJson = JsonSerializer.Serialize(newCourt, new JsonSerializerOptions { WriteIndented = true });
                                                    File.WriteAllText($"C:\\json\\{courtName}.json", courtJson);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid sport selection!");
                                            }
                                            break;
                                        case "2": // Delete Court
                                            Console.WriteLine("List of Sports:");
                                            sportsFacility.DisplaySports();
                                            Console.Write("Enter the number of the sport you want to choose: ");
                                            sportIndex = int.Parse(Console.ReadLine());

                                            Sport selectedSport = null;
                                            Court selectedCourt = null;

                                            if (sportIndex > 0 && sportIndex <= sportsFacility.Sports.Count)
                                            {
                                                selectedSport = sportsFacility.Sports[sportIndex - 1];
                                                Console.WriteLine($"You selected the sport: {selectedSport.Name}");

                                                // Display available courts for the selected sport
                                                DisplayAvailableCourts(selectedSport.Courts);

                                                // Let the admin choose a court
                                                Console.Write("Enter the number of the court you want to delete: ");
                                                int courtIndexToDelete = int.Parse(Console.ReadLine()) - 1;

                                                if (courtIndexToDelete >= 0 && courtIndexToDelete < selectedSport.Courts.Count)
                                                {
                                                    string courtNameToDelete = selectedSport.Courts[courtIndexToDelete].Name;

                                                    // Call the RemoveCourt method to delete all courts with the specified name
                                                    sportsFacility.RemoveCourt(sportIndex - 1, courtNameToDelete);
                                                    SaveData(sportsFacility); // Save changes after deletion
                                                    Console.WriteLine($"All courts named '{courtNameToDelete}' removed successfully!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid court index!");
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid sport selection!");
                                                return;
                                            }
                                            break;
                                        case "3": // Logout
                                            SaveData(sportsFacility); // Save changes before logout
                                            Console.WriteLine("Logout successful!");
                                            return;

                                        default:
                                            Console.WriteLine("Invalid option. Please try again.");
                                            break;
                                    }
                                }
                            }
                        }
                    }

                }

            }

        }
    }
}
