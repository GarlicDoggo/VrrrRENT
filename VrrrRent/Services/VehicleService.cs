using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;

namespace VrrrRent.Services
{
    public class VehicleService : BaseService
    {
        public VehicleService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Vehicle> GetVehicles()
        {
            return repositoryWrapper.VehicleRepository.FindAll().ToList();
        }

        public List<Vehicle> GetVehiclesByCondition(Expression<Func<Vehicle, bool>> expression)
        {
            return repositoryWrapper.VehicleRepository.FindByCondition(expression).ToList();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            repositoryWrapper.VehicleRepository.Create(vehicle);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            repositoryWrapper.VehicleRepository.Update(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            repositoryWrapper.VehicleRepository.Delete(vehicle);
        }
    }
}
