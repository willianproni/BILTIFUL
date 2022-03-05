using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Compra : EntidadeBase
    {
        public DateTime dcompra { get; set; }
        //CNPJ
        public long fornecedor { get; set; }
        public int vtotal { get; set; }
        public Compra()
        {

        }
    }
}
