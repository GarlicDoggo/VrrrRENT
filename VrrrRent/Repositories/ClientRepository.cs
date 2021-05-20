using VrrrRent.Abstractions;
using VrrrRent.Models;

namespace VrrrRent.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(VrrrRentContext vrrrRentContext)
            : base(vrrrRentContext)
        {
        }
    }
}
