using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP_Project
{

    internal class SportsFacility
    {
        public List<Sport> Sports { get; set; } = new List<Sport>();


        public SportsFacility()
        {
            Sports = new List<Sport>();
        }

        public void DisplaySports()
        {
            Console.WriteLine("Sports available:");

            for (int i = 0; i < Sports.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Sports[i].Name}");
            }
        }

        public void RemoveCourt(int sportIndex, string courtName)
        {
            if (sportIndex >= 0 && sportIndex < Sports.Count)
            {
                Sport sport = Sports[sportIndex];

                // Remove all courts with the specified name
                sport.Courts.RemoveAll(court => court.Name == courtName);

                Console.WriteLine($"All courts named '{courtName}' removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid sport index!");
            }
        }

        public static SportsFacility LoadData()
        {
            try
            {
                if (File.Exists(@"C:\json\Court.json"))
                {
                    string jsonData = File.ReadAllText(@"C:\json\Court.json");

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

        public static void SaveData(SportsFacility sportsFacility)
        {
            string jsonData = JsonSerializer.Serialize(sportsFacility, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"C:\json\Court.json", jsonData);
            Console.WriteLine("Data saved successfully.");
        }
    }
}
