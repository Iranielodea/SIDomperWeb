using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ClienteConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoCliente(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ClienteConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Cliente;
        }

        public Cliente ObterPorId(int id)
        {
            return _uow.RepositorioCliente.find(id);
        }
    }
}
