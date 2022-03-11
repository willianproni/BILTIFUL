using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Producao : EntidadeBase, IEntidadeDAT<Producao>
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID produto
        //public string Produto { get; set; }
        public int Quantidade { get; set; }
        public int Produto { get; set; }

        public Producao()
        {
        }


        public string Dados()
        {
            return @$"
            Data: {DataProducao.ToString("dd/MM/yyyy")}
            Quantidade do Produto: {Quantidade}";
        }


        public string ConverterParaDAT()
        {
            return $"{Id.ToString().PadLeft(5, '0')}{DataProducao.ToString("dd/MM/yyyy")}{Produto}{Quantidade}";
        }
        public string DadosProducao()
        {
            return $"-------------------------------------------\nId: {Id}\nData produção: {DataProducao}\n-------------------------------------------";
        }

        public Producao ExtrairDAT(string line)
        {
            if (line == null) return null;

            Id = int.Parse(line.Substring(0, 5));
            DataProducao= DateTime.Parse(line.Substring(5, 10));
            Produto = int.Parse(line.Substring(15, 12));
            Quantidade= int.Parse(line.Substring(27, 5));

            return this;
        }
    }
}
