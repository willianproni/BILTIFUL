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
        Controle controle = new Controle();
        List<Fornecedor> testes = new List<Fornecedor>();
        public void AdicionarFornecedor()
        {

            testes.Add(new Fornecedor(1, "fornecedor1"));
            testes.Add(new Fornecedor(2, "fornecedor2"));
        }

        public void SubMenu()
        {
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Localizar");
            Console.WriteLine("3 - Imprimir Compras");
            string opc = Console.ReadLine();
            switch (opc)
            {
                case "1":
                    Cadastrar();
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

        public void Cadastrar()
        {
            AdicionarFornecedor();
            int cont = 0;
            string saida = "a";
            string opc = "a";
            do
            {
                Console.Clear();
                do
                {
                    Console.WriteLine("Informe o CNPJ do forncedor");
                    long cnpj = long.Parse(Console.ReadLine());
                    Fornecedor fornecedorCompra = BuscarCnpj(cnpj, testes);
                    if (fornecedorCompra == null)
                    {
                        Console.WriteLine("Fornecedor nao encontrado. Favor informar outro cnpj");
                    }
                    else
                    {
                        Console.WriteLine(fornecedorCompra.ToString());
                        Console.WriteLine("[1]SIM [0]NAO");
                        Console.WriteLine("Confirma dados do Fornecedor?");
                        opc = Console.ReadLine();
                        if (opc == "0")
                        {
                            Console.WriteLine("Pressione uma tecla para voltar e informar o fornecedor correto");
                            Console.ReadKey();

                        }
                    }
                } while (opc != "1");
                Console.WriteLine("Informe o codigo da materia-prima");
                string mprima = Console.ReadLine();
                BuscaMPrima(mprima, controle.materiasprimas);
                Console.WriteLine("Informe a quantiade");
                int quat = int.Parse(Console.ReadLine());
                Console.WriteLine("Deseja adicionar mais materia-prima\n[1]SIM [0]NAO");
                saida = Console.ReadLine();
                cont++;
                Console.WriteLine("{0}{1}", saida, cont);
            } while ((saida != "0") & (cont != 3));
        }

        public Fornecedor BuscarCnpj(long fcnpj, List<Fornecedor> fornecedor)
        {
            Fornecedor fornecedorcompra = fornecedor.Find(delegate (Fornecedor f) { return f.cnpj == fcnpj; });

            return fornecedorcompra;


            //if (fornecedorcompra == null)
            //{
            //    string retorno = "Fornecedor nao encontrado favor informar outro cnpj";
            //    return retorno;
            //}
            //else
            //{
            //    return fornecedorcompra.ToString();
            //}
        }

        public MPrima BuscaMPrima(string idMPrima, List<MPrima> mPrima)
        {
            MPrima mPrimaCompra = mPrima.Find(delegate (MPrima mP) { return mP.id == idMPrima; });

            return mPrimaCompra;
        }



        public void ImprimirForncedor()
        {


        }


    }
}
