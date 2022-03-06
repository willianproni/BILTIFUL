using System.Collections.Generic;
using BILTIFUL.Core.Entidades.Base;

namespace BILTIFUL.Core.Entidades
{
    public class ItemVenda : EntidadeBase
    {
        //ID produto
        public string produto { get; set; }
        public int qtd { get; set; }
        public int vunitario { get; set; }
        public int titem => qtd * vunitario;
        public ItemVenda()
        {
        }

        public ItemVenda(string produto, int qtd, int vunitario)
        {
            this.produto = produto;
            this.qtd = qtd;
            this.vunitario = vunitario;
        }

        public Produto CodigoProdutoValido(string codproduto, List<Produto> list)
        {
            Produto aux = list.Find(i => i.cbarras == codproduto);
            
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
