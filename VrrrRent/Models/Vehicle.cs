using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public char Class { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; }
        public bool Available { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
        public ICollection<Rental> Rental { get; set; }
    }
}
