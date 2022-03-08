using System.Collections.Generic;
using BILTIFUL.Core.Entidades.Base;

namespace BILTIFUL.Core.Entidades
{
    public class ItemVenda : EntidadeBase
    {
        //ID produto
        public string Produto { get; set; }
        public string Quantidade { get; set; }
        public string ValorUnitario { get; set; }
        public string TotalItem { get; set; }
        public ItemVenda()
        {
        }

        public ItemVenda(string id,string produto, string qtd, string totalitem)
        {
            Id = id;
            this.Produto = produto;
            this.Quantidade = qtd;
            this.ValorUnitario = totalitem;
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
        public string ConverterParaEDI()
        {
            return $"{Produto}{Quantidade}{TotalItem}";
        }
        public string DadosItemVenda()
        {
            return $"-------------------------------------------\nProduto: {Produto}\nQuantidade: {Quantidade}\nValor total: {TotalItem}\n-------------------------------------------";
        }
    }
}
