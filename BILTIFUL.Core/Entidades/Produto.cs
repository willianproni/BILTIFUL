using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    internal class Produto
    {
        public int cbarras { get; set; }
        public string nome { get; set; }
        public int vvenda { get; set; }
        public DateTime uvenda { get; set; }
        public DateTime dcadastro { get; set; }
        public Situacao situacao { get; set; }

        public Produto()
        {
              
        }
    }
}
