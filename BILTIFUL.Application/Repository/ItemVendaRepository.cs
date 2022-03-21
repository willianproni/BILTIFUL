using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class ItemVendaRepository : RepositoryIdDAT<ItemVenda>
    {
        public ItemVendaRepository()
        {
            Path = "Venda.dat";
        }
    }
}
