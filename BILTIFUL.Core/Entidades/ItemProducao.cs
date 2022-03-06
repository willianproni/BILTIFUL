using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemProducao : EntidadeBase
    {
        public DateTime dproducao { get; set; } = DateTime.Now;
        //ID Materia Prima
        public string mprima { get; set; }
        public int qtdmp { get; set; }

        public ItemProducao()
        {

        }
    }
}
