using System;
using System.Collections.Generic;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.ModuloVenda
{
    public class VendaService
    {
        int cont = 0;
        List<Venda> vendas = new List<Venda>();
        List<Produto> produtos = new List<Produto>();
        List<Cliente> clientes = new List<Cliente>();
        ItemVenda itemVenda = new ItemVenda();

        public void Menu()
        {
            Console.WriteLine("[1] - Cadastrar" +
                              "\n[2] - Localizar" +
                              "\n[3] - Excluir" +
                              "\n[4] - Imprimir Registro" +
                              "\n[0] - sair");
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
                    case 1:
                        ItemVenda();
                        break;
                    case 2:
                        Console.WriteLine("Localizar Venda ");
                        break;
                    case 3:
                        Console.WriteLine("Excluir Venda");
                        break;
                    case 4:
                        Console.WriteLine("Impressão");
                        break;
                    default:
                        Console.WriteLine("Digite Uma Opção invalida");
                        break;
                }
            } while (0 != opc);
            Menu();
        }

        public void AdicionandoProduto()
        {
            produtos.Add(new Produto("1234567", "batom", "12"));
            produtos.Add(new Produto("3245676", "Blush", "12"));
        }

        public Venda CadastrarVenda()
        {
            Console.WriteLine("Digite o Cpf do cliente: ");
            long clientecpf = long.Parse(Console.ReadLine());
            BuscarCpf(clientecpf, clientes);
            Console.WriteLine("Data venda: ");
            DateTime datavenda = DateTime.Now;
            Console.WriteLine("Digite o Cpf do cliente: ");
            return new Venda();
        }

        public ItemVenda ItemVenda()
        {
            AdicionandoProduto();
            do
            {
                Console.WriteLine("Digite o Código do Produto: ");
                string codigoProd = Console.ReadLine();
                Produto aux = itemVenda.CodigoProdutoValido(codigoProd, produtos);

                Console.WriteLine("Digite a Quantidade do Produto: ");
                int quantidade = int.Parse(Console.ReadLine());
                int valorTotal = quantidade * aux.vvenda;
                Console.WriteLine(valorTotal);
                return new ItemVenda();
            } while (cont != 3);
        }

        public void ExibirVendas(List<Venda> list)
        {
            list.ForEach(i => Console.WriteLine(i));
        }

        public Cliente BuscarCpf(long ccpf, List<Cliente> cliente)
        {
            Cliente clientecompra = cliente.Find(delegate (Cliente c) { return c.cpf == ccpf; });
            return clientecompra;
        }
    }
}
