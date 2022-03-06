using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Producao : EntidadeBase
    {
        public DateTime dproducao { get; set; } = DateTime.Now;
        //ID produto
        public string produto { get; set; }
        public DateTime dproduto { get; set; }
        public int qtd { get; set; }

        public Producao()
        {

        }
    }
}
