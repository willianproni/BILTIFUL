using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    internal class Producao : EntidadeBase
    {
        public DateTime dproducao { get; set; } = DateTime.Now;
        //ID produto
        public int produto { get; set; }
        public DateTime dproduto { get; set; }
        public int qtd { get; set; }
    }
}
