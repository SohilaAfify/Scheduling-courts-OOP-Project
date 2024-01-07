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

        public void AddSport(Sport sport)
        {
            Sports.Add(sport);
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


    }
}
