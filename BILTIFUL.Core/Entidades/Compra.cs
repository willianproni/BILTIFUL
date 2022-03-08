using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Compra : EntidadeBase
    {
        public DateTime DataCompra { get; set; } = DateTime.Now;
        //CNPJ
        public long Fornecedor { get; set; }
        public string ValorTotal { get; set; }
        public Compra()
        {

        }

        public Compra( string id , long fornecedor, string valorTotal)//criação
        {
            Id = id.PadLeft(5,'0');
            Fornecedor = fornecedor;
            ValorTotal = valorTotal.PadLeft(7,'0');
        }

        public Compra(string id,DateTime dataCompra, long fornecedor, string valorTotal)//leitura
        {
            Id = id;
            DataCompra = dataCompra;
            Fornecedor = fornecedor;
            ValorTotal = valorTotal;
        }

        public string ConverterParaEDI()
        {
            return $"{Id}{DataCompra.ToString("dd/MM/yyyy")}{Fornecedor}{ValorTotal}";
        }
        public string DadosCompra()
        {
            return "-------------------------------------------\nId: " + Id + "\nData de compra: " + DataCompra.ToString("dd/MM/yyyy") + "\nFornecedor: " + Fornecedor + "\nValor da compra: "  +float.Parse(ValorTotal.Insert(5, ","));
        }
    }
}
