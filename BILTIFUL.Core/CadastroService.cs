using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL;
using BILTIFUL.Core.Controles;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;

namespace BILTIFUL.Core
{
    public class CadastroService
    {

        public Controle cadastros = new Controle();
        public void SubMenu()
        {
            string opc;
            do
            {
                opc = Menu();
                switch (opc)
                {
                    case "1":
                        Controle cliente = new Controle(CadastroCliente());
                        break;
                    case "2":
                        Controle produto = new Controle(CadastroProduto());
                        cadastros.codigos.ForEach(p => Console.WriteLine(p));

                        break;
                    case "3":
                        Controle fornecedor = new Controle(CadastroFornecedor());
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opção invalida!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (opc != "0");
        }
        private string Menu()
        {
            string opc;
            Console.WriteLine("\t________________________________________________");
            Console.WriteLine("\t|+++++++++++++++++++| MENU |+++++++++++++++++++|");
            Console.WriteLine("\t|1| - CADASTRAR CLIENTE                        |");
            Console.WriteLine("\t|2| - CADASTRAR PRODUTO                        |");
            Console.WriteLine("\t|3| - CADASTRAR FORNECEDOR                     |");
            Console.WriteLine("\t|4| - CADASTRAR MATERIA PRIMA                  |");
            Console.WriteLine("\t|5| - ADICIONAR CLIENTE COMO INADIMPLENTE      |");
            Console.WriteLine("\t|6| - ADICIOANR FORNECEDOR A LISTA DE BLOQUEADO|");
            Console.WriteLine("\t|7| - REMOVER CLIENTE DA LISTA DE INADIMPLENTE |");
            Console.WriteLine("\t|8| - REMOVER FORNECEDOR DA LISTA DE BLOQUEADO |");
            Console.WriteLine("\t|0| - VOLTAR PARA O MENU PRINCIPAL             |");
            Console.Write("\t|______________________________________________|\n" +
                          "\t|Opção: ");
            opc = Console.ReadLine();
            return opc;
        }
        public Cliente CadastroCliente()
        {
            string cpf;
            string datanascimento;
            string csexo;
            DateTime dnascimento;
            Console.Clear();
            Console.WriteLine("===========CADASTRO CLIENTE===========");
            do
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine().Trim().Replace(".", "").Replace("-", "");//tira o ponto e o traço caso digitado
                if (!ValidaCpf(cpf))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCpf(cpf));//enquanto cpf nao for valido digitar denovo

            Console.Write("Nome: ");
            string nome = Console.ReadLine().Trim();
            do
            {
                Console.Write("Data de nascimento(dd/mm/aaaa): ");
                datanascimento = Console.ReadLine();
                if (!DateTime.TryParse(datanascimento, out dnascimento))
                    Console.WriteLine("Data invalida!");
            } while (!DateTime.TryParse(datanascimento, out dnascimento));
            if ((DateTime.Now - dnascimento).Days / 365 < 18)
            {
                Console.WriteLine("Deve ter pelomenos 18 anos para ser cliente!");
                return null;
            }
            do
            {
                Console.Write("Sexo(M-Masculino e F-Feminino): ");
                csexo = Console.ReadLine().ToUpper();
            } while ((csexo != "M") && (csexo != "F"));
            Sexo sexo = (Sexo)char.Parse(csexo);
            return new Cliente(long.Parse(cpf), nome, dnascimento, sexo);
        }
        public bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public Fornecedor CadastroFornecedor()
        {
            string dataabertura;
            DateTime dabertura;
            string cnpj;
            Console.Clear();
            Console.WriteLine("===========CADASTRO FORNECEDOR===========");
            do
            {
                Console.Write("CNPJ: ");
                cnpj = Console.ReadLine().Trim().Replace(".", "").Replace("-", "").Replace("/", "");//tira o ponto e o traço caso digitado
                if (!ValidaCnpj(cnpj))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");

            } while (!ValidaCnpj(cnpj));//enquanto cpf nao for valido digitar denovo

            Console.Write("Razão Social: ");
            string rsocial = Console.ReadLine().Trim();

            do
            {
                Console.Write("Data de abertura(dd/mm/aaaa): ");
                dataabertura = Console.ReadLine();
                if (!DateTime.TryParse(dataabertura, out dabertura))
                    Console.WriteLine("Data invalida!");
            } while (!DateTime.TryParse(dataabertura, out dabertura));
            if ((DateTime.Now - dabertura).Days < 180)
            {
                Console.WriteLine("Deve ter se passado pelo menos 6 meses desde a abertura!");
                return null;
            }
            return new Fornecedor(long.Parse(cnpj), rsocial, dabertura);
        }
        public static bool ValidaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }
        public Produto CadastroProduto()
        {
            string svalor;
            int valor;
            Console.Clear();
            Console.WriteLine("===========CADASTRO PRODUTO===========");
            Console.Write("Nome: ");
            string nome = Console.ReadLine().Trim();
            do
            {
                Console.Write("Valor($$$,$$)(valor precisa ser menor que 1000,00): ");
                svalor = Console.ReadLine().Trim().Replace(".", "").Replace(",", "");
                if (!int.TryParse(svalor, out valor) || (valor > 99999) || (valor <= 0))
                    Console.WriteLine("Valor invalido!");
            } while (!int.TryParse(svalor, out valor) || (valor > 99999) || (valor <= 0));

            cadastros.codigos[0]++;
            SalvarCodigos();
            string cod = "" + cadastros.codigos[0];
            cadastros.produtos.Add(new Produto(cod, nome, svalor));
            return new Produto(cod, nome, svalor);
        }
        public void SalvarCodigos()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Arquivos\\Controle.dat");
                sw.WriteLine(cadastros.codigos[0]);
                sw.WriteLine(cadastros.codigos[1]);
                sw.Close();
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }
    }
}
