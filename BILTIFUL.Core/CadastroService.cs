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

        public CadastroService()
        {
        }

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
                        CadastroBloqueado();
                        break;
                    case "9":
                        MostrarRegistro();
                        break;
                    case "10":
                        LocalizarRegistro();
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
            Console.WriteLine("\t|10| - LOCALIZAR REGISTROS                     |");
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

            Cliente cliente = new Cliente(long.Parse(cpf), nome, dnascimento, sexo);

            new Controle(cliente);

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


            Fornecedor fornecedor = new Fornecedor(long.Parse(cnpj), rsocial, dabertura);

            new Controle(fornecedor);

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
            Console.Clear();
            Console.WriteLine("===========CADASTRO PRODUTO===========");
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine().Trim();
            } while (nome == "");
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

            Produto produto = new Produto(cod, nome, svalor);
            new Controle(produto);
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
            Console.Clear();
            Console.WriteLine("===========CADASTRO MATERIA PRIMA===========");
            do
            {
                Console.WriteLine("Digite o nome da Materia Prima");
                nome = Console.ReadLine().Trim();
            } while (nome == "");

            cadastros.codigos[1]++;
            SalvarCodigos();
            string cod = "" + cadastros.codigos[1];

            MPrima mPrima = new MPrima(cod, nome);

            new Controle(mPrima);

            return mPrima;

        }
        public long CadastroInadimplente()
        {
            string inadimplente;
            Console.Clear();
            Console.WriteLine("===========CADASTRO DE INADIMPLENTE===========");
            do
            {
                Console.WriteLine("Digite o cpf do caloteiro: ");
                inadimplente = Console.ReadLine().Trim().Replace(".", "").Replace("-", ""); ;
                if (!ValidaCpf(inadimplente))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCpf(inadimplente));

            long cpf = long.Parse(inadimplente);

            if (cadastros.clientes.Find(p => p.CPF == cpf) != null)
            {
                new Controle(cpf);
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
                Console.WriteLine("Digite o cpf do fornecedor: ");
                bloqueado = Console.ReadLine().Trim().Replace(".", "").Replace("-", ""); ;
                if (!ValidaCnpj(bloqueado))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCnpj(bloqueado));

            long cnpj = long.Parse(bloqueado);

            if (cadastros.fornecedores.Find(p => p.CNPJ == cnpj) != null)
            {
                new Controle(cnpj, "remover");
                return cnpj;
            }
            return 0;
        }
        public long RemoverInadimplencia()
        {
            string inadimplente;
            Console.Clear();
            Console.WriteLine("===========REMOVER DE INADIMPLENTE===========");
            do
            {
                Console.WriteLine("Digite o cpf do ex caloteiro: ");
                inadimplente = Console.ReadLine().Trim().Replace(".", "").Replace("-", ""); ;
                if (!ValidaCpf(inadimplente))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCpf(inadimplente));

            long cpf = long.Parse(inadimplente);

            if (cadastros.inadimplentes.Find(p => p == "" + cpf) != null)
            {
                return cpf;
                new Controle(cpf, "remover");
            }
            return 0;
        }
        public long RemoverBloqueio()
        {
            string bloqueado;
            Console.Clear();
            Console.WriteLine("===========REMOVER DE BLOQUEADO===========");
            do
            {
                Console.WriteLine("Digite o cnpj do fornecedor bloqueado: ");
                bloqueado = Console.ReadLine().Trim().Replace(".", "").Replace("-", ""); ;
                if (!ValidaCnpj(bloqueado))//valida cpf
                    Console.WriteLine("Cpf invalido!\nDigite novamente");
            } while (!ValidaCnpj(bloqueado));

            long cnpj = long.Parse(bloqueado);

            if (cadastros.bloqueados.Find(p => p == "" + cnpj) != null)
                return cnpj;
            return 0;
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
                        if (cadastros.clientes.Count() != 0)
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
        public void LocalizarRegistro()
        {
            string opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\t________________________________________________");
                Console.WriteLine("\t|++++++++++++| MENU DE LOCALIZAÇÃO |+++++++++++|");
                Console.WriteLine("\t|1| - LOCALIZAR CLIENTES                       |");
                Console.WriteLine("\t|2| - LOCALIZAR FORNECEDORES                   |");
                Console.WriteLine("\t|3| - LOCALIZAR MATERIAS PRIMAS                |");
                Console.WriteLine("\t|4| - LOCALIZAR PRODUTOS                       |");
                Console.WriteLine("\t|5| - LOCALIZAR VENDAS                         |");
                Console.WriteLine("\t|6| - LOCALIZAR ITENS DE VENDAS                |");
                Console.WriteLine("\t|7| - LOCALIZAR COMPRAS                        |");
                Console.WriteLine("\t|8| - LOCALIZAR ITENS DE COMPRAS               |");
                Console.WriteLine("\t|0| - VOLTAR                                   |");
                Console.Write("\t|______________________________________________|\n" +
                              "\t|Opção: ");
                opc = Console.ReadLine();
                bool encontrado = false;
                Console.Clear();
                switch (opc)
                {

                    case "1":
                        string cpf;
                        do 
                        {
                            Console.Write("Digite o cpf que deseja localizar: ");
                            cpf = Console.ReadLine();
                            if (!ValidaCpf(cpf))
                            {
                                Console.WriteLine("CPF INVÁLIDO, TENTE NOVAMENTE!");
                            }
                        } while (ValidaCpf(cpf) != true);
                        Console.Clear();

                        Cliente localizarcliente = cadastros.clientes.Find(p => p.CPF == long.Parse(cpf));
                        if (localizarcliente != null)
                        {
                            encontrado = true;
                            Console.WriteLine(localizarcliente.DadosCliente());
                        }
                        break;
                    case "2":
                        string cnpj;
                        do
                        {
                            Console.Write("Digite o cnpj que deseja localizar: ");
                            cnpj = Console.ReadLine();
                            if (!ValidaCnpj(cnpj))
                            {
                                Console.WriteLine("CNPJ INVÁLIDO, TENTE NOVAMENTE!");
                            }
                        } while (ValidaCnpj(cnpj) != true);
                        Console.Clear();
                        
                        Fornecedor localizarfornecedor = cadastros.fornecedores.Find(p => p.CNPJ == long.Parse(cnpj));
                        if (localizarfornecedor != null)
                        {
                            encontrado = true;
                            Console.WriteLine(localizarfornecedor.DadosFornecedor());
                        }
                        break;
                    case "3":
                        Console.Write("Digite o nome que deseja localizar: ");
                        string nomeMateriaPrima = Console.ReadLine().Trim().ToLower();
                        List<MPrima> localizarmprima = cadastros.materiasprimas.FindAll(p => p.Nome.ToLower() == nomeMateriaPrima);
                        if (localizarmprima != null)
                        {
                            encontrado = true;
                            localizarmprima.ForEach(p => Console.WriteLine(p.DadosMateriaPrima()));
                        }
                        break;
                    case "4":
                        Console.Write("Digite o nome do produto que deseja localizar: ");
                        string nomeProduto = Console.ReadLine().Trim().ToLower();
                        List<Produto> localizaProduto = cadastros.produtos.FindAll(p => p.Nome.ToLower() == nomeProduto);
                        if (localizaProduto != null)
                        {
                            encontrado = true;
                            localizaProduto.ForEach(p => Console.WriteLine(p.DadosProduto()));
                        }
                        else
                        {
                            Console.WriteLine("ne");
                        }
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
                if(encontrado==false)
                    Console.WriteLine("Registro não encontrado");
                Console.ReadKey();
            } while (opc != "0");
        }
    }
}