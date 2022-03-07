using BILTIFUL.Core;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BILTIFUL.ModuloProducao
{
    public class ProducaoService
    {
        List<Producao> producoes = new List<Producao>();
        List<ItemProducao> itemProducoes = new List<ItemProducao>();
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

                Console.WriteLine("1- Adicionar Produção");
                Console.WriteLine("2- Localizar Produção");
                Console.WriteLine("3- Exiber Produções cadastradas");
                Console.WriteLine("0- Voltar para menu principal");

                opcao = Console.ReadLine();

                Console.Clear();
                switch (opcao)
                {
                    case "0":
                        break;

                    case "1":
                        Cadastrar();
                        BackMenu();
                        break;

                    case "2":
                        Localizar();
                        BackMenu();
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

        public void BackMenu()
        {
            Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu de Produção...");
            Console.ReadKey();
            Console.Clear();
            SubMenu();
        }


        void Cadastrar()
        {
            Producao producao = new Producao();

            Console.WriteLine("Deseja cadastrar um novo produto? Sim/Não");
            string existe = Console.ReadLine();
            if (existe == "s" || existe == "Sim")
            {
                Produto produto = cadastroService.CadastroProduto();
                if (produto != null) producao.Produto = produto.CodigoBarras;
            }
            else if (existe == "n" || existe == "Nao" || existe == "Nao")
            {
                Produto produto = new Produto();
                do
                {
                    Console.WriteLine("Insira o nome do produto a ser localizado ou digite 0 para sair:");
                    string nome = Console.ReadLine();

                    if (nome == "0") break;

                    produto = cadastroService.cadastros.produtos.Find(c => c.Nome == nome && c.Situacao == Situacao.Ativo);

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
            else Cadastrar();

            Console.WriteLine("Quantos produtos serão produzidos");
            while (!double.TryParse(Console.ReadLine(), out double quantidade))
            {
                Console.WriteLine("Quantos produtos serão produzidos");
                producao.Quantidade = quantidade.ToString().Remove(',').Remove('.');
            }

            bool materiaprima;
            do
            {
                ItemProducao itemProducao = new ItemProducao();

                int posicao = 0;
                Console.WriteLine("Quais as materias primas utilizadas?");
                mPrimas.ForEach(c => Console.WriteLine(++posicao + "- " + c.Nome));
                int materiasprimas = int.Parse(Console.ReadLine());

                itemProducao.MateriaPrima = mPrimas[materiasprimas + 1].Id;

                Console.WriteLine("Quantidade Materia prima");
                while (!double.TryParse(Console.ReadLine(), out double quantidadeMateriaPrima))
                {
                    Console.WriteLine("Quantos produtos serão produzidos");
                    itemProducao.QuantidadeMateriaPrima = quantidadeMateriaPrima.ToString();
                }

                Console.WriteLine("Deseja adicionar mais alguma materia prima");
                materiaprima = Console.ReadLine() == "s";

                itemProducoes.Add(itemProducao);

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
            else Console.WriteLine("Nenhuma produção enontrada para esse produto\n\n" + (produto != null ? produto.DadosProduto() : string.Empty));

        }



    }
}
