namespace SIDomper.Dominio.Interfaces
{
    public interface IRepositoryWriteOnly
    {
        int Insert(string instrucaoSql, object entity);
        void Update(string instrucaoSql, object entity);
    }
}
