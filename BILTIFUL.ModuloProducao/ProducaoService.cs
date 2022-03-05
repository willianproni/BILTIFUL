using BILTIFUL.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BILTIFUL.ModuloProducao
{
    public class ProducaoService
    {
        List<Producao> producao = new List<Producao>();
        public void SubMenu()
        {
            Console.WriteLine("1 - Adicionar");
            Console.WriteLine("2 - Remover");
        }
    }
}
