using BILTIFUL.Core;
using BILTIFUL.Core.Controles;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BILTIFUL.ModuloProducao
{
    public class ProducaoService
    {

        CadastroService cadastroService = new CadastroService();

        public void SubMenu()
        {
            string opcao = "";

            Console.Clear();

            Console.WriteLine("1- Adicionar Produção");
            Console.WriteLine("2- Localizar Produção");
            Console.WriteLine("3- Exibir Produções cadastradas");
            Console.WriteLine("0- Voltar para menu principal");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    break;

                case "1":
                    Console.Clear();
                   if (!MateriaPrimaVazia()) EntradaDadosProducao(new Producao());
                    break;

                case "2":
                    Console.Clear();
                    if (!ProducaoVazia()) Localizar();
                    break;

                case "3":
                    Console.Clear();
                    if (!ProducaoVazia()) ImpressaoDoRegistro();
                    break;
                default:
                    Console.WriteLine("Opção inválida! ");
                    Console.ReadKey();
                    SubMenu();
                    break;
            }

        }

        public void BackMenu()
        {
            Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu de Produção...");
            Console.ReadKey();
            Console.Clear();
            SubMenu();
        }

        public bool ProducaoVazia()
        {
            if (cadastroService.cadastros.producao.Count == 0)
            {
                Console.WriteLine("Nenhuma produção cadastrada no sistema.");
                BackMenu();
                return true;
            }

            return false;
        }

        public bool MateriaPrimaVazia()
        {
            if (cadastroService.cadastros.materiasprimas.Count == 0)
            {
                Console.WriteLine("Nenhuma Materia Prima cadastrada no sistema.");
                BackMenu();
                return true;
            }

            return false;
        }

        void EntradaDadosProducao(Producao producao)
        {           

            List<ItemProducao> itemProducoes = new List<ItemProducao>();
            Produto produto = new Produto();

            if (cadastroService.cadastros.produtos.Count == 0) Console.WriteLine("Nenhum produto cadastrado");

            Console.WriteLine("Deseja cadastrar um novo produto para Produção? Sim/Não");
            string existe = Console.ReadLine().ToLower();
            if (existe == "s" || existe == "sim")
            {
                produto = cadastroService.CadastroProduto();
                if (produto != null) producao.Produto = produto.CodigoBarras;
            }
            else if (existe == "n" || existe == "nao" || existe == "não")
            {
                do
                {
                    Console.WriteLine("Insira o nome do produto a ser localizado ou digite 0 para sair:");
                    string nome = Console.ReadLine();

                    if (nome == "0") BackMenu();

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
            else EntradaDadosProducao(new Producao());

            if (producao.Quantidade == null)
            {
                Console.Write("Quantidade de produtos: ");
                if (Int32.TryParse(Console.ReadLine(), out int quantidade))
                    producao.Quantidade = quantidade.ToString();
                else
                {
                    Console.WriteLine("Quantidade inválida");
                    EntradaDadosProducao(producao);
                }
            }

            bool materiaprima;
            do
            {
                itemProducoes.Add(EntradaDadosItemProducao(new ItemProducao()));
                Console.WriteLine("Deseja adicionar mais alguma materia prima? Sim/Não");
                materiaprima = Console.ReadLine() == "s";

            } while (materiaprima);


            DadosProducao(producao);

            Console.WriteLine("Deseja cadastrar a produção? Sim/Não");
            string confirma = Console.ReadLine();

            if (confirma == "s" || confirma == "sim")
            {
                Cadastro(producao, itemProducoes);
            }
            BackMenu();

        }


        ItemProducao EntradaDadosItemProducao(ItemProducao itemProducao)
        {

            int posicao = 0;

            int materiasprimas = 0;

            Console.WriteLine("Quais as materias primas utilizadas?");
            cadastroService.cadastros.materiasprimas.ForEach(c => Console.WriteLine(++posicao + "- " + c.Nome));
            do
            {
                itemProducao.MateriaPrima = Console.ReadLine();
                if (!int.TryParse(itemProducao.MateriaPrima, out materiasprimas) || materiasprimas > cadastroService.cadastros.materiasprimas.Count || materiasprimas == 0)
                    Console.WriteLine("Item invalido!");
            } while (!int.TryParse(itemProducao.MateriaPrima, out materiasprimas) || materiasprimas > cadastroService.cadastros.materiasprimas.Count || materiasprimas == 0);

            itemProducao.MateriaPrima = cadastroService.cadastros.materiasprimas[materiasprimas - 1].Id;


            if (itemProducao.QuantidadeMateriaPrima == null)
            {
                Console.Write("Quantidade Materia prima: ");
                if (Int32.TryParse(Console.ReadLine(), out int quantidade))
                    itemProducao.QuantidadeMateriaPrima = quantidade.ToString();
                else
                {
                    Console.WriteLine("Quantidade inválida");
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

        void Cadastro(Producao producao, List<ItemProducao> itemProducaos)
        {
            producao.Id = (++cadastroService.cadastros.codigos[4]).ToString();
            cadastroService.SalvarCodigos();

            cadastroService.cadastros.producao.Add(producao);
            new Controle(producao);

            cadastroService.cadastros.itensproducao.AddRange(itemProducaos);
            itemProducaos.ForEach(c => { c.Id = producao.Id; new Controle(c); });

        }


        void DadosProducao(Producao producao)
        {
            Console.WriteLine(producao.Dados());
            Console.WriteLine("Produto: ");
            Console.WriteLine((cadastroService.cadastros.produtos.Find(c => c.CodigoBarras == producao.Produto)).ExibirProd());

            List<ItemProducao> itens = cadastroService.cadastros.itensproducao.FindAll(c => c.Id == producao.Id);


            foreach (var itemProducao in itens)
            {
                Console.WriteLine("Quantidade Materia prima: " + itemProducao.QuantidadeMateriaPrima);
                Console.WriteLine((cadastroService.cadastros.materiasprimas.Find(c => c.Id == itemProducao.MateriaPrima)).DadosMateriaPrima());
            }
        }

        void ImpressaoDoRegistro()
        {

            int i = 0;
            string opc = "-1";
            while (opc != "5")
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

            }

        }

        void Localizar()
        {

            Console.WriteLine("Digite o nome ou código de barras do produto para localizar a produção dele.");
            string busca = Console.ReadLine();

            Produto produto = cadastroService.cadastros.produtos.FirstOrDefault(c => c.Nome == busca || c.CodigoBarras == busca);
            Producao producao = produto != null ? producao = cadastroService.cadastros.producao.Find(c => c.Produto == produto.CodigoBarras) : null;

            if (producao != null) DadosProducao(cadastroService.cadastros.producao.Find(c => c.Produto == produto.CodigoBarras));
            else Console.WriteLine("Nenhuma produção encontrada para esse produto\n\n" + (produto != null ? produto.DadosProduto() : string.Empty));

            BackMenu();
        }

    }
}
