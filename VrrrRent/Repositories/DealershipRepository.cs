using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Data;
using VrrrRent.Models;

namespace VrrrRent.Repositories
{
    public class DealershipRepository : RepositoryBase<Dealership>, IDealershipRepository
    {
        public DealershipRepository(VrrrRentContext vrrrRentContext)
            : base(vrrrRentContext)
        {
        }
    }
}
