using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VrrrRent.Abstractions
{
    public interface IRepositoryWrapper
    {
        IClientRepository ClientRepository { get; }
        IDealershipRepository DealershipRepository { get; }
        IRentalRepository RentalRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        void Save();
    }
}
