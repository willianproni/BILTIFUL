using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Bloqueado : IEntidadeDAT<Bloqueado>
    {
        public string CNPJ { get; set; }

        public string ConverterParaDAT()
        {
            return $"{CNPJ}";
        }

        public string Dados()
        {
            throw new NotImplementedException();
        }

        public Bloqueado ExtrairDAT(string line)
        {
            CNPJ = line;
            return line != null ? this : null;
        }
    }
}
