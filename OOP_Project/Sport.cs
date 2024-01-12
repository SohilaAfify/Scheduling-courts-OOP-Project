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

        public void AddCourt(Court court)
        {
            Courts.Add(court);
        }

       

    }
}