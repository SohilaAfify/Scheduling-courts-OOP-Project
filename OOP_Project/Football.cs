using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Football : Courts
    {
        public Football(int Id, string Name, double Price, List<string> courtList) 
          : base(Id, Name, Price, courtList)
        {
        }

        public void printCourtList(List<string> courtList)
        {
            foreach (string court in courtList)
            {
                Console.WriteLine(courtList);
            }
        }
    }
}
