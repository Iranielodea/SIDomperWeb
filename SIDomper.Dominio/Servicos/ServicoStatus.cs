using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoStatus : IServicoStatus
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<StatusConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoStatus(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<StatusConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Status;
        }

        public Status Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Status model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioStatus.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<StatusConsulta> Filtrar(string campo, string texto, EnStatus enStatus, string ativo = "A", bool contem = true)
        {
            int tipo = (int)enStatus;

            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Sta_Id as Id,");
            sb.AppendLine(" Sta_Codigo as Codigo,");
            sb.AppendLine(" Sta_Nome as Nome,");
            sb.AppendLine(" Sta_Programa as Programa");
            sb.AppendLine(" FROM Status");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Sta_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Sta_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Sta_Ativo = 0");

            if (enStatus != EnStatus.Todos)
                sb.AppendLine(" AND Sta_Programa = " + tipo);

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public IEnumerable<Status> ListarTodos()
        {
            return _uow.RepositorioStatus.GetAll().ToList();
        }

        public List<Status> ListarVisitas(string nome)
        {
            return _uow.RepositorioStatus.Get(x => x.Programa == 2 && x.Nome.Contains(nome) && x.Ativo == true).OrderBy(o => o.Nome).ToList();
        }

        public Status Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var status = new Status
            {
                Codigo = ProximoCodigo(),
                Ativo = true
            };
            return status;
        }

        public Status ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioStatus.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Status não Cadastrado!");
            return model;
        }

        public Status ObterPorCodigo(int codigo, EnStatus enStatus)
        {
            return _uow.RepositorioStatus.ObterPorCodigo(codigo, enStatus);
        }

        public Status ObterPorId(int id)
        {
            return _uow.RepositorioStatus.find(id);
        }

        public IEnumerable<Status> ObterPorPrograma(EnStatus enStatus)
        {
            return _uow.RepositorioStatus.ObterPorPrograma(enStatus);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Status model)
        {
            if (model.Codigo <= 0)
                _uow.Notificacao.Add("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            _uow.RepositorioStatus.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioStatus.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
