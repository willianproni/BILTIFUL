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
        List<Venda> vendas = new List<Venda>();
        List<Produto> produtos = new List<Produto>();
        List<Cliente> clientes = new List<Cliente>();
        List<ItemVenda> itemVenda = new List<ItemVenda>();
        List<Producao> producao = new List<Producao>();
        ItemVenda vendaitem = new ItemVenda();
        Venda venda = new Venda();



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
                        break;
                    default:
                        Console.WriteLine("Digite Uma Opção invalida");
                        Console.ReadKey();
                        break;
                }
            } while (0 != opc);
            Menu();
        }

        public void AdicionandoProduto()
        {
            produtos.Add(new Produto("1234567", "batom", "12"));
            produtos.Add(new Produto("3245676", "Blush", "12"));
            producao.Add(new Producao("batom", "12"));
            producao.Add(new Producao("Blush", "33"));
            vendas.Add(new Venda("1", 392489343, 88));
            vendas.Add(new Venda("2", 194832748, 434));
            clientes.Add(new Cliente(123456789, "Nayron Holuppi"));
            clientes.Add(new Cliente(123456788, "Willian Proni"));
            controle.inadimplentes.Add("123456789");
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
                Cliente aux = BuscarCpf(clientecpf, clientes);

                if (aux == null)
                {
                    Console.WriteLine("\n\t\t-----------------------------------------" +
                                      "\n\t\t\t   CPF não encontrado\n" +
                                      "\t\t-----------------------------------------");
                    Console.Write("\t\tCadastrar um nome Cliente (S/N): ");
                    char cadNovoCliente = char.Parse(Console.ReadLine().ToUpper());
                    if (cadNovoCliente == 'S')
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
                Produto aux = vendaitem.CodigoProdutoValido(codigoProd, produtos);
                if (aux != null)
                {
                    Console.Write("\t\tDigite a Quantidade do Produto: ");

                    if (int.TryParse(Console.ReadLine(), out int CanParse) && quantidade > 0)
                    {
                        quantidade = CanParse;
                        int valorTotal = quantidade * int.Parse(aux.ValorVenda);
                        Console.WriteLine($"\n\t\tValor Total: R${valorTotal}");
                        cont++;                    

                        itemVenda.Add(new ItemVenda(cod, codigoProd, quantidade, valorTotal));

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
            RegistroVenda(cod);
            /* 
               itemVenda.ForEach(i => Console.WriteLine(i.ToString()));
               Console.ReadKey();
              */
        }
        public string CodId() {
            cadastros.codigos[2]++;
            SalvarCodigos();
            string cod = "" + cadastros.codigos[2];

            return cod;
        }

        public void RegistroVenda(string cod)
        {
           
          /*clienteVenda.ForEach(delegate (ItemVenda i)
            {
                Console.WriteLine("Id = 0:");
                Console.WriteLine(String.Format("{0} {1} {2} {3} {4}",i.Id, i.Produto , i.Quantidade , i.ValorUnitario, i.TotalItem));
                Console.ReadKey();

        
             
            });*/

        

            /*   long cliente =
            int ValorTotal =
            cadastros.produtos.Add(new Produto(cod, cliente, ValorTotal));*/
        }
        public void Localizar()
        {
            Console.Clear();
            Console.WriteLine("\t\t------------ Localizar Venda ------------");
            Console.Write("\t\tDigite a venda especifica: ");
            string buscarId = Console.ReadLine();
            venda.LocalizarVenda(buscarId, vendas);
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
