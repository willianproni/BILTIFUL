using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class ProducaoRepository : RepositoryIdDAT<Producao>
    {
        public ProducaoRepository()
        {
            Path = "Producao.dat";
        }

    }
}
