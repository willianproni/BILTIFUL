using System.Collections.Generic;
using BILTIFUL.Core.Entidades.Base;

namespace BILTIFUL.Core.Entidades
{
    public class ItemVenda : EntidadeBase
    {
        //ID produto
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public int ValorUnitario { get; set; }
        public int TotalItem => Quantidade * ValorUnitario;
        public ItemVenda()
        {
        }

        public ItemVenda(string produto, int qtd, int vunitario)
        {
            this.Produto = produto;
            this.Quantidade = qtd;
            this.ValorUnitario = vunitario;
        }

        public Produto CodigoProdutoValido(string codproduto, List<Produto> list)
        {
            Produto aux = list.Find(i => i.CodigoBarras == codproduto);
            
       /*     foreach (var lista in list)
            {
                if (codproduto.CompareTo(lista.cbarras) == 0)
                {
                    System.Console.WriteLine(lista.ExibirProd());
                    check = true;
                }
            }*/

            if (aux == null)
            {
                System.Console.WriteLine("Nenhum Produto encontrado!!");
            }
            else
            {
                System.Console.WriteLine(aux.ExibirProd());
            }
            return aux;
        }
    }
}
