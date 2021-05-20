using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VrrrRent.Models;

namespace VrrrRent.Models
{
    public class VrrrRentContext : IdentityDbContext<IdentityUser>
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
