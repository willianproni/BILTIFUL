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
                string cnpj = Console.ReadLine().Trim().Replace(".", "").Replace("-", "").Replace("/", "");
                if (BuscarBloqueado(cnpj, cadastroService.cadastros.bloqueados))
                {
                    Console.WriteLine("Fornecedor nao disponivel para compra");
                    Console.ReadKey();
                    CadastrarCompra();
                }


                Fornecedor fornecedorCompra = BuscarCnpj(long.Parse(cnpj), cadastroService.cadastros.fornecedores);
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
            string[] stringValor = new string[4];
            int valor;
            int[] quantidade = new int[4];
            int[] totalItem = new int[4];
            string[] idMPrima = new string[4];


            do
            {

                do
                {
                    opcp = "a";
                    Console.Clear();
                    Console.WriteLine("Informe o ID da Materia-Prima");
                    idMPrima[cont] = Console.ReadLine();
                    MPrima mPrimaCompra = BuscaMPrima(idMPrima[cont], cadastroService.cadastros.materiasprimas);
                    if (mPrimaCompra == null)
                    {
                        Console.WriteLine("Materia-Prima nao encontrada.");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine(mPrimaCompra.ToString());
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("[1]SIM [0]NAO");
                        Console.WriteLine("Confirma dados da Materia-Prima?");
                        opcp = Console.ReadLine();
                        if (opcp == "0")
                        {
                            Console.WriteLine("");

                        }
                        else
                        {
                            
                            do
                            {
                                Console.WriteLine("-----------------------------------------");
                                Console.WriteLine("Informe o valor unitario da Materia-Prima");
                                Console.Write("Valor($$$,$$)(valor precisa ser menor que 1000,00): ");
                                stringValor[cont] = Console.ReadLine().Trim().Replace(".", "").Replace(",", "");
                                if (!int.TryParse(stringValor[cont], out valor) || (valor > 99999) || (valor <= 0))
                                    Console.WriteLine("Valor invalido!");
                            } while (!int.TryParse(stringValor[cont], out valor) || (valor > 99999) || (valor <= 0));
                            do
                            {
                                Console.WriteLine("Informe a quantiade");
                                quantidade[cont] = int.Parse(Console.ReadLine());
                                totalItem[cont] = quantidade[cont] * int.Parse(stringValor[cont]);
                            } while (TotalItem(int.Parse(stringValor[cont]), quantidade[cont]) != true);
                        }
                    }

                } while (opcp != "1");
                Console.WriteLine("Produto:\t{0} Quantidade:\t{1} Valor Unitario:\t{2} Total Item:\t{3}", idMPrima[cont], quantidade[cont], stringValor[cont], totalItem[cont]);
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

            Console.WriteLine("Confirma compra ?");

        }

        public bool TotalItem(int valor, int quantidade)
        {
            
            int totalCompra = valor * quantidade;
            if (totalCompra >= 10000)
            {
                Console.WriteLine("Valor ultrapasssou o valor total permetido por compra");
                Console.WriteLine("Favor informar outra quantidade e outro valor de Materia-Prima");
                Console.WriteLine("Quantidade disponivel para compra: {0}",9999/valor);
                return false;
            }
            else
            { return true; }
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
