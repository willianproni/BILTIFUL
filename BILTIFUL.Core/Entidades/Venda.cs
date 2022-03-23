﻿using BILTIFUL.Core.Entidades.Base;
using System;
using System.Collections.Generic;

namespace BILTIFUL.Core.Entidades
{
    public class Venda : EntidadeBase
    {
        public DateTime DataVenda { get; set; }=DateTime.Now;
        //CPF
        public string Cliente { get; set; }
        public string ValorTotal { get; set; }

        public Venda()
        {

        }

        public Venda(string cliente)
        {
            Cliente = cliente;
        }

        public Venda(string id, string cliente, string valorTotal)
        {
            Id = id.PadLeft(5,'0');
            Cliente = cliente;
            ValorTotal = valorTotal.PadLeft(7,'0');
        }

        public Venda(string id,DateTime dataVenda, string cliente, string valorTotal)
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
            return $"-------------------------------------------\nId: {Id}\nCliente: {Cliente}\nValor total: {float.Parse(ValorTotal.Insert(3, ","))}\n-------------------------------------------";
        }
        public string ConverterParaEDI()
        {
            return $"{Id}{DataVenda.ToString("dd/MM/yyyy")}{Cliente.ToString().PadLeft(11,'0')}{ValorTotal}";
        }
        public string MostrarItemVenda()
        {
            return $"\n\t\t\t\t\tId = {Id}" +
                   $"\n\t\t\t\t\tCpf: {Cliente}" +
                   $"\n\t\t\t\t\tValor Total: {float.Parse(ValorTotal.Insert(3, ","))}";
        }
    }
}
