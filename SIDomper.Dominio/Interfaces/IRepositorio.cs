using System;
using System.Linq;
using System.Linq.Expressions;

namespace SIDomper.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T find(params object[] key);
        T First(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void AddUpdate(T entidade);
        void Salvar(T entidade);
        void Deletar(T entidade);
        void DeleteAll(Func<T, bool> predicate);
        void Commit();
        void Dispose();
    }
}
