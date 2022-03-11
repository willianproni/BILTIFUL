using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class ProdutoRepository : RepositoryIdDAT<Produto>
    {
        public ProdutoRepository()
        {
            Path = "Cosmetico.dat";
        }
    }
}
