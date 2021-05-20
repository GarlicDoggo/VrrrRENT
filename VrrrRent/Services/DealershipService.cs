using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;

namespace VrrrRent.Services
{
    public class DealershipService : BaseService
    {
        public DealershipService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Dealership> GetDealerships()
        {
            return repositoryWrapper.DealershipRepository.FindAll().ToList();
        }

        public List<Dealership> GetDealershipsByCondition(Expression<Func<Dealership, bool>> expression)
        {
            return repositoryWrapper.DealershipRepository.FindByCondition(expression).ToList();
        }

        public void AddDealership(Dealership dealership)
        {
            repositoryWrapper.DealershipRepository.Create(dealership);
        }

        public void UpdateDealership(Dealership dealership)
        {
            repositoryWrapper.DealershipRepository.Update(dealership);
        }

        public void DeleteDealership(Dealership dealership)
        {
            repositoryWrapper.DealershipRepository.Delete(dealership);
        }
    }
}
