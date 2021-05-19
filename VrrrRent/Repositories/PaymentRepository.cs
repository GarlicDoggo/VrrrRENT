using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Data;
using VrrrRent.Models;

namespace VrrrRent.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(VrrrRentContext vrrrRentContext)
            : base(vrrrRentContext)
        {
        }
    }
}
