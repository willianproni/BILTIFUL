using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Producao : EntidadeBase
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID produto
        public string Produto { get; set; }
        public string Quantidade { get; set; }

        public Producao()
        {
        }

        public Producao(string id, string produto, string quantidade)
        {
            Id = id.PadLeft(5, '0');
            Produto = produto;
            Quantidade = quantidade;
        }

        public Producao(string produto, string quantidade)
        {
            Produto = produto;
            Quantidade = quantidade.PadLeft(5, '0');
        }

        public Producao(string id,DateTime dataProducao, string produto, string quantidade)
        {
            Id = id;
            DataProducao = dataProducao;
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
            return $"{Id.PadLeft(5, '0')}{DataProducao.ToString("dd/MM/yyyy")}{Produto}{Quantidade}";
        }

    }
}
