using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class ItemProducaoRepository : RepositoryIdDAT<ItemProducao>
    {
        public ItemProducaoRepository()
        {
            Path = "ItemProducao.dat";
        }
    }
}
