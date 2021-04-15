using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Models
{
    public class Rental
    {
        public int ID { get; set; }
        public Client Client { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Pick_Up_Dealer_ID { get; set; }
        public int Dropp_Off_Dealer_ID { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
