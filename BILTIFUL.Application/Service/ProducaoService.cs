using BILTIFUL.Application.Repository;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;
using System;
using System.Collections.Generic;

namespace BILTIFUL.Application.Service
{
    public class ProducaoService
    {
        private ProducaoRepository producaoRepository = new ProducaoRepository();
        private ItemProducaoRepository itemProducaoRepository = new ItemProducaoRepository();
        private MateriaPrimaRepository materiaPrimaRepository = new MateriaPrimaRepository();
        private ProdutoRepository produtoRepository = new ProdutoRepository();

        public void SubMenu()
        {
            string opcao = "";


            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t __________________________________________________");
            Console.WriteLine("\t\t\t\t\t|+++++++++++++++++++| PRODUÇÃO |+++++++++++++++++++|");
            Console.WriteLine("\t\t\t\t\t|1| - ADICIONAR PRODUÇÃO                           |");
            Console.WriteLine("\t\t\t\t\t|2| - LOCALIZAR PRODUÇÃO                           |");
            Console.WriteLine("\t\t\t\t\t|3| - EXIBIR PRODUÇÃO CADASTRADAS                  |");
            Console.WriteLine("\t\t\t\t\t|0| - SAIR                                         |");
            Console.Write("\t\t\t\t\t|__________________________________________________|\n" +
                          "\t\t\t\t\t|Opção: ");


            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    break;

                case "1":
                    Console.Clear();
                    if (!MateriaPrimaVazia())
                    {
                        EntradaDadosProducao(new Producao());
                    }

                    break;

                case "2":
                    Console.Clear();
                    if (!ProducaoVazia())
                    {
                        Localizar();
                    }

                    break;

                case "3":
                    Console.Clear();
                    if (!ProducaoVazia())
                    {
                        ImpressaoDoRegistro();
                    }

                    break;
                default:
                    Console.WriteLine("\t\t\t\t\tOpção inválida! ");
                    Console.ReadKey();
                    SubMenu();
                    break;
            }

        }

        public void BackMenu()
        {
            Console.WriteLine("\n\t\t\t Pressione qualquer tecla para voltar ao menu de Produção...");
            Console.ReadKey();
            Console.Clear();
            SubMenu();
        }

        public bool ProducaoVazia()
        {
            if (producaoRepository.GetAll().Count == 0)
            {
                Console.WriteLine("\n\t\t\tNenhuma produção cadastrada no sistema.");
                BackMenu();
                return true;
            }

            return false;
        }

        public bool MateriaPrimaVazia()
        {
            if (materiaPrimaRepository.GetAll().Count == 0)
            {
                Console.WriteLine("\n\t\t\tNenhuma Materia Prima cadastrada no sistema.");
                BackMenu();
                return true;
            }

            return false;
        }

        private void EntradaDadosProducao(Producao producao)
        {

            List<ItemProducao> itemProducoes = new List<ItemProducao>();
            Produto produto = new Produto();

            if (produtoRepository.GetAll().Count == 0)
            {
                Console.WriteLine("\n\t\t\tNenhum produto cadastrado");
            }

            Console.WriteLine("\n\t\t\tDeseja cadastrar um novo produto para Produção? Sim/Não");
            string existe = Console.ReadLine().ToLower();
            if (existe == "s" || existe == "sim")
            {
                //produto = cadastroService.CadastroProduto();
                if (produto != null)
                {
                    producao.Produto = produto.Id;
                }
            }
            else if (existe == "n" || existe == "nao" || existe == "não")
            {
                do
                {
                    Console.WriteLine("\n\t\t\tInsira o nome do produto a ser localizado:");
                    string nome = Console.ReadLine();

                    produto = produtoRepository.GetByWhere(c => c.Nome == nome && c.Situacao == Situacao.Ativo);

                    if (produto != null)
                    {
                        producao.Produto = produto.Id;
                        Console.WriteLine(produto.DadosProduto());
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t\tProduto não localizado");
                    }

                } while (produto == null);

            }
            else
            {
                EntradaDadosProducao(new Producao());
            }

            if (producao.Quantidade == 0)
            {
                Console.Write("\n\t\t\tQuantidade de produtos: ");
                if (int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    producao.Quantidade = quantidade;
                }
                else
                {
                    Console.WriteLine("\n\t\t\tQuantidade inválida");
                    EntradaDadosProducao(producao);
                }
            }

            bool materiaprima;
            do
            {
                itemProducoes.Add(EntradaDadosItemProducao(new ItemProducao()));
                Console.WriteLine("\n\t\t\tDeseja adicionar mais alguma materia prima? Sim/Não");
                string confirmar = Console.ReadLine().ToLower();
                materiaprima = confirmar == "s" || confirmar == "sim";

            } while (materiaprima);

            DadosProducao(producao);

            Console.WriteLine("\n\t\t\tDeseja cadastrar a produção? Sim/Não");
            string confirma = Console.ReadLine().ToLower();

            if (confirma == "s" || confirma == "sim")
            {
                Cadastro(producao, itemProducoes);
            }
            BackMenu();

        }

        private ItemProducao EntradaDadosItemProducao(ItemProducao itemProducao)
        {

            int posicao = 0;

            int materiasprimas = 0;

            Console.WriteLine("\n\t\t\tQuais as materias primas utilizadas?");
            materiaPrimaRepository.GetAll().ForEach(c => Console.WriteLine(++posicao + "- " + c.Nome));

            itemProducao.MateriaPrima = int.Parse(Console.ReadLine());


            itemProducao.MateriaPrima = materiaPrimaRepository.entities[materiasprimas - 1].Id;


            if (itemProducao.QuantidadeMateriaPrima == 0)
            {
                Console.Write("\n\t\t\tQuantidade Materia prima: ");
                if (int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    itemProducao.QuantidadeMateriaPrima = quantidade;
                }
                else
                {
                    Console.WriteLine("\n\t\t\tQuantidade inválida");
                    EntradaDadosItemProducao(itemProducao);
                }
            }

            /*Console.WriteLine("Quantidade Materia prima");
            while (!double.TryParse(Console.ReadLine(), out double quantidadeMateriaPrima))
            {
                Console.WriteLine("Quantos produtos serão produzidos");
                itemProducao.QuantidadeMateriaPrima = quantidadeMateriaPrima.ToString();
            }*/

            return itemProducao;

        }

        private void Cadastro(Producao producao, List<ItemProducao> itemProducaos)
        {
            producaoRepository.Add(producao);

            itemProducaoRepository.AddRange(itemProducaos);

        }

        private void DadosProducao(Producao producao)
        {
            Console.WriteLine(producao.Dados());
            Console.WriteLine("\n\t\t\tProduto: ");
            Console.WriteLine((produtoRepository.GetByWhere(c => c.CodigoBarras == producao.Produto.ToString())).DadosProduto());

            List<ItemProducao> itens = itemProducaoRepository.GetAllByWhere(c => c.Id == producao.Id);


            foreach (ItemProducao itemProducao in itens)
            {
                Console.WriteLine("\n\t\t\tQuantidade Materia prima: " + itemProducao.QuantidadeMateriaPrima);
                Console.WriteLine((materiaPrimaRepository.GetByWhere(c => c.Id == itemProducao.MateriaPrima)).Dados());
            }
        }

        private void ImpressaoDoRegistro()
        {

            /*int i = 0;
            string opc = "-1";
            while (opc != "0")
            {
                Console.Clear();
                DadosProducao(cadastroService.cadastros.producao[i]);
                Console.WriteLine();
                if (i > 0)
                {
                    Console.WriteLine("1-primeiro");
                    Console.WriteLine("2-anterior");
                }
                if (i < cadastroService.cadastros.producao.Count() - 1)
                {
                    Console.WriteLine("3-proximo");
                    Console.WriteLine("4-ultimo");
                }
                Console.WriteLine("0-Sair");
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
                        break;
                    case "3":
                        if (i + 1 <= cadastroService.cadastros.producao.Count() - 1)
                            i++;
                        else
                            Console.WriteLine("Não existe registro depois deste");
                        break;
                    case "4":
                        i = cadastroService.cadastros.producao.Count() - 1;
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }

            }*/

        }

        private void Localizar()
        {

            Console.WriteLine("Digite o nome ou código de barras do produto para localizar a produção dele.");
            string busca = Console.ReadLine();

            Produto produto = produtoRepository.GetByWhere(c => c.Nome == busca || c.CodigoBarras == busca);
            Producao producao = produto != null ? producao = producaoRepository.GetByWhere(c => c.Produto.ToString() == produto.CodigoBarras) : null;

            if (producao != null)
            {
                DadosProducao(producaoRepository.GetByWhere(c => c.Produto.ToString() == produto.CodigoBarras));
            }
            else
            {
                Console.WriteLine("Nenhuma produção encontrada para esse produto\n\n" + (produto != null ? produto.DadosProduto() : string.Empty));
            }

            BackMenu();
        }

    }
}
