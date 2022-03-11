using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class VendaRepository : RepositoryIdDAT<Venda>
    {
        public VendaRepository()
        {
            Path = "Venda.dat";
        }
    }
}
