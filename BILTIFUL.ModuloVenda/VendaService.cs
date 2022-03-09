using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL;
using BILTIFUL.Core.Controles;
using BILTIFUL.Core;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;

namespace BILTIFUL.ModuloVenda
{
    public class VendaService
    {

        Controle controle = new Controle();
        ItemVenda vendaitem = new ItemVenda();
        CadastroService servicocadastro = new CadastroService();
        Venda venda = new Venda();

        long clienteVenda;
        float valorVenda = 0;
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("\t________________________________________________");
            Console.WriteLine("\t|+++++++++++++++++++| Vendas |+++++++++++++++++++|");
            Console.WriteLine("\t|1| - CADASTRAR VENDA                            |");
            Console.WriteLine("\t|2| - LOCALIZAR VENDA                            |");
            Console.WriteLine("\t|3| - EXCLUIR VENDA                              |");
            Console.WriteLine("\t|4| - REGISTROS DE VENDAS                        |");
            Console.WriteLine("\t|0| - VOLTAR                                     |");
            Console.Write("\t|________________________________________________|\n" +
                          "\t|Opção: ");
        }

        public void SubMenu()
        {
            int opc;

            do
            {
                Menu();
                if (int.TryParse(Console.ReadLine(), out int CanParse))
                {
                    opc = CanParse;
                }
                else
                {
                    opc = -1;
                }
                switch (opc)
                {
                    case 0:
                        break;
                    case 1:
                        CadastrarVenda();
                        break;
                    case 2:
                        servicocadastro.LocalizarRegistro();
                        break;
                    case 3:
                        Console.WriteLine("Excluir Venda");
                        break;
                    case 4:
                        if (servicocadastro.cadastros.vendas.Count() != 0)
                            new Registros(servicocadastro.cadastros.vendas, servicocadastro.cadastros.itensvenda);
                        else
                            Console.WriteLine("Nenhum Venda registrada");
                        break;

                    default:
                        Console.WriteLine("Digite Uma Opção invalida");
                        Console.ReadKey();
                        break;
                }
            } while (0 != opc);

        }

        public void CadastrarVenda()
        {
            Console.Clear();
            Console.WriteLine("\t\t------------- Verificar CPF -------------\n");
            Console.Write("\t\tDigite o Cpf do cliente: ");

            if (long.TryParse(Console.ReadLine(), out long confimar))
            {
                long cpfCliente = confimar;

                if (BuscarInadimplentes(cpfCliente, controle.inadimplentes))
                {
                    Console.WriteLine("\t\t-------------------------- Solicitar  ao cliente que se direcione a gerencia------------- "); //Cliente Inadimplente
                    Console.ReadKey();
                }
                else
                {
                    long clientecpf = cpfCliente;
                    clienteVenda = clientecpf;
                    Cliente aux = BuscarCpf(clientecpf, controle.clientes);

                    if (aux == null)
                    {
                        Console.WriteLine("\n\t\t-----------------------------------------" +
                                          "\n\t\t\t   CPF não encontrado\n" +
                                          "\t\t-----------------------------------------");
                        Console.Write("\t\tCadastrar um nome Cliente (S/N): ");
                        string cadNovoCliente = Console.ReadLine().ToUpper();
                        if (cadNovoCliente == "S" || cadNovoCliente == "SIM")
                        {
                            servicocadastro.CadastroCliente();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\t\tRetornando para o Menu de Vendas... aperte qualquer tecla...");
                            Console.ReadKey();
                        }
                        //Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine(aux.VendasCliente());
                        Console.Write("\n\t\tConfirma dados Cliente [S]/[N]: ");
                        if (char.TryParse(Console.ReadLine().ToUpper(), out char confirmarCliente))
                        {
                            if (confirmarCliente == 'S')
                            {
                                ItemVenda();
                            }
                        }
                        //Console.Clear();
                    }
                }
            }
            else
            {
                Console.Write("\n\t\tDigite um CPF!!");
                Console.ReadKey();
            }
        }

        public void ItemVenda()
        {
            Console.Clear();
            Console.WriteLine("\t\t------------ Cadastro de Venda ------------");
            int cont = 0;
            float quantidade = 1;

            string codigo = CodIdIncremento();
            do
            {
                Console.Write("\n\t\tCódigo do Produto: ");
                string codProduto = Console.ReadLine();
                Produto aux = vendaitem.CodigoProdutoValido(codProduto, controle.produtos);
                if (aux != null)
                {
                    Console.Write("\t\tDigite a Quantidade do Produto: ");
                    if (float.TryParse(Console.ReadLine(), out float CanParse) && quantidade > 0)
                    {
                        quantidade = CanParse;
                        if (quantidade > 999)
                        {
                            do
                            {
                                Console.WriteLine("\t\tQuantidade máxima de produto por item é 999");
                                Console.Write("\t\tDigite a Quantidade do Produto: ");
                                if (float.TryParse(Console.ReadLine(), out float quantMax) && quantidade > 0)
                                {
                                    quantidade = quantMax;
                                }
                                else
                                {
                                    Console.WriteLine("\t\tDigite uma quantidade válida!");
                                }
                            } while (quantidade > 999);
                        }
                        float valorUnitario = float.Parse(aux.ValorVenda);
                        float valorTotal = quantidade * valorUnitario;
                        if (valorTotal > 9999)
                        {
                            do
                            {
                                Console.WriteLine("\n\t\tValor Total superior ao permitido, máximo valor por item é R$ 9.999");
                                Console.Write("\t\tDigite a Quantidade do Produto: ");
                                if (float.TryParse(Console.ReadLine(), out float quantUnidadeTotal) && quantidade > 0)
                                {
                                    quantidade = quantUnidadeTotal;
                                }
                                else
                                {
                                    Console.WriteLine("\t\tDigite uma quantidade válida!");
                                }
                                valorTotal = quantidade * valorUnitario;
                            } while (valorTotal > 9999);
                        }
                        if (valorVenda + valorTotal == 99999)
                        {
                            Console.WriteLine("\n\t\tValor total de Compras atigindo, abrir novo cadastro de compras");
                            cont = 3;
                        }
                        else if (valorVenda + valorTotal > 99999)
                        {
                            do
                            {
                                Console.WriteLine($"\t\tPreço máximo por compra atingido, escolha outra quantidade do produto até R$ {99999 - valorVenda}");
                                Console.Write("\t\tDigite a Quantidade do Produto: ");
                                if (float.TryParse(Console.ReadLine(), out float quantValorTotal) && quantidade > 0)
                                {
                                    quantidade = quantValorTotal;
                                }
                                else
                                {
                                    Console.WriteLine("\t\tDigite uma quantidade válida!");
                                }
                                valorTotal = quantidade * valorUnitario;
                            } while (valorVenda + valorTotal > 99999);
                        }


                        valorVenda = valorTotal + valorVenda;

                        Console.WriteLine($"\n\t\tValor Total: R${valorTotal.ToString("F2").TrimStart('0')}");
                        cont++;

                        controle.itensvenda.Add(new ItemVenda(codigo, codProduto, quantidade.ToString().Replace(",", "").Replace(".", ""), valorUnitario.ToString("F2").Replace(",", "").Replace(".", "")));

                        Console.WriteLine($"\t\t{quantidade} {aux.Nome} adicionados na venda!!");
                        if (cont <= 2)
                        {
                            Console.Write("\n\t\t Deseja adiciona outro Item [S]/[N]: ");
                            string adicionarNovoItem = Console.ReadLine().ToUpper();

                            if (adicionarNovoItem == "S" || adicionarNovoItem == "SIM")
                            {
                            }
                            else
                            {
                                cont = 3;
                            }
                        }


                    }
                    else
                    {
                        Console.WriteLine("\t\t\tDigite uma quantidade válida!!");
                    }
                }
            } while (cont <= 2 || cont != 3);

            Console.Write("\t\tConfirmar Compras [S]/[N]: ");
            string confirmarCompras = Console.ReadLine().ToUpper();
            if (confirmarCompras == "S" || confirmarCompras == "SIM")
            {
                SalvarItemVenda(codigo);
                controle.vendas.Add(new Venda(codigo, clienteVenda, valorVenda.ToString("F2").Replace(",", "").Replace(".", "")));
                new Controle(new Venda(codigo, clienteVenda, valorVenda.ToString("F2").Replace(",", "").Replace(".", "")));

            }
            else
            {
                RemoveItem(codigo);
                CodIdDecremento();
                Console.WriteLine("\n\t\tVenda Cancelada!!");
                Console.ReadKey();
            }
        }

        public void RemoveItem(string codigo)
        {
            codigo = codigo.PadLeft(5, '0');
            for (int i = 0; i < 3; i++)
            {
                controle.itensvenda.FindAll(delegate (ItemVenda iv)
                {
                    if (iv.Id == codigo)
                    {
                        Console.WriteLine("Removendo compra...");
                        Console.WriteLine(iv);
                        controle.itensvenda.Remove(iv);
                    }
                    return true;
                });
            }

        }
        public string CodIdIncremento()
        {
            controle.codigos[2]++;
            SalvarCodigos();
            string cod = "" + controle.codigos[2];

            return cod;
        }
        public string CodIdDecremento()
        {
            controle.codigos[2]--;
            SalvarCodigos();
            string cod = "" + controle.codigos[2];

            return cod;
        }

        public void SalvarItemVenda(string codigo)
        {
            codigo = codigo.PadLeft(5, '0');

            foreach (ItemVenda iv in controle.itensvenda)
            {
                if (iv.Id == codigo)
                {
                    new Controle(new ItemVenda(codigo, iv.Produto, iv.Quantidade.ToString().Replace(",", "").Replace(".", ""), iv.ValorUnitario.ToString().Replace(",", "").Replace(".", "")));

                }
            }
        }
        public void SalvarCodigos()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Arquivos\\Controle.dat");
                sw.WriteLine(controle.codigos[0]);
                sw.WriteLine(controle.codigos[1]);
                sw.WriteLine(controle.codigos[2]);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool BuscarInadimplentes(long clientcpf, List<string> inadimplentes)
        {
            string clienteinadimplentes = inadimplentes.Find(delegate (string i) { return i == clientcpf.ToString(); });
            if (clienteinadimplentes == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Cliente BuscarCpf(long ccpf, List<Cliente> cliente)
        {
            Cliente clientecompra = cliente.Find(delegate (Cliente c) { return c.CPF == ccpf; });
            return clientecompra;
        }

    }
}
