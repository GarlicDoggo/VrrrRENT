using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;

namespace VrrrRent.Services
{
    public class RentalService : BaseService
    {
        public RentalService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Rental> GetRentals()
        {
            return repositoryWrapper.RentalRepository.FindAll().ToList();
        }

        public List<Rental> GetRentalsByCondition(Expression<Func<Rental, bool>> expression)
        {
            return repositoryWrapper.RentalRepository.FindByCondition(expression).ToList();
        }

        public void AddRental(Rental rental)
        {
            repositoryWrapper.RentalRepository.Create(rental);
        }

        public void UpdateRental(Rental rental)
        {
            repositoryWrapper.RentalRepository.Update(rental);
        }

        public void DeleteRental(Rental rental)
        {
            repositoryWrapper.RentalRepository.Delete(rental);
        }
    }
}
