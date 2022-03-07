using BILTIFUL.Core.Entidades.Enums;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Cliente
    {

        public long CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime UltimaCompra { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public Situacao Situacao { get; set; } = Situacao.Ativo;

        public Cliente()
        {
        }

        public Cliente(long cpf, string nome, DateTime dnascimento, Sexo sexo)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.DataNascimento = dnascimento;
            this.Sexo = sexo;
            this.Situacao = Situacao;
        }

        public Cliente(long cpf, string nome, DateTime dnascimento, Sexo sexo, DateTime ucompra, DateTime dcadastro, Situacao situacao)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.DataNascimento = dnascimento;
            this.Sexo = sexo;
            this.UltimaCompra = ucompra;
            this.DataCadastro = dcadastro;
            this.Situacao = situacao;
        }

        public string ConverterParaEDI()
        {
            return $"{CPF}{Nome.PadRight(50,' ')}{DataNascimento.ToString("dd/MM/yyyy")}{(char)Sexo}{UltimaCompra.ToString("dd/MM/yyyy")}{DataCadastro.ToString("dd/MM/yyyy")}{(char)Situacao}";
        }
        public string DadosCliente()
        {
            return "-------------------------------------------\n|Nome: " + Nome+ "\n|CPF: " + CPF+ "\n|Data de nascimento: " + DataNascimento.ToString("dd/MM/yyyy") + "\n|Sexo: " + (char)Sexo+ "\n|Ultima compra: " + UltimaCompra.ToString("dd/MM/yyyy") + "\n|Data de cadastro: " + DataCadastro.ToString("dd/MM/yyyy") + "\n|Situação: " + Situacao;
        }
    }

}
