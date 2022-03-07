using BILTIFUL.Core.Entidades.Base;
using System;
using System.Collections.Generic;

namespace BILTIFUL.Core.Entidades
{
    public class Venda : EntidadeBase
    {
        public DateTime DataVenda { get; set; }
        //CPF
        public long Cliente { get; set; }
        public int ValorTotal { get; set; }

        public Venda()
        {

        }
        public Venda(string id, long cliente, int valorTotal)
        {
            Id = id;
            DataVenda = DateTime.Now;
            Cliente = cliente;
            ValorTotal = valorTotal;
        }

        public void LocalizarVenda(string buscaid, List<Venda> list)
        {
            Venda aux = list.Find(i => i.Id == buscaid);

            if (aux == null)
            {
                Console.WriteLine("Nenhuma venda encontrada!!");
            }
            else
            {
                Console.WriteLine(aux.MostrarItemVenda());
            }
        }

        public string MostrarItemVenda()
        {
            return $"\n\t\tId = {Id}" +
                   $"\n\t\tCpf: {Cliente}" +
                   $"\n\t\tValor Total: {ValorTotal}";
        }
    }
}
