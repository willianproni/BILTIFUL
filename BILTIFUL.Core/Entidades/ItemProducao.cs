using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemProducao : EntidadeBase
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID Materia Prima
        public string MateriaPrima { get; set; }
        public int QuantidadeMateriaPrima { get; set; }

        public ItemProducao()
        {

        }

    }
}
