using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemCompra : EntidadeBase
    {
        public DateTime DataCompra { get; set; }
        //ID materia prima
        public int MateriaPrima { get; set; }
        public int Quantidade { get; set; }
        public int ValorUnitario { get; set; }
        public int TotalItem => Quantidade * ValorUnitario;

        public ItemCompra()
        {

        }
    }
}
