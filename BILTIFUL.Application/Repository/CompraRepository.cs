using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class CompraRepository : RepositoryIdDAT<Compra>
    {
        public CompraRepository()
        {
            Path = "Compra.dat";
        }
    }
}
