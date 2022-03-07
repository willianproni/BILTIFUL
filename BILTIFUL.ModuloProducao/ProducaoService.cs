using BILTIFUL.Core;
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
        List<Producao> producoes = new List<Producao>();
        List<ItemProducao> itemProducao = new List<ItemProducao>();
        List<MPrima> mPrimas = new List<MPrima>();


        CadastroService cadastroService = new CadastroService();




        public void SubMenu()
        {

            /*produtos.Add(new Produto("001", "baton", "9,99"));
            produtos.Add(new Produto("002", "shampoo", "19,99"));
            produtos.Add(new Produto("003", "esmalte", "11,99"));*/

            mPrimas.Add(new MPrima("1", "detergente"));
            mPrimas.Add(new MPrima("2", "aroma"));
            mPrimas.Add(new MPrima("3", "fixador"));

            string opcao = "";
            do
            {
                Console.Clear();

                Console.WriteLine("1- Adicionar");
                Console.WriteLine("2- Localizar");
                Console.WriteLine("3- Imprimir por registro");
                Console.WriteLine("0- Voltar para menu principal");
                opcao = Console.ReadLine();


                Console.Clear();
                switch (opcao)
                {
                    case "0":
                        break;

                    case "1":
                        Cadastrar();
                        break;

                    case "2":
                        Localizar();
                        break;

                    case "3":
                        ImpressaoDoRegistro();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! ");
                        Console.ReadKey();
                        SubMenu();
                        break;
                }
            } while (opcao != "0");

        }

        void Cadastrar()
        {
            Producao producao = new Producao();

            Console.WriteLine("O produto a ser produzido existe?");
            bool existe = Console.ReadLine() == "s";
            if (existe == false)
            {
                Produto produto = cadastroService.CadastroProduto();
                if (produto != null) producao.Produto = produto.CodigoBarras;
            }
            else
            {
                Console.WriteLine("Insira o nome do produto a ser localizado:");
                string nome = Console.ReadLine();

                Produto produto = cadastroService.cadastros.produtos.Find(c => c.Nome == nome);

                if (produto != null)
                {
                    producao.Produto = produto.CodigoBarras;
                    Console.WriteLine(produto.ExibirProd());
                }
                else
                {
                    Console.WriteLine("Produto não localizado");
                }

            }

            Console.WriteLine("Quantos produtos serão produzidos");
            producao.Quantidade = int.Parse(Console.ReadLine());

            bool materiaprima;
            do
            {
                int posicao = 0;
                Console.WriteLine("Quais as materias primas utilizadas?");
                mPrimas.ForEach(c => Console.WriteLine(++posicao + "- " + c.Nome));
                int materiasprimas = int.Parse(Console.ReadLine());

                Console.WriteLine("Quantidade Materia prima");
                int qtdmateriaprima = int.Parse(Console.ReadLine());

                Console.WriteLine("Deseja adicionar mais alguma materia prima");
                materiaprima = Console.ReadLine() == "s";

                if (materiaprima)
                    itemProducao.Add(new ItemProducao()
                    { MateriaPrima = mPrimas[materiasprimas + 1].Id, QuantidadeMateriaPrima = qtdmateriaprima });

            } while (materiaprima);

            producoes.Add(producao);


        }

        void ImpressaoDoRegistro()
        {
            Console.WriteLine("Primeira produção.Data, nome e quant.");

        }

        void Localizar()
        {
            Console.WriteLine("Digite o nome do produto para localizar a produção dele.");
            string nome = Console.ReadLine();

            Produto produto = cadastroService.cadastros.produtos.Find(c => c.Nome == nome);

            if (produto != null)
            {
                Producao producao = producoes.Find(c => c.Produto == produto.CodigoBarras);

                if (producao != null) Console.WriteLine("Data: " + producao.DataProducao + "\n Quantidade: " + producao.Quantidade);
                else Console.WriteLine("Nenhuma produção enontrada para esse produto");

                Console.WriteLine(produto.ExibirProd());

            }

            Console.ReadKey();
        }




    }
}
