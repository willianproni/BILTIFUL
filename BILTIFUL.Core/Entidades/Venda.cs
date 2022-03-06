using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Venda : EntidadeBase
    {
        public DateTime DataVenda { get; set; }
        //CPF
        public long Cliente { get; set; }
        public int ValorTotal { get; set; }
        public Venda()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
