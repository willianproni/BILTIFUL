using BILTIFUL.Core;
using BILTIFUL.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Produto produto = new Produto();
                do
                {
                    Console.WriteLine("Insira o nome do produto a ser localizado:");
                    string nome = Console.ReadLine();

                    produto = cadastroService.cadastros.produtos.Find(c => c.Nome == nome);

                    if (produto != null)
                    {
                        producao.Produto = produto.CodigoBarras;
                        Console.WriteLine(produto.DadosProduto());
                    }
                    else
                    {
                        Console.WriteLine("Produto não localizado");
                    }

                } while (produto == null);

     

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

        void DadosProducao(Producao producao, Produto produto)
        {
            Console.WriteLine(producao.Dados());
            Console.WriteLine("Produto: ");
            Console.WriteLine(produto.DadosProduto());
            /*foreach (var materia in mPrimas)
            {
                Console.WriteLine(materia.DadosMateriaPrima()); ;
            }*/
        }

        void DadosProducao(Producao producao)
        {
            Console.WriteLine(producao.Dados());
            Console.WriteLine("Produto: ");
            Console.WriteLine(cadastroService.cadastros.produtos.Find(c => c.CodigoBarras == producao.Produto).DadosProduto());
            /*foreach (var materia in mPrimas)
            {
                Console.WriteLine(materia.DadosMateriaPrima()); ;
            }*/
        }

        void ImpressaoDoRegistro()
        {

            int i = 0;
            string opc = "-1";
            while (opc != "5")
            {
                Console.Clear();
                DadosProducao(producoes[i]);
                Console.WriteLine();
                if (i > 0)
                {
                    Console.WriteLine("1-primeiro");
                    Console.WriteLine("2-anterior");
                }
                if (i < producoes.Count() - 1)
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
                        if (i - 1 >= 0)
                            i--;
                        else
                            Console.WriteLine("Não existe registro antes deste");
                        Console.ReadKey();
                        break;
                    case "3":
                        if (i + 1 <= producoes.Count() - 1)
                            i++;
                        else
                            Console.WriteLine("Não existe registro depois deste");
                        Console.ReadKey();
                        break;
                    case "4":
                        i = producoes.Count() - 1;
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }

            }

        }

        void Localizar()
        {
            Console.WriteLine("Digite o nome ou código de barras do produto para localizar a produção dele.");
            string busca = Console.ReadLine();

            Produto produto = cadastroService.cadastros.produtos.FirstOrDefault(c => c.Nome == busca || c.CodigoBarras == busca);
            Producao producao = producoes.Find(c => c.Produto == produto.CodigoBarras);

            if (producao != null) DadosProducao(producoes.Find(c => c.Produto == produto.CodigoBarras), cadastroService.cadastros.produtos.Find(c => c.Nome == busca));
            else Console.WriteLine("Nenhuma produção enontrada para esse produto\n\n" +( produto != null ? produto.DadosProduto() : string.Empty));

            Console.ReadKey();
        }
    }
}
