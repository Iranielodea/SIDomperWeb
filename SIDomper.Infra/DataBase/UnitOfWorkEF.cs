using SIDomper.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.DataBase
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWorkEF(Contexto context)
        {
            _context = context;
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction.Rollback();
        }
    }
}
