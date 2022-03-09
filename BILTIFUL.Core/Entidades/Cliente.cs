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

        public Cliente(long cpf, string nome)
        {
            CPF = cpf;
            Nome = nome;
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
            return $"{CPF.ToString().PadLeft(11, '0')}{Nome.PadRight(50).Substring(0, 50)}{DataNascimento.ToString("dd/MM/yyyy")}{(char)Sexo}{UltimaCompra.ToString("dd/MM/yyyy")}{DataCadastro.ToString("dd/MM/yyyy")}{(char)Situacao}";
        }
        public string DadosCliente()
        {
            return "-------------------------------------------\n|Nome: " + Nome + "\n|CPF: " + CPF + "\n|Data de nascimento: " + DataNascimento.ToString("dd/MM/yyyy") + "\n|Sexo: " + Sexo + "\n|Ultima compra: " + UltimaCompra.ToString("dd/MM/yyyy") + "\n|Data de cadastro: " + DataCadastro.ToString("dd/MM/yyyy") + "\n|Situação: " + Situacao;
        }

        public string VendasCliente()
        {
            return $"\n\t\t\t\t\t-------------- Informações --------------" +
                    $"\n\t\t\t\t\tCpf: {CPF.ToString().PadLeft(11, '0')}" +
                    $"\n\t\t\t\t\tNome: {Nome}" +
                    $"\n\t\t\t\t\tData Ultima Compra: {UltimaCompra.ToString("dd/MM/yyyy")}" +
                    $"\n\t\t\t\t\t-----------------------------------------";
        }
    }

}
