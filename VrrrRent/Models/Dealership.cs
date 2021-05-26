using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Models
{
    public class Dealership
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public ICollection<Inventory> Inventory { get; set; }

    }
}
