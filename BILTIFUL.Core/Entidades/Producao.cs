using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Producao : EntidadeBase
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID produto
        public string Produto { get; set; }
        public int Quantidade { get; set; }

        public Producao()
        {
        }

        public Producao(string id, string produto, int quantidade)
        {
            Id = id.PadLeft(5, '0');
            Produto = produto;
            Quantidade = quantidade;
        }

        public Producao(string produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public string Dados()
        {
            return @$"
    Data: {DataProducao.ToString("dd/MM/yyyy")}
    Quantidade do Produto: {Quantidade}";
        }


        public string ConverterParaEDI()
        {
            return $"{Id}{DataProducao.ToString("dd/MM/yyyy")}{Produto}{Quantidade.ToString().PadLeft(5, '0')}";
        }

    }
}
