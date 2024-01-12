using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Court
    {
        public string Name { get; set; }
        public int MonthDay { get; set; }
        public List<bool> IsReserved { get; set; }
        public List<string> Times { get; set; }

        // Add a constructor that takes the necessary parameters
        public Court(string name, int monthDay, List<bool> isReserved, List<string> times)
        {
            Name = name;
            MonthDay = monthDay;
            IsReserved = isReserved;
            Times = times;
        }

        public static void DisplayAvailableCourts(List<Court> courts)
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

    }
}
