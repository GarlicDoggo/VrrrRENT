using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VrrrRent.Abstractions;
using VrrrRent.Models;
using VrrrRent.Repositories;

namespace VrrrRent.Services
{
    public class ClientService : BaseService
    {
        public ClientService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Client> GetClients()
        {
            return repositoryWrapper.ClientRepository.FindAll().ToList();
        }

        public List<Client> GetClientsByCondition(Expression<Func<Client, bool>> expression)
        {
            return repositoryWrapper.ClientRepository.FindByCondition(expression).ToList();
        }

        public void AddClient(Client client)
        {
            repositoryWrapper.ClientRepository.Create(client);
        }

        public void UpdateClient(Client client)
        {
            repositoryWrapper.ClientRepository.Update(client);
        }

        public void DeleteClient(Client client)
        {
            repositoryWrapper.ClientRepository.Delete(client);
        }
    }
}
