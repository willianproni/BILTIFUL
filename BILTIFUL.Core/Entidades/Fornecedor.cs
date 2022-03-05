using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Fornecedor
    {
        public long cnpj { get; set; }
        public string rsocial { get; set; }
        public DateTime dabertura { get; set; }
        public DateTime ucompra { get; set; }
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; }

        public Fornecedor()
        {

        }
        
    }
}
