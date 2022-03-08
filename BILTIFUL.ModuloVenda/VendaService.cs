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

namespace BILTIFUL.ModuloVenda
{
    public class VendaService
    {

        Controle cadastros = new Controle();
        Controle controle = new Controle();
        ItemVenda vendaitem = new ItemVenda();
        Venda venda = new Venda();

        long clienteVenda;
        int valorVenda = 0;
        public void Menu()
        {
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
        //78966171234567
        //78966173245676
        public void SubMenu()
        {
            int opc;
            AdicionandoProduto();
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
                        Localizar();
                        break;
                    case 3:
                        Console.WriteLine("Excluir Venda");
                        break;
                    case 4:
                        Console.WriteLine("Impressão");
                        RegistroVenda();
                        break;

                    default:
                        Console.WriteLine("Digite Uma Opção invalida");
                        Console.ReadKey();
                        break;
                }
            } while (0 != opc);

        }

        public void AdicionandoProduto()
        {
            controle.produtos.Add(new Produto("1234567", "batom", "12"));
            controle.produtos.Add(new Produto("3245676", "Blush", "20"));
            controle.producao.Add(new Producao("batom", "12"));
            controle.producao.Add(new Producao("Blush", "33"));
            controle.clientes.Add(new Cliente(123456789, "Nayron Holuppi"));
            controle.clientes.Add(new Cliente(123456788, "Willian Proni"));
            controle.inadimplentes.Add("123456787");
            controle.inadimplentes.Add("111111111");
            controle.inadimplentes.Add("333333333");
        }
        public void CadastrarVenda()
        {

            Console.Clear();
            Console.WriteLine("\t\t------------- Verificar CPF -------------\n");
            Console.Write("\t\tDigite o Cpf do cliente: ");
            string clientcpf = Console.ReadLine();

            if (BuscarInadimplentes(clientcpf, controle.inadimplentes))
            {
                Console.WriteLine("\t\t-------------------------- Solicitar  ao cliente que se direcione a gerencia------------- ");
                Console.ReadKey();

            }
            else
            {

                long clientecpf = long.Parse(clientcpf);
                clienteVenda = clientecpf;
                Cliente aux = BuscarCpf(clientecpf, controle.clientes);

                if (aux == null)
                {
                    Console.WriteLine("\n\t\t-----------------------------------------" +
                                      "\n\t\t\t   CPF não encontrado\n" +
                                      "\t\t-----------------------------------------");
                    Console.Write("\t\tCadastrar um nome Cliente (S/N): ");
                    string cadNovoCliente = Console.ReadLine().ToUpper();
                    if (cadNovoCliente == "S")
                    {
                        Console.ReadKey();
                    }
                    else
                    {

                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(aux.VendasCliente());
                    Console.Write("\n\t\tConfimar Pessoa (S) para continuar ou qualquer teclar para sair:");
                    if (char.TryParse(Console.ReadLine().ToUpper(), out char confirpessoa))
                    {
                        if (confirpessoa == 'S')
                        {
                            ItemVenda();
                        }

                    }

                    Console.Clear();
                }

            }




        }
        public void ItemVenda()
        {
            Console.Clear();
            Console.WriteLine("\t\t------------ Cadastro de Venda ------------");
            int cont = 0;
            int quantidade = 1;

            string cod = CodId();
            do
            {
                Console.Write("\n\t\tCódigo do Produto: ");
                string codigoProd = Console.ReadLine();
                Produto aux = vendaitem.CodigoProdutoValido(codigoProd, controle.produtos);
                if (aux != null)
                {
                    Console.Write("\t\tDigite a Quantidade do Produto: ");

                    if (int.TryParse(Console.ReadLine(), out int CanParse) && quantidade > 0)
                    {
                        quantidade = CanParse;
                        int valorUnitario = int.Parse(aux.ValorVenda);
                        int valorTotal = quantidade * int.Parse(aux.ValorVenda);

                        valorVenda = valorTotal + valorVenda;

                        Console.WriteLine($"\n\t\tValor Total: R${valorTotal}");
                        cont++;

                        controle.itensvenda.Add(new ItemVenda(cod, codigoProd, quantidade, valorUnitario));

                        Console.WriteLine($"\t\t{quantidade} {aux.Nome} adicionados na venda!!");
                        if (cont <= 2)
                        {

                            Console.Write("\n\t\t Deseja adicionar outro item nessa comprar se sim digite S se não qualquer tecla : ");
                            string adicionarNovoItem = Console.ReadLine().ToUpper();

                            if (adicionarNovoItem == "S")
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
            } while (cont != 3);


            controle.vendas.Add(new Venda(cod, clienteVenda, valorVenda));

        }
        public string CodId()
        {
            cadastros.codigos[2]++;
            SalvarCodigos();
            string cod = "" + cadastros.codigos[2];

            return cod;
        }

        public void RegistroVenda()
        {


            Console.WriteLine("\t__________________________________________________________________");
            Console.WriteLine("\t|+++++++++++++++++++++| Registro de Vendas |+++++++++++++++++++++");
            Console.WriteLine("\t|                                                                ");
            controle.vendas.ForEach((Action<Venda>)(v =>
            {



                Console.WriteLine("\t| Id da Venda : " + v.Id + "          Data de venda : " + v.DataVenda + "  ");
                Console.WriteLine("\t| Cpf do Cliente : " + v.Cliente + "                                     |");
                Console.WriteLine("\t|                                                                ");



                controle.itensvenda.ForEach((Action<ItemVenda>)(i =>
                {
                    if (v.Id == i.Id)
                        Console.WriteLine("\t|                                                                ");
                    Console.WriteLine("\t| Id do Item :" + i.Id + "                                                ");
                    Console.WriteLine("\t| Codigo do Produto :" + i.Produto + "                              ");
                    Console.WriteLine("\t| Quantidade :" + i.Quantidade + "                                                ");
                    Console.WriteLine("\t| Valor Unitario :" + i.ValorUnitario + "                                           ");
                    Console.WriteLine("\t| Total do valor por item :" + i.TotalItem + "                                   ");
                    Console.WriteLine("\t|                                                                ");
                    Console.Write("\t|________________________________________________________________\n");
                }));
                Console.WriteLine("\t| Valor total da venda :" + v.ValorTotal + "                                      ");


            }));

            Console.Write("\t|________________________________________________________________\n");

            Console.ReadKey();
        }
        public void Localizar()
        {
            Console.Clear();
            Console.WriteLine("\t\t------------ Localizar Venda ------------");
            Console.Write("\t\tDigite a venda especifica: ");
            string buscarId = Console.ReadLine();
            venda.LocalizarVenda(buscarId, controle.vendas);
            Console.ReadKey();
            Console.Clear();
        }
        public void SalvarCodigos()
        {
            try
            {
                StreamWriter sw = new StreamWriter("Arquivos\\Controle.dat");
                sw.WriteLine(cadastros.codigos[0]);
                sw.WriteLine(cadastros.codigos[1]);
                sw.WriteLine(cadastros.codigos[2]);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool BuscarInadimplentes(string clientcpf, List<string> inadimplentes)
        {
            string clienteinadimplentes = inadimplentes.Find(delegate (string i) { return i == clientcpf; });
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
