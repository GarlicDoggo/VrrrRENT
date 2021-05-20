using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;

namespace VrrrRent.Repositories
{
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(VrrrRentContext vrrrRentContext)
            : base(vrrrRentContext)
        {
        }
    }
}
