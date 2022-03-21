using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class ItemCompraRepository : RepositoryIdDAT<ItemCompra>
    {
        public ItemCompraRepository()
        {
            Path = "ItemCompra.dat";
        }
    }
}
