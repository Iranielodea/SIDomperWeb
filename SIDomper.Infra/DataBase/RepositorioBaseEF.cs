using SIDomper.Dominio.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SIDomper.Infra.DataBase
{
    public class RepositorioBaseEF<T> : IRepositorio<T>, IDisposable where T : class
    {
        public Contexto context;

        public RepositorioBaseEF(Contexto contexto)
        {
            context = contexto;
        }

        public void Add(T entidade)
        {
            context.Set<T>().Add(entidade);
        }

        public void Update(T entidade)
        {
            context.Entry(entidade).State = EntityState.Modified;
        }

        public void AddUpdate(T entidade)
        {
            context.Set<T>().AddOrUpdate(entidade);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Deletar(T entidade)
        {
            context.Set<T>().Remove(entidade);
        }

        public void DeleteAll(Func<T, bool> predicate)
        {
            context.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => context.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public T find(params object[] key)
        {
            return context.Set<T>().Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public void Salvar(T entidade)
        {
            context.Set<T>().AddOrUpdate(entidade);
        }

        public void Attach(T entidade)
        {
            context.Set<T>().Attach(entidade);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
    }
}
