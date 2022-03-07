using System;
using System.Collections;
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
        public CadastroService()
        {
        }

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
                        CadastroCliente();
                        break;
                    case "2":
                        CadastroProduto();
                        break;
                    case "3":
                        CadastroFornecedor();
                        break;
                    case "4":
                        CadastroMateriaPrima();
                        break;
                    case "5":
                        CadastroInadimplente();
                        break;
                    case "6":
                        CadastroBloqueado();
                        break;
                    case "7":
                        RemoverInadimplencia();
                        break;
                    case "8":
                        RemoverBloqueio();
                        break;
                    case "9":
                        MostrarRegistro();
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
            Console.WriteLine("\t|6| - ADICIONAR FORNECEDOR A LISTA DE BLOQUEADO|");
            Console.WriteLine("\t|7| - REMOVER CLIENTE DA LISTA DE INADIMPLENTE |");
            Console.WriteLine("\t|8| - REMOVER FORNECEDOR DA LISTA DE BLOQUEADO |");
            Console.WriteLine("\t|9| - MOSTRAR REGISTROS                        |");
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
            string nome;
            Console.Clear();
            Console.WriteLine("===========CADASTRO CLIENTE===========");
            do
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine().Trim().Replace(".", "").Replace("-", "");//tira o ponto e o traço caso digitado
                if (!ValidaCpf(cpf))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCpf(cpf));//enquanto cpf nao for valido digitar denovo
            if (cadastros.clientes.Find(p => p.CPF == long.Parse(cpf)) != null)
            {
                Console.WriteLine("Cliente com esse CPF ja existe");
                return null;
            }
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine().Trim();
                if (nome == "")
                    Console.WriteLine("Nome nao pode ser vazio");
            } while (nome == "");
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

            Cliente cliente = new Cliente(long.Parse(cpf), nome, dnascimento, sexo);

            new Controle(cliente);
            cadastros.clientes.Add(cliente);

            return cliente;
        }
        public static bool ValidaCpf(string cpf)
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
            string rsocial;
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
            if (cadastros.fornecedores.Find(p => p.CNPJ == long.Parse(cnpj)) != null)
            {
                Console.WriteLine("Cliente com esse CPF ja existe");
                return null;
            }
            do
            {
                Console.Write("Razão Social: ");
                rsocial = Console.ReadLine().Trim();
            } while (rsocial == "");
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


            Fornecedor fornecedor = new Fornecedor(long.Parse(cnpj), rsocial, dabertura);

            new Controle(fornecedor);
            cadastros.fornecedores.Add(fornecedor);

            return fornecedor;
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
            string nome;
            Console.Clear();
            Console.WriteLine("===========CADASTRO PRODUTO===========");
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine().Trim();
            } while (nome=="");
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

            Produto produto = new Produto(cod, nome, svalor);
            new Controle(produto);
            cadastros.produtos.Add(produto);
            return produto;
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
        public MPrima CadastroMateriaPrima()
        {
            string nome;
            Console.Clear();
            Console.WriteLine("===========CADASTRO MATERIA PRIMA===========");
            do {
                Console.WriteLine("Digite o nome da Materia Prima");
                nome = Console.ReadLine().Trim();
            } while (nome == "");

            cadastros.codigos[1]++;
            SalvarCodigos();
            string cod = "" + cadastros.codigos[1];
            cadastros.materiasprimas.Add(new MPrima(cod, nome));

            MPrima mPrima = new MPrima(cod, nome);

            new Controle(mPrima);
            cadastros.materiasprimas.Add(mPrima);

            return mPrima;

        }
        public long CadastroInadimplente()
        {
            string inadimplente;
            Console.Clear();
            Console.WriteLine("===========CADASTRO DE INADIMPLENTE===========");
            do
            {
                Console.WriteLine("Digite o cpf do inadimplente: ");
                inadimplente = Console.ReadLine().Trim().Replace(".", "").Replace("-", ""); ;
                if (!ValidaCpf(inadimplente))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCpf(inadimplente));
            if (cadastros.inadimplentes.Find(p => p == "" + inadimplente) != null)
            {
                Console.WriteLine("Inadimplente com esse CPF ja existe");
                return 0;
            }
            long cpf = long.Parse(inadimplente);

            if (cadastros.clientes.Find(p => p.CPF == cpf) != null)
            {
                new Controle(cpf);
                cadastros.inadimplentes.Add("" + cpf);
                return cpf;
            }
            return 0;
        }
        public long CadastroBloqueado()
        {
            string bloqueado;
            Console.Clear();
            Console.WriteLine("===========CADASTRO DE BLOQUEADO===========");
            do
            {
                Console.WriteLine("Digite o CNPJ do fornecedor: ");
                bloqueado = Console.ReadLine().Trim().Replace(".", "").Replace("-", "").Replace("/", "");
                if (!ValidaCnpj(bloqueado))//valida cpf
                    Console.WriteLine("Cnpj invalido!\nDigite novamente");
            } while (!ValidaCnpj(bloqueado));
            if (cadastros.bloqueados.Find(p => p == bloqueado) != null)
            {
                Console.WriteLine("Fornecedor com esse cnpj ja existe");
                return 0;
            }

            long cnpj = long.Parse(bloqueado);

            if (cadastros.fornecedores.Find(p => p.CNPJ == cnpj) != null)
            {
                new Controle(cnpj);
                cadastros.bloqueados.Add("" + cnpj);
                return cnpj;
            }
            return 0;
        }

        public void RemoverInadimplencia()
        {
            string inadimplente;
            Console.Clear();
            Console.WriteLine("===========REMOVER DE INADIMPLENTE===========");
            do
            {
                Console.WriteLine("Digite o cpf do ex caloteiro: ");
                inadimplente = Console.ReadLine().Trim().Replace(".", "").Replace("-", "");
                if (!ValidaCpf(inadimplente))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCpf(inadimplente));

            long cpf = long.Parse(inadimplente);

            if (cadastros.inadimplentes.Find(p => p == "" + cpf) != null)
                Remover(cpf);
        }
        public void RemoverBloqueio()
        {
            string bloqueado;
            Console.Clear();
            Console.WriteLine("===========REMOVER DE BLOQUEADO===========");
            do
            {
                Console.WriteLine("Digite o cnpj do fornecedor bloqueado: ");
                bloqueado = Console.ReadLine().Trim().Replace(".", "").Replace("-", "").Replace("/", "");
                if (!ValidaCnpj(bloqueado))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCnpj(bloqueado));

            long cnpj = long.Parse(bloqueado);

            if (cadastros.bloqueados.Find(p => p == "" + cnpj) != null)
                Remover(cnpj);
        }
        public void Remover(long chave)
        {
            string schave = "" + chave;
            if (CadastroService.ValidaCpf(schave))
            {
                cadastros.inadimplentes.Remove(schave);
                try//envia cliente para arquivo como novo cliente]try
                {
                    int i = 0;
                    StreamWriter sw = new StreamWriter("Arquivos\\Risco.dat");
                    while (i != cadastros.inadimplentes.Count)
                    {
                        sw.WriteLine(cadastros.inadimplentes[i]);
                        i++;
                    }
                    sw.Close();
                    Console.WriteLine("Cliente removido dos inadimplentes!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            if (CadastroService.ValidaCnpj(schave))
            {
                cadastros.bloqueados.Remove(schave);
                try//envia cliente para arquivo como novo cliente]try
                {
                    int i = 0;
                    StreamWriter sw = new StreamWriter("Arquivos\\Bloqueado.dat");
                    while (i != cadastros.bloqueados.Count)
                    {
                        sw.WriteLine(cadastros.bloqueados[i]);
                        i++;
                    }
                    sw.Close();
                    Console.WriteLine("Fornecedor desbloqueado!!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
        }

        public void MostrarRegistro()
        {
            string opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\t________________________________________________");
                Console.WriteLine("\t|+++++++++++++| MENU DE REGISTROS |++++++++++++|");
                Console.WriteLine("\t|1| - REGISTROS DE CLIENTES                    |");
                Console.WriteLine("\t|2| - REGISTROS DE FORNECEDORES                |");
                Console.WriteLine("\t|3| - REGISTROS DE MATERIAS PRIMAS             |");
                Console.WriteLine("\t|4| - REGISTROS DE PRODUTOS                    |");
                Console.WriteLine("\t|5| - REGISTROS DE VENDAS                      |");
                Console.WriteLine("\t|6| - REGISTROS DE ITENS DE VENDAS             |");
                Console.WriteLine("\t|7| - REGISTROS DE COMPRAS                     |");
                Console.WriteLine("\t|8| - REGISTROS DE ITENS DE COMPRAS            |");
                Console.WriteLine("\t|0| - VOLTAR                                   |");
                    Console.Write("\t|______________________________________________|\n" +
                                  "\t|Opção: ");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        if(cadastros.clientes.Count()!=0)
                            new Registros(cadastros.clientes);
                        else
                            Console.WriteLine("Nenhum cliente registrado");
                        break;
                    case "2":
                        if (cadastros.fornecedores.Count() != 0)
                            new Registros(cadastros.fornecedores);
                        else
                            Console.WriteLine("Nenhum fornecedor registrado");
                        break;
                    case "3":
                        if (cadastros.materiasprimas.Count() != 0)
                            new Registros(cadastros.materiasprimas);
                        else
                            Console.WriteLine("Nenhuma materia prima registrada");
                        break;
                    case "4":
                        if (cadastros.produtos.Count() != 0)
                            new Registros(cadastros.produtos);
                        else
                            Console.WriteLine("Nenhum produto registrado");
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
                Console.ReadKey();
            } while (opc != "0");
        }
    }
}