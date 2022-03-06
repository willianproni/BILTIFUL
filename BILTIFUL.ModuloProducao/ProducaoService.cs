using BILTIFUL.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILTIFUL.ModuloProducao
{
    public class ProducaoService
    {
        List<Producao> producao = new List<Producao>();
        List<ItemProducao> itemProducao = new List<ItemProducao>();
        List<Produto> produtos = new List<Produto>();
        List<MPrima> mPrimas = new List<MPrima>();


        public void SubMenu()
        {
            string opcao = "a";
            Console.WriteLine("1- Adicionar");
            Console.WriteLine("2- Remover");
            Console.WriteLine("3- Localizar");
            Console.WriteLine("4- Imprimir por registro");
            opcao = Console.ReadLine();


            Console.Clear();
            switch (opcao)
            {
                case "1":
                    Cadastrar();
                    break;

                case "2":
                    Remover();
                    break;

                case "3":
                    Localizar();
                    break;

                case "4":
                    ImpressaoDoRegistro();
                    break;
                default:
                    break;
            }


        }

        void Cadastrar()
        {
            Producao producao = new Producao();

            Console.WriteLine("O produto a ser produzido existe?");
            Console.WriteLine("Insira o nome do produto:");
            Console.WriteLine("Preço:");
            Console.WriteLine("Produto ativo ou inativo:");

            Console.WriteLine("Insira o nome do produto a ser localizado:");
            Console.WriteLine("Quantos produtos serão produzidos");
            Console.WriteLine("Quais as materias primas utilizadas?");
            Console.WriteLine("1- Detergente" +
                "2- Corante");
            Console.WriteLine("Quantidade Materia prima");
            Console.WriteLine("Deseja adicionar mais alguma materia prima");



            Console.WriteLine("");



        }

        void Remover()
        {
            Console.WriteLine("Excluir a produção. Digite o nome do produto para localizar a produção dele.");
        }

        void ImpressaoDoRegistro()
        {
            Console.WriteLine("Primeira podução.Data, nome e quant.");
        }

        void Localizar()
        {
            Console.WriteLine("Digite o nome do produto para localizar a produção dele.");
        }




    }
}
