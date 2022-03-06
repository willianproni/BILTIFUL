using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Produto
    {
        public string cbarras { get; set; } = "7896617";
        public string nome { get; set; }
        public string vvenda { get; set; }
        public DateTime uvenda { get; set; } = DateTime.Now;
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; } = Situacao.Ativo;

        public Produto()
        {
        }

        public Produto(string cbarras, string nome, string vvenda)
        {
            this.cbarras += cbarras.PadLeft(5,'0');
            this.nome = nome;
            this.vvenda = vvenda;
        }

        public Produto(string cbarras, string nome, string vvenda, DateTime uvenda, DateTime dcadastro, Situacao situacao)
        {
            this.cbarras = cbarras;
            this.nome = nome;
            this.vvenda = vvenda;
            this.uvenda = uvenda;
            this.dcadastro = dcadastro;
            this.situacao = situacao;
        }

        public string ConverterParaEDI()
        {
            return $"{cbarras}{nome.PadRight(20,' ')}{vvenda.PadLeft(5,'0')}{uvenda.ToString("dd/MM/yyyy")}{dcadastro.ToString("dd/MM/yyyy")}{(char)situacao}";
        }
    }
}
