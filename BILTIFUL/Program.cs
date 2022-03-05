using System;
using System.Collections.Generic;
using System.IO;
using BILTIFUL.Core.Controle;
using BILTIFUL.Core.Entidades;
using BILTIFUL.Core.Entidades.Enums;

namespace BILTIFUL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Controle controle = new Controle(new Cliente());

            Console.WriteLine(new Cliente(1221,"Fabio", DateTime.Now, Sexo.Masculino, Situacao.Ativo).ConverterParaEDI());
        }
    }
}
