using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class ItemProducao : EntidadeBase
    {
        public DateTime DataProducao { get; set; } = DateTime.Now;
        //ID Materia Prima
        public string MateriaPrima { get; set; }
        public int QuantidadeMateriaPrima { get; set; }

        public ItemProducao()
        {

        }

        public ItemProducao(string id, DateTime dataProducao, string materiaPrima, int quantidadeMateriaPrima)
        {
            Id = id;
            DataProducao = dataProducao;
            MateriaPrima = materiaPrima;
            QuantidadeMateriaPrima = quantidadeMateriaPrima;
        }

        public string ConverterParaEDI()
        {
            return $"{Id}{DataProducao.ToString("dd/MM/yyyy")}{MateriaPrima}{QuantidadeMateriaPrima.ToString().PadLeft(5, '0')}";
        }

    }
}
