using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Fornecedor
    {
        public long cnpj { get; set; }
        public string rsocial { get; set; }
        public DateTime dabertura { get; set; }
        public DateTime ucompra { get; set; } = DateTime.Now;
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; } = Situacao.Ativo;

        public Fornecedor()
        {
        }

        public Fornecedor(long cnpj, string rsocial, DateTime dabertura)
        {
            this.cnpj = cnpj;
            this.rsocial = rsocial;
            this.dabertura = dabertura;
        }
        public Fornecedor(long cnpj, string rsocial)
        {
            this.cnpj = cnpj;
            this.rsocial = rsocial;
            
        }

        public override string ToString()
        {
            return "Fornecedor:\t" + rsocial + "\nCnpj:\t" + cnpj;
        }

        public Fornecedor(long cnpj, string rsocial, DateTime dabertura, DateTime ucompra, DateTime dcadastro, Situacao situacao)
        {

            this.cnpj = cnpj;
            this.rsocial = rsocial;
            this.dabertura = dabertura;
            this.ucompra = ucompra;
            this.dcadastro = dcadastro;
            this.situacao = situacao;
        }

        public string ConverterParaEDI()
        {
            return $"{cnpj}{rsocial.PadRight(50, ' ')}{dabertura.ToString("dd/MM/yyyy")}{ucompra.ToString("dd/MM/yyyy")}{dcadastro.ToString("dd/MM/yyyy")}{(char)situacao}";
        }
    }
}
