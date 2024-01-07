using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Sport
    {
        public string Name { get; set; }
        public List<Court> Courts { get; set; }

        public Sport(string name)
        {
            Name = name;
            Courts = new List<Court>();
        }

        public void AddCourt(Court court)
        {
            Courts.Add(court);
        }

        public void DisplayCourts()
        {
            for (int i = 0; i < Courts.Count; i++)
            {
                Console.WriteLine($"Court #{i + 1}: {Courts[i].Name}, Available: {Courts[i].MonthDay} - {string.Join(", ", Courts[i].Times)}");
            }
        }
        public void RemoveCourt(int courtIndex)
        {
            if (courtIndex >= 0 && courtIndex < Courts.Count)
            {
                Courts.RemoveAt(courtIndex);
            }
            else
            {
                Console.WriteLine("Invalid court index!");
            }
        }

    }
}