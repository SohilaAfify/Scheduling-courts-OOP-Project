using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Project
{
    internal class Courts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<String> courtList { get; set; }

        public Courts(int Id, String Name, double Price, List<String> courtList) 
        { 
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.courtList = courtList;
        }


    }
}
