using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public Vehicle Vehicle { get; set; }
        public Dealership Dealership { get; set; }
    }
}
