using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Compra : EntidadeBase
    {
        public DateTime DataCompra { get; set; }
        //CNPJ
        public long Fornecedor { get; set; }
        public int ValorTotal { get; set; }
        public Compra()
        {

        }

        public string ConverterParaEDI()
        {
            return $"{Id}{DataCompra.ToString("dd/MM/yyyy")}{Fornecedor}{ValorTotal}";
        }
    }
}
