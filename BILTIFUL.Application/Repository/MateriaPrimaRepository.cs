using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Application.Repository
{
    public class MateriaPrimaRepository : RepositoryIdDAT<MPrima>
    {
        public MateriaPrimaRepository()
        {
            Path = "Materia.dat";
        }
    }
}
