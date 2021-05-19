using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Data;

namespace VrrrRent.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private VrrrRentContext _vrrrRentContext;
        private IClientRepository _clientRepository;
        private IRentalRepository _rentalRepository;
        private IVehicleRepository _vehicleRepository;
        private IDealershipRepository _dealershipRepository;
        private IInventoryRepository _inventoryRepository;
        private IPaymentRepository _paymentRepository;

        public IClientRepository ClientRepository
        {
            get
            {
                if(_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_vrrrRentContext);
                }
                return _clientRepository;
            }
        }

        public IDealershipRepository DealershipRepository
        {
            get
            {
                if (_dealershipRepository == null)
                {
                    _dealershipRepository = new DealershipRepository(_vrrrRentContext);
                }
                return _dealershipRepository;
            }
        }


        public IRentalRepository RentalRepository
        {
            get
            {
                if (_rentalRepository == null)
                {
                    _rentalRepository = new RentalRepository(_vrrrRentContext);
                }
                return _rentalRepository;
            }
        }


        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new PaymentRepository(_vrrrRentContext);
                }
                return _paymentRepository;
            }
        }

        public IInventoryRepository InventoryRepository
        {
            get
            {
                if (_inventoryRepository == null)
                {
                    _inventoryRepository = new InventoryRepository(_vrrrRentContext);
                }
                return _inventoryRepository;
            }
        }

        public IVehicleRepository VehicleRepository
        {
            get
            {
                if (_vehicleRepository == null)
                {
                    _vehicleRepository = new VehicleRepository(_vrrrRentContext);
                }
                return _vehicleRepository;
            }
        }

        public void Save()
        {
            _vrrrRentContext.SaveChanges();
        }
    }
}
