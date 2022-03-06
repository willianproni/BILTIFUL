using BILTIFUL.Core.Entidades.Base;

namespace BILTIFUL.Core.Entidades
{
    public class ItemVenda : EntidadeBase
    {
        //ID produto
        public int produto { get; set; }
        public int qtd { get; set; }
        public int vunitario { get; set; }
        public int titem => qtd * vunitario;
        public ItemVenda()
        {
        }
    }
}
