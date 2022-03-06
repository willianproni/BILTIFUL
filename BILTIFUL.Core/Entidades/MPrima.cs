using BILTIFUL.Core.Entidades.Base;
using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class MPrima : EntidadeBase
    {
        public string nome { get; set; }
        public DateTime ucompra { get; set; } = DateTime.Now;
        public DateTime dcadastro { get; set; } = DateTime.Now;
        public Situacao situacao { get; set; } = Situacao.Ativo;

        public MPrima()
        {
        }

        public MPrima(string idcod,string nome)
        {
            id = "MP" + idcod.PadLeft(4, '0');
            this.nome = nome;
        }

        public MPrima(string id,string nome, DateTime ucompra, DateTime dcadastro, Situacao situacao)
        {
            this.id = id; 
            this.nome = nome;
            this.ucompra = ucompra;
            this.dcadastro = dcadastro;
            this.situacao = situacao;
        }

        public string ConverterParaEDI()
        {
            return $"{id}{nome.PadRight(20)}{ucompra.ToString("dd/MM/yyyy")}{dcadastro.ToString("dd/MM/yyyy")}{(char)situacao}";
        }
    }
}
