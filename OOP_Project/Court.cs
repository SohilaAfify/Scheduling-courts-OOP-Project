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
    }
}
