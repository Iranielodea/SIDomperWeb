using System.Collections.Generic;

namespace SIDomper.Dominio.Interfaces
{
    public interface IRepositoryReadOnly<T> where T : class
    {
        IEnumerable<T> GetAll(string instrucaoSql);
    }
}
