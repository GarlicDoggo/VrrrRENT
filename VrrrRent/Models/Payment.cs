using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public Rental Rental { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }
    }
}
