using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemProducao : EntidadeBase, IEntidadeDAT<ItemProducao>
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID Materia Prima
        public int MateriaPrima { get; set; }
        public float QuantidadeMateriaPrima { get; set; }

        public ItemProducao()
        {

        }


        public string ConverterParaDAT()
        {
            return $"{Id.ToString().PadLeft(5, '0')}{DataProducao.ToString("dd/MM/yyyy")}{MateriaPrima}{QuantidadeMateriaPrima.ToString().PadLeft(5, '0')}";
        }
        public string Dados()
        {
            return $"-------------------------------------------\nMateria prima: {MateriaPrima}\nQuantidade de materia prima{QuantidadeMateriaPrima}\n-------------------------------------------";
        }

        public ItemProducao ExtrairDAT(string line)
        {
            if (line == null) return null;

            Id = int.Parse(line.Substring(0, 5));
            DataProducao = DateTime.Parse(line.Substring(5, 10));
            MateriaPrima = int.Parse(line.Substring(10, 5));
            QuantidadeMateriaPrima = float.Parse(line.Substring(36, 10));

            return this;
        }
    }
}
