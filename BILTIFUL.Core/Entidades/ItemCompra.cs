using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemCompra : EntidadeBase, IEntidadeDAT<ItemCompra>
    {
        public DateTime DataCompra { get; set; } = DateTime.Now;
        //ID materia prima
        public int MateriaPrima { get; set; }
        public int Quantidade { get; set; }
        public float ValorUnitario { get; set; }
        public float TotalItem => Quantidade * ValorUnitario;

        public ItemCompra()
        {
        }

        public string ConverterParaDAT()
        {
            return $"{Id}{DataCompra.ToString("dd/MM/yyyy")}{MateriaPrima}{Quantidade}{ValorUnitario}{TotalItem}";
        }
        public string Dados()
        {
            return $"\t\t\t\t\tMateria prima: {MateriaPrima}\n\t\t\t\t\tQuantidade: {Quantidade}\n\t\t\t\t\tValor unitario: {ValorUnitario}\n\t\t\t\t\tTotal: {TotalItem}\n\t\t\t\t\t-------------------------------------------";
        }

        public ItemCompra ExtrairDAT(string line)
        {
            if (line == null) return null;

            Id = int.Parse(line.Substring(0, 5));
            DataCompra = DateTime.Parse(line.Substring(5, 10));
            MateriaPrima = int.Parse(line.Substring(17, 40));
            Quantidade = int.Parse(line.Substring(21, 5));
            ValorUnitario = float.Parse(line.Substring(26, 5));

            return this;
        }
    }
}
