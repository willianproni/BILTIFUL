using System;
using System.Collections.Generic;
using BILTIFUL.Core.Entidades;

namespace BILTIFUL.ModuloVenda
{
    public class VendaService
    {
        List<Venda> vendas = new List<Venda>();
        public void SubMenu()
        {
            Console.WriteLine("1 - Adicionar");
            Console.WriteLine("2 - Remover");
        }
        public void AdicionandoVenda()
        {
            vendas.Add(new Venda());
        }

        public Venda CadastrarVenda()
        {
            Console.WriteLine("Data venda: ");
            DateTime datavenda = DateTime.Now;
            Console.WriteLine("Digite o Cpf do cliente: ");
            return new Venda();
        }

        public Venda ItemVenda()
        {
            Console.WriteLine("Digite o Código do Produto: ");
            int codigoProd = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Quantidade do Produto: ");
            return new Venda();

        }

        public void ExibirVendas(List<Venda> list)
        {
            list.ForEach(i => Console.WriteLine(i));
        }
    }
}
