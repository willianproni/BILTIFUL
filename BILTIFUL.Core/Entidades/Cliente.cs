using BILTIFUL.Core.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILTIFUL.Core.Entidades
{
    internal class Cliente
    {

        public long cpf { get; set; }
        public string nome { get; set; }
        public DateTime dnascimento { get; set; }
        public Sexo sexo { get; set; }
        public DateTime ucompra { get; set; }
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; }

        public Cliente()
        {
        }
    }

}
