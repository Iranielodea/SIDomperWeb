using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoClienteEspecificacao : IServicoClienteEspecificacao
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ClienteEspecifiacaoConsulta> _repositoryReadOnly;
        public ServicoClienteEspecificacao(IUnitOfWork uow, 
            IRepositoryReadOnly<ClienteEspecifiacaoConsulta> repositoryReadOnly)
        {
            _uow = uow;
            _repositoryReadOnly = repositoryReadOnly;
        }

        public void Excluir(ClienteEspecifiacao model)
        {
            if (model.Id > 0)
            {
                var especificacao = _uow.RepositorioClienteEspecificacao.find(model.Id);
                _uow.RepositorioClienteEspecificacao.Deletar(especificacao);
            }
        }

        public IEnumerable<ClienteEspecifiacaoConsulta> Filtrar(int idCliente)
        {
            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" CliEsp_Id as Id,");
            sb.AppendLine(" CliEsp_Item as Item,");
            sb.AppendLine(" CliEsp_Data as Data,");
            sb.AppendLine(" CliEsp_Nome as Nome");
            sb.AppendLine(" FROM Cliente_Especificacao");
            sb.AppendLine(" WHERE CliEsp_Cliente = " + idCliente);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public ClienteEspecifiacao ObterPorId(int id)
        {
            return _uow.RepositorioClienteEspecificacao.find(id);
        }

        public void Salvar(ClienteEspecifiacao model)
        {
            if (model.UsuarioId == 0)
                _uow.Notificacao.Add("Informe o usuário!");
            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o nome!");
            if (string.IsNullOrWhiteSpace(model.Descricao))
                _uow.Notificacao.Add("Informe a descrição!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            if (model.Id == 0)
                model.Item = ProximoNumero(model.ClienteId);

            _uow.RepositorioClienteEspecificacao.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoNumero(int clienteId)
        {
            try
            {
                return _uow.RepositorioClienteEspecificacao.GetAll()
                    .Where(x => x.ClienteId == clienteId).Max(x => x.Item) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
