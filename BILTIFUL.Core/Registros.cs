using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.Core
{
    internal class Registros
    {
        public Registros(List<Cliente> clientes)
        {

            int i=0;
            string opc = "-1";
            while(opc != "5")
            {
                Console.Clear();
                Console.WriteLine(clientes[i].DadosCliente());
                if (i > 0)
                {
                    Console.WriteLine("1-primeiro");
                    Console.WriteLine("2-anterior");
                }
                if (i < clientes.Count()-1)
                {
                    Console.WriteLine("3-proximo");
                    Console.WriteLine("4-ultimo");
                }
                Console.WriteLine("5-Sair");
                Console.Write("Opção: ");
                opc = Console.ReadLine();
                switch(opc)
                {
                    case "1":
                        i = 0;
                        break; ;
                    case "2":
                        i--;
                        break;
                    case "3":
                        i++;
                        break;
                    case "4":
                        i = clientes.Count()-1;
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }
        }
        public Registros(List<Fornecedor> fornecedor)
        {

            int i = 0;
            string opc = "-1";
            while (opc != "5")
            {
                Console.Clear();
                Console.WriteLine(fornecedor[i].DadosFornecedor());
                if (i > 0)
                {
                    Console.WriteLine("1-primeiro");
                    Console.WriteLine("2-anterior");
                }
                if (i < fornecedor.Count()-1)
                {
                    Console.WriteLine("3-proximo");
                    Console.WriteLine("4-ultimo");
                }
                Console.WriteLine("5-Sair");
                Console.Write("Opção: ");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        i = 0;
                        break; ;
                    case "2":
                        i--;
                        break;
                    case "3":
                        i++;
                        break;
                    case "4":
                        i = fornecedor.Count()-1;
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }
        }
        public Registros(List<MPrima> materiaprima)
        {
            int i = 0;
            string opc = "-1";
            while (opc != "5")
            {
                Console.Clear();
                Console.WriteLine(materiaprima[i].DadosMateriaPrima());
                if (i > 0)
                {
                    Console.WriteLine("1-primeiro");
                    Console.WriteLine("2-anterior");
                }
                if (i < materiaprima.Count() - 1)
                {
                    Console.WriteLine("3-proximo");
                    Console.WriteLine("4-ultimo");
                }
                Console.WriteLine("5-Sair");
                Console.Write("Opção: ");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        i = 0;
                        break; ;
                    case "2":
                        i--;
                        break;
                    case "3":
                        i++;
                        break;
                    case "4":
                        i = materiaprima.Count() - 1;
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }
        }
        public Registros(List<Produto> produto)
        {
            int i = 0;
            string opc = "-1";
            while (opc != "5")
            {
                Console.Clear();
                Console.WriteLine(produto[i].DadosProduto());
                if (i > 0)
                {
                    Console.WriteLine("1-primeiro");
                    Console.WriteLine("2-anterior");
                }
                if (i < produto.Count() - 1)
                {
                    Console.WriteLine("3-proximo");
                    Console.WriteLine("4-ultimo");
                }
                Console.WriteLine("5-Sair");
                Console.Write("Opção: ");
                opc = Console.ReadLine();
                switch (opc)
                {
                    case "1":
                        i = 0;
                        break; ;
                    case "2":
                        i--;
                        break;
                    case "3":
                        i++;
                        break;
                    case "4":
                        i = produto.Count() - 1;
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
