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
    public class ServicoCategoria : IServicoCategoria
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<CategoriaConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoCategoria(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<CategoriaConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Categoria;
        }

        public Categoria Novo(int idUsuario)
        {
            _uow.RepositorioUsuario.PermitirIncluir(idUsuario, _enProgramas);
            var categoria = new Categoria
            {
                Codigo = ProximoCodigo(),
                Ativo = true
            };
            return categoria;
        }

        public Categoria Editar(int id, int idUsuario, ref string mensagem)
        {
            _uow.RepositorioUsuario.PermitirEditar(idUsuario, _enProgramas, ref mensagem);

            return ObterPorId(id);
        }

        public void Excluir(Categoria model, int idUsuario)
        {
            _uow.RepositorioUsuario.PermitirExcluir(idUsuario, _enProgramas);

            _uow.RepositorioCategoria.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<CategoriaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true, int idCliente = 0)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Cat_Id as Id,");
            sb.AppendLine(" Cat_Codigo as Codigo,");
            sb.AppendLine(" Cat_Nome as Nome");
            sb.AppendLine(" FROM Categoria");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Cat_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Cat_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Cat_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public IQueryable<Categoria> Listar(string nome)
        {
            return _uow.RepositorioCategoria.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public Categoria ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioCategoria.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Categoria não Cadastrada");
            if (model.Ativo == false)
                throw new Exception("Categoria Inativa!");
            return model;
        }

        public Categoria ObterPorId(int id)
        {
            return _uow.RepositorioCategoria.find(id);
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioCategoria.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public void Salvar(Categoria model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");
            
            _uow.RepositorioCategoria.Salvar(model);
            _uow.SaveChanges();
        }

        public void Relatorio(int idUsuario)
        {
            _uow.RepositorioUsuario.PermitirRelatorio(idUsuario, _enProgramas);
        }
    }
}
