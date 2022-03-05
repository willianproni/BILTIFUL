using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    internal class ItemCompra : EntidadeBase
    {
        public DateTime dcompra { get; set; }
        //ID materia prima
        public int mprima { get; set; }
        public int qtd { get; set; }
        public int vunitario { get; set; }
        public int titem => qtd * vunitario;
    }
}
