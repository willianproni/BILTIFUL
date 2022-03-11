namespace BILTIFUL.Core.Entidades.Base
{
    public interface IEntidadeDAT<TEntity>
    {
        public string ConverterParaDAT();
        public string Dados();
        public TEntity ExtrairDAT(string line);
    }
}
