using BILTIFUL.Application.Repository.Base;
using BILTIFUL.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
