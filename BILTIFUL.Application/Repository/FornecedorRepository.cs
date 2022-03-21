using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class FornecedorRepository : RepositoryDAT<Fornecedor>
    {
        public FornecedorRepository()
        {
            Path = "Fornecedor.dat";
        }
    }
}
