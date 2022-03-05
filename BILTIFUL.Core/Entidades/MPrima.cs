using BILTIFUL.Core.Entidades.Base;
using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class MPrima : EntidadeBase
    {
        public string nome { get; set; }
        public DateTime ucompra { get; set; }
        public DateTime dcadastro { get; set; }
        public Situacao situacao { get; set; }

        public MPrima()
        {

        }
    }
}
