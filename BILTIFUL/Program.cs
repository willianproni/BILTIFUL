using BILTIFUL.Core.Controles;
using BILTIFUL.ModuloCompra;
using BILTIFUL.ModuloProducao;
using BILTIFUL.ModuloVenda;
using BILTIFUL.Core;
using System;

namespace BILTIFUL
{
    public class Program
    {
        static ProducaoService producaoService = new ProducaoService();
        static VendaService vendaService = new VendaService();
        static CompraService compraService = new CompraService();
        static CadastroService cadastroService = new CadastroService();
        static void Main(string[] args)
        {
            
            Menu();
        }

        public static void Menu()
        {

            Console.WriteLine(@$"

                                1) Producao
                                2) Compra
                                3) Venda
                                4) Cadastro
                                ------------------------------
                                0) - Sair
");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0": Environment.Exit(0); break;

                case "1":
                    Console.Clear();
                    producaoService.SubMenu();
                    BackMenu();
                    break;

                case "2":
                    Console.Clear();
                    compraService.SubMenu();
                    BackMenu();
                    break;

                case "3":
                    Console.Clear();
                    vendaService.SubMenu();
                    BackMenu();
                    break;

                case "4":
                    Console.Clear();
                    cadastroService.SubMenu();
                    BackMenu();
                    break;

                default:
                    Console.WriteLine("Opção inválida! ");
                    BackMenu();
                    break;
            }

        }

        public static void BackMenu()
        {
            Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
