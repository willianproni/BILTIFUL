using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Produto
    {
        public string cbarras { get; set; } = "7896617";
        public string nome { get; set; }
        public int vvenda { get; set; }
        public DateTime uvenda { get; set; } = DateTime.Now;
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; } = Situacao.Ativo;

        public Produto()
        {
        }

        public Produto(string cbarras, string nome, int vvenda)
        {
            this.cbarras += cbarras.PadLeft(5,'0');
            this.nome = nome;
            this.vvenda = vvenda;
        }
    }
}
