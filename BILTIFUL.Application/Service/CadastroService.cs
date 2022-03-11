using BILTIFUL.Application.Repository;
using BILTIFUL.Core.Entidades;
using System;
using System.Collections.Generic;

namespace BILTIFUL.Application.Service
{
    public class CadastroService
    {

        MateriaPrimaRepository materiaPrimaRepository = new MateriaPrimaRepository();

        public void SubMenu()
        {
            string opc;
            do
            {
                opc = Menu();
                switch (opc)
                {

                    case "4":
                        CadastroMateriaPrima();
                        break;
                    case "10":
                        LocalizarRegistro();
                        break;




                    case "0":
                        break;
                    default:
                        Console.WriteLine("Opção invalida!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (opc != "0");
        }
        private string Menu()
        {
            string opc;
            Console.WriteLine("\n\t\t\t\t\t________________________________________________");
            Console.WriteLine("\t\t\t\t\t|+++++++++++++++++++| MENU |+++++++++++++++++++|");
            Console.WriteLine("\t\t\t\t\t|1| - CADASTRAR CLIENTE                        |");
            Console.WriteLine("\t\t\t\t\t|2| - CADASTRAR PRODUTO                        |");
            Console.WriteLine("\t\t\t\t\t|3| - CADASTRAR FORNECEDOR                     |");
            Console.WriteLine("\t\t\t\t\t|4| - CADASTRAR MATERIA PRIMA                  |");
            Console.WriteLine("\t\t\t\t\t|5| - ADICIONAR CLIENTE COMO INADIMPLENTE      |");
            Console.WriteLine("\t\t\t\t\t|6| - ADICIONAR FORNECEDOR A LISTA DE BLOQUEADO|");
            Console.WriteLine("\t\t\t\t\t|7| - REMOVER CLIENTE DA LISTA DE INADIMPLENTE |");
            Console.WriteLine("\t\t\t\t\t|8| - REMOVER FORNECEDOR DA LISTA DE BLOQUEADO |");
            Console.WriteLine("\t\t\t\t\t|9| - MOSTRAR REGISTROS                        |");
            Console.WriteLine("\t\t\t\t\t|10| - LOCALIZAR REGISTROS                     |");
            Console.WriteLine("\t\t\t\t\t|0| - VOLTAR PARA O MENU PRINCIPAL             |");
            Console.Write("\t\t\t\t\t|______________________________________________|\n" +
                          "\t\t\t\t\t|Opção: ");
            opc = Console.ReadLine();
            return opc;
        }

        public MPrima CadastroMateriaPrima()
        {
            string nome;
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t===========CADASTRO MATERIA PRIMA===========");
            do
            {
                Console.WriteLine("\t\t\t\t\tDigite o nome da Materia Prima");
                nome = Console.ReadLine().Trim();
            } while (nome == "");

            return materiaPrimaRepository.Add(new MPrima(nome)); ;

        }


        public void LocalizarRegistro()
        {
            string opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t________________________________________________");
                Console.WriteLine("\t\t\t\t\t|++++++++++++| MENU DE LOCALIZAÇÃO |+++++++++++|");
                Console.WriteLine("\t\t\t\t\t|1| - LOCALIZAR CLIENTES                       |");
                Console.WriteLine("\t\t\t\t\t|2| - LOCALIZAR FORNECEDORES                   |");
                Console.WriteLine("\t\t\t\t\t|3| - LOCALIZAR MATERIAS PRIMAS                |");
                Console.WriteLine("\t\t\t\t\t|4| - LOCALIZAR PRODUTOS                       |");
                Console.WriteLine("\t\t\t\t\t|5| - LOCALIZAR VENDAS                         |");
                Console.WriteLine("\t\t\t\t\t|6| - LOCALIZAR COMPRAS                        |");
                Console.WriteLine("\t\t\t\t\t|7| - LOCALIZAR PRODUÇÕES                      |");
                Console.WriteLine("\t\t\t\t\t|0| - VOLTAR                                   |");
                Console.Write("\t\t\t\t\t|______________________________________________|\n" +
                              "\t\t\t\t\t|Opção: ");
                opc = Console.ReadLine();
                bool encontrado = false;
                Console.Clear();
                switch (opc)
                {


                    case "3":
                        Console.Write("\t\t\t\t\tDigite o nome que deseja localizar: ");
                        string nomeMateriaPrima = Console.ReadLine().Trim().ToLower();
                        List<MPrima> localizarmprima = materiaPrimaRepository.GetAllByWhere(p => p.Nome.ToLower() == nomeMateriaPrima);
                        if (localizarmprima != null)
                        {
                            encontrado = true;
                            localizarmprima.ForEach(p => Console.WriteLine(p.Dados()));
                        }
                        break;

                    case "0":
                        break;
                    default:
                        Console.WriteLine("\t\t\t\t\tOpção invalida");
                        break;
                }
                if (encontrado == false && opc != "0")
                    Console.WriteLine("\t\t\t\t\tRegistro não encontrado");
                Console.ReadKey();
            } while (opc != "0");
        }

        public void MostrarRegistro()
        {
            string opc;
            do
            {
                Console.Clear();
                Console.WriteLine("\n\t\t\t\t\t________________________________________________");
                Console.WriteLine("\t\t\t\t\t|+++++++++++++| MENU DE REGISTROS |++++++++++++|");
                Console.WriteLine("\t\t\t\t\t|1| - REGISTROS DE CLIENTES                    |");
                Console.WriteLine("\t\t\t\t\t|2| - REGISTROS DE FORNECEDORES                |");
                Console.WriteLine("\t\t\t\t\t|3| - REGISTROS DE MATERIAS PRIMAS             |");
                Console.WriteLine("\t\t\t\t\t|4| - REGISTROS DE PRODUTOS                    |");
                Console.WriteLine("\t\t\t\t\t|5| - REGISTROS DE VENDAS                      |");
                Console.WriteLine("\t\t\t\t\t|6| - REGISTROS DE COMPRAS                     |");
                Console.WriteLine("\t\t\t\t\t|7| - REGISTROS DE PRODUÇÃO                    |");
                Console.WriteLine("\t\t\t\t\t|0| - VOLTAR                                   |");
                Console.Write("\t\t\t\t\t|______________________________________________|\n" +
                              "\t\t\t\t\t|Opção: ");
                opc = Console.ReadLine();
                switch (opc)
                {

                    case "3":
                        break;

                    case "0":

                        break;
                    default:
                        Console.WriteLine("\t\t\t\t\tOpção invalida");
                        break;
                }
                Console.ReadKey();
            } while (opc != "0");
        }

    }
}