using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Data;
using VrrrRent.Models;

namespace VrrrRent.Repositories
{
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VrrrRentContext vrrrRentContext)
            : base(vrrrRentContext)
        {
        }
    }
}
