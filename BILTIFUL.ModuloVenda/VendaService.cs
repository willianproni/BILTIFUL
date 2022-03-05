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
    }
}
