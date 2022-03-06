using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Produto
    {
        public string CodigoBarras { get; set; } = "7896617";
        public string Nome { get; set; }
        public string ValorVenda { get; set; }
        public DateTime UltimaVenda { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public Situacao Situacao { get; set; } = Situacao.Ativo;

        public Produto()
        {
        }


        public Produto(string cbarras, string nome, string vvenda)
        {
            this.CodigoBarras += cbarras.PadLeft(5,'0');
            this.Nome = nome;
            this.ValorVenda = vvenda;
        }

        public Produto(string cbarras, string nome, string vvenda, DateTime uvenda, DateTime dcadastro, Situacao situacao)
        {
            this.CodigoBarras = cbarras;
            this.Nome = nome;
            this.ValorVenda = vvenda;
            this.UltimaVenda = uvenda;
            this.DataCadastro = dcadastro;
            this.Situacao = situacao;
        }
        public string ExibirProd()
        {
            return $"Cod. Barra: {CodigoBarras}" +
                   $"\nNome: {Nome}" +
                   $"\nValor Unitário: {ValorVenda}";
        }

        public string ConverterParaEDI()
        {
            return $"{CodigoBarras}{Nome.PadRight(20)}{ValorVenda.PadLeft(5,'0')}{UltimaVenda.ToString("dd/MM/yyyy")}{DataCadastro.ToString("dd/MM/yyyy")}{(char)Situacao}";
        }
    }
}