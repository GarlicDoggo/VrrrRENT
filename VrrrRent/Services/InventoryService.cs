using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;

namespace VrrrRent.Services
{
    public class InventoryService : BaseService
    {
        public InventoryService(IRepositoryWrapper RepositoryWrapper) : base(RepositoryWrapper)
        {

        }

        public List<Inventory> GetInventories()
        {
            return repositoryWrapper.InventoryRepository.FindAll().ToList();
        }

        public List<Inventory> GetInventoryByCondition(Expression<Func<Inventory, bool>> expression)
        {
            return repositoryWrapper.InventoryRepository.FindByCondition(expression).ToList();
        }

        public void AddInventory(Inventory inventory)
        {
            repositoryWrapper.InventoryRepository.Create(inventory);
        }

        public void UpdateInventory(Inventory inventory)
        {
            repositoryWrapper.InventoryRepository.Update(inventory);
        }

        public void DeleteInventory(Inventory inventory)
        {
            repositoryWrapper.InventoryRepository.Delete(inventory);
        }

    }
}
