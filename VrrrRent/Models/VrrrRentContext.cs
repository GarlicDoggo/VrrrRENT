using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VrrrRent.Models;

namespace VrrrRent.Data
{
    public class VrrrRentContext :DbContext
    {
        public VrrrRentContext (DbContextOptions<VrrrRentContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Dealership> Dealership { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
    }
}
