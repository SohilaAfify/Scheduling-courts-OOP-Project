using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    public class Day
    {

        public int MonthDay { get; set; }
        public List<bool> IsReserved { get; set; }
        public List<string> Times { get; set; }

        public Day() { }
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
    }
}
