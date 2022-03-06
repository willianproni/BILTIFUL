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
        List<Producao> producao = new List<Producao>();
        List<ItemProducao> itemProducao = new List<ItemProducao>();
        List<Produto> produtos = new List<Produto>();
        List<MPrima> mPrimas = new List<MPrima>();


        CadastroService cadastroService = new CadastroService();




        public void SubMenu()
        {

            produtos.Add(new Produto("001", "baton", "9,99"));
            produtos.Add(new Produto("002", "shampoo", "19,99"));
            produtos.Add(new Produto("003", "esmalte", "11,99"));

            mPrimas.Add(new MPrima("1", "detergente"));
            mPrimas.Add(new MPrima("2", "aroma"));
            mPrimas.Add(new MPrima("3", "fixador"));

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

                Produto produto = produtos.Find(c => c.Nome == nome);

                if (produto != null) producao.Produto = produto.CodigoBarras;

            }

            Console.WriteLine("Quantos produtos serão produzidos");
            int qtdProduto = int.Parse(Console.ReadLine());

            bool materiaprima;
            do
            {
                Console.WriteLine("Quais as materias primas utilizadas?");
                mPrimas.ForEach(c => Console.WriteLine(c.Nome));
                int materiasprimas = int.Parse(Console.ReadLine());

                Console.WriteLine("Quantidade Materia prima");
                int qtdmateriaprima = int.Parse(Console.ReadLine());

                Console.WriteLine("Deseja adicionar mais alguma materia prima");
                materiaprima = Console.ReadLine() == "s";

                if (materiaprima)
                    itemProducao.Add(new ItemProducao()
                    { MateriaPrima = mPrimas[materiasprimas].Id, QuantidadeMateriaPrima = qtdmateriaprima });

            } while (materiaprima);





        }

        void Remover()
        {
            Console.WriteLine("Excluir a produção. Digite o nome do produto para localizar a produção dele.");
            string nome = Console.ReadLine();
        }

        void ImpressaoDoRegistro()
        {
            Console.WriteLine("Primeira produção.Data, nome e quant.");

        }

        void Localizar()
        {
            Console.WriteLine("Digite o nome do produto para localizar a produção dele.");
            string nome = Console.ReadLine();
        }




    }
}
