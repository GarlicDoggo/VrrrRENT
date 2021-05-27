using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long Phone { get; set; }
        public bool BListStatus { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<Rental> Rental { get; set; }

    }
}
