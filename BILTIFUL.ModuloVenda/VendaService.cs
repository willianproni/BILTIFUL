using System;
using System.Collections.Generic;
using BILTIFUL.Core.Controles;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.ModuloVenda
{
    public class VendaService
    {
        List<Venda> vendas = new List<Venda>();
        List<Produto> produtos = new List<Produto>();
        List<Cliente> clientes = new List<Cliente>();
        List<ItemVenda> itemVenda = new List<ItemVenda>();
        List<Producao> producao = new List<Producao>();
        ItemVenda vendaitem = new ItemVenda();
        Venda venda = new Venda();
        Controle controle = new Controle();

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
                        ItemVenda();
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
           /* producao.Add(new Producao("batom", 12));
            producao.Add(new Producao("Blush", 33));*/
           /* vendas.Add(new Venda("1", 392489343, 88));
            vendas.Add(new Venda("2", 194832748, 434));*/

        }
        public void CadastrarVenda()
        {
            Console.Clear();
            Console.WriteLine("Digite o Cpf do cliente: ");
            long clientecpf = long.Parse(Console.ReadLine());
            BuscarCpf(clientecpf, clientes);
            Console.WriteLine("Digite o Cpf do cliente: ");
            new Venda();
        }
        public void ItemVenda()
        {
            Console.Clear();
            Console.WriteLine("\t\t------------ Cadastro de Venda ------------");
            int cont = 0;
            int quantidade = 1;
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
                        Console.WriteLine($"\n\t\tValor Total: {valorTotal}");
                        cont++;
                        itemVenda.Add(new ItemVenda(codigoProd, quantidade.ToString().Remove(',').Remove('.').PadLeft(3,'0'), valorTotal.ToString().Remove(',').Remove('.').PadLeft(5,'0')));

                        Console.WriteLine($"\t\t{quantidade} {aux.Nome} Comprado!!");

                    }
                    else
                    {
                        Console.WriteLine("Digite uma quantidade válida!!");
                    }
                }
            } while (cont != 3);

            itemVenda.ForEach(i => Console.WriteLine(i.ToString()));
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
        
        public Cliente BuscarCpf(long ccpf, List<Cliente> cliente)
        {
            Cliente clientecompra = cliente.Find(delegate (Cliente c) { return c.CPF == ccpf; });
            return clientecompra;
        }
    }
}
