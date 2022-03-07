using BILTIFUL.Core;
using BILTIFUL.Core.Controles;
using BILTIFUL.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BILTIFUL.ModuloCompra
{
    public class CompraService
    {
        public CadastroService cadastroService = new CadastroService();
        //List<Fornecedor> testes = new List<Fornecedor>();
        //public void AdicionarFornecedor()
        //{

        //    testes.Add(new Fornecedor(1, "fornecedor1"));
        //    testes.Add(new Fornecedor(2, "fornecedor2"));
        //}

        public void SubMenu()
        {
        
        Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Localizar");
            Console.WriteLine("3 - Imprimir Compras");
            string opc = Console.ReadLine();
            switch (opc)
            {
                case "1":
                    CadastrarCompra();

                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "0":
                    break;
                default:
                    break;
            }
        }

        public void CadastrarCompra()
        {


            string opc = "a";

            Console.Clear();
            do
            {
                    Console.WriteLine("Informe o CNPJ do forncedor");
                    string bloq = Console.ReadLine();
                if (BuscarBloqueado(bloq, cadastroService.cadastros.bloqueados))
                {
                    Console.WriteLine("Fornecedor nao disponivel para compra");
                    Console.ReadKey();
                    CadastrarCompra();
                }

                long cnpj = long.Parse(bloq);
                Fornecedor fornecedorCompra = BuscarCnpj(cnpj, cadastroService.cadastros.fornecedores);
                if (fornecedorCompra == null)
                {
                    Console.WriteLine("Fornecedor nao encontrado.");
                }
                else
                {
                    Console.WriteLine(fornecedorCompra.DadosFornecedorCompra());
                    Console.WriteLine("[1]SIM [0]NAO");
                    Console.WriteLine("Confirma dados do Fornecedor?");
                    opc = Console.ReadLine();
                    if (opc == "0")
                    {
                        Console.WriteLine("");

                    }
                }
            } while (opc != "1");
            ItemCompra();


        }
        public void ItemCompra()
        {
            int cont = 0;
            string saida = "a";
            string opcp = "a";
            do
            {

                do
                {
                    Console.WriteLine("Informe o ID da Materia-Prima");
                    string idMPrima = Console.ReadLine();
                    MPrima mPrimaCompra = BuscaMPrima(idMPrima, cadastroService.cadastros.materiasprimas);
                    if (mPrimaCompra == null)
                    {
                        Console.WriteLine("Materia-Prima nao encontrada.");
                    }
                    else
                    {
                        Console.WriteLine(mPrimaCompra.ToString());
                        Console.WriteLine("[1]SIM [0]NAO");
                        Console.WriteLine("Confirma dados da Materia-Prima?");
                        opcp = Console.ReadLine();
                        if (opcp == "0")
                        {
                            Console.WriteLine("");

                        }
                        else
                        {
                            Console.WriteLine("Informe o valor unitario da Materia-Prima");
                            int valor = int.Parse(Console.ReadLine());
                            Console.WriteLine("Informe a quantiade");
                            int quat = int.Parse(Console.ReadLine());

                        }
                    }

                } while (opcp != "1");
                cont++;
                if (cont == 3)
                {
                    Console.WriteLine("Limite de Materia-Prima atingido por compra");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Deseja adicionar mais materia-prima\n[1]SIM [0]NAO");
                    saida = Console.ReadLine();
                }
            } while ((saida != "0") & (cont != 3));
        }


        public Fornecedor BuscarCnpj(long fcnpj, List<Fornecedor> fornecedor)
        {
            Fornecedor fornecedorcompra = fornecedor.Find(delegate (Fornecedor f) { return f.CNPJ == fcnpj; });

            return fornecedorcompra;
        }

        public bool BuscarBloqueado(string fcnpj, List<string> bloqueados)
        {
            string buscar = bloqueados.Find(x => x == fcnpj);
            if (buscar == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public MPrima BuscaMPrima(string idMPrima, List<MPrima> mPrima)
        {
            MPrima mPrimaCompra = mPrima.Find(delegate (MPrima mP) { return mP.Id == idMPrima; });

            return mPrimaCompra;
        }




    }
}
