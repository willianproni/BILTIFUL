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


    }
}
