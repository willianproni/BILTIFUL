using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    internal class ItemProducao : EntidadeBase
    {
        public DateTime dproducao { get; set; } = DateTime.Now;
        //ID Materia Prima
        public int mprima { get; set; }
        public int qtdmp { get; set; }
    }
}
