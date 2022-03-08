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

    
        public ItemVenda(string id,string produto, int qtd, int vunitario)
        {
            Id = id;
            this.Produto = produto;
            this.Quantidade = qtd;
            this.ValorUnitario = vunitario;
        }


        public override string ToString()
        {
            
            return $"Código id: {Id}" +
                  $"Código produto: {Produto}"+
                  $"Código Quantidade : {Quantidade}"; 
        }

        public Produto CodigoProdutoValido(string codproduto, List<Produto> list)
        {
            Produto aux = list.Find(i => i.CodigoBarras == codproduto);

            if (aux == null)
            {
                System.Console.WriteLine("\t\t\tNenhum Produto encontrado!!");
            }
            else
            {
                System.Console.WriteLine(aux.ExibirProd());
            }
            return aux;
        }
    }
}
