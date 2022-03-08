using BILTIFUL.Core.Entidades.Base;
using System;
using System.Collections.Generic;

namespace BILTIFUL.Core.Entidades
{
    public class Venda : EntidadeBase
    {
        public DateTime DataVenda { get; set; }=DateTime.Now;
        //CPF
        public long Cliente { get; set; }
        public string ValorTotal { get; set; }

        public Venda()
        {

        }
        public Venda(string id, long cliente, string valorTotal)
        {
            Id = id.PadLeft(5,'0');
            Cliente = cliente;
            ValorTotal = valorTotal.PadLeft(7,'0');
        }

        public Venda(string id,DateTime dataVenda, long cliente, string valorTotal)
        {
            Id = id;
            DataVenda = dataVenda;
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
        public string DadosVenda()
        {
            return $"-------------------------------------------\nId: {Id}\nCliente: {Cliente}\nValor total: {ValorTotal}\n-------------------------------------------";
        }
        public string ConverterParaEDI()
        {
            return $"{Id}{DataVenda.ToString("dd/MM/yyyy")}{Cliente.ToString().PadLeft(11,'0')}{ValorTotal}";
        }
        public string MostrarItemVenda()
        {
            return $"\n\t\tId = {Id}" +
                   $"\n\t\tCpf: {Cliente}" +
                   $"\n\t\tValor Total: {ValorTotal}";
        }
    }
}
