using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Produto
    {
        public int cbarras { get; set; }
        public string nome { get; set; }
        public int vvenda { get; set; }
        public DateTime uvenda { get; set; } = DateTime.Now;
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; } = Situacao.Ativo;

        public Produto()
        {
        }

        public Produto(int cbarras, string nome, int vvenda)
        {
            this.cbarras = cbarras;
            this.nome = nome;
            this.vvenda = vvenda;
        }
    }
}
