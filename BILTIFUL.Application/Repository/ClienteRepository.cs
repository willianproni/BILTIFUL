using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class ClienteRepository : RepositoryDAT<Cliente>
    {
        public ClienteRepository()
        {
            Path = "Cliente.dat";
        }
    }
}
