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
    public class ServicoTipo : IServicoTipo
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<TipoConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoTipo(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<TipoConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Tipo;
        }

        public Tipo Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Tipo model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioTipo.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<TipoConsulta> Filtrar(string campo, string texto, EnTipos enTipos, string ativo = "A", bool contem = true)
        {
            int tipo = (int)enTipos;

            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Tip_Id as Id,");
            sb.AppendLine(" Tip_Codigo as Codigo,");
            sb.AppendLine(" Tip_Nome as Nome,");
            sb.AppendLine(" Tip_Programa as Programa");
            sb.AppendLine(" FROM Tipo");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Tip_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Tip_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Tip_Ativo = 0");

            if (enTipos != EnTipos.Todos)
                sb.AppendLine(" AND Tip_Programa = " + tipo);

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public IQueryable<Tipo> Listar(string nome)
        {
            return _uow.RepositorioTipo.Get(x => x.Nome.Contains(nome)).OrderBy(x => nome);
        }

        public List<Tipo> ListarTipos(string nome, EnTipos enTipos)
        {
            int tipo = (int)enTipos;
            return _uow.RepositorioTipo.Get(x => x.Programa == tipo && x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome).ToList();
        }

        public Tipo Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var tipo = new Tipo();
            tipo.Codigo = ProximoCodigo();
            tipo.Ativo = true;
            return tipo;
        }

        public Tipo ObterPorCodigo(int codigo, EnTipos enTipos)
        {
            var model = _uow.RepositorioTipo.First(x => x.Codigo == codigo && x.Programa == (int)enTipos);
            if (model == null)
                throw new Exception("Registro não Encontrado!");
            if (model.Ativo == false)
                throw new Exception("Tipo Inativo!");

            return model;
        }

        public Tipo ObterPorId(int id)
        {
            return _uow.RepositorioTipo.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Tipo model)
        {
            if (model.Codigo <= 0)
                _uow.Notificacao.Add("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            _uow.RepositorioTipo.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioTipo.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
