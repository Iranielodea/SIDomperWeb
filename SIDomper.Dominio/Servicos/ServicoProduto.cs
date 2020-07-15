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
    public class ServicoProduto : IServicoProduto
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ProdutoConsulta> _repositoryReadOnly;
        private readonly EnProgramas _tipoPrograma;

        public ServicoProduto(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ProdutoConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _tipoPrograma = EnProgramas.Produto;
        }

        public void Excluir(Produto model)
        {
            _uow.RepositorioProduto.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ProdutoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Prod_Id as Id,");
            sb.AppendLine(" Prod_Codigo as Codigo,");
            sb.AppendLine(" Prod_Nome as Nome,");
            sb.AppendLine(" Prod_Ativo as Ativo");
            sb.AppendLine(" FROM Produto");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine(" WHERE Prod_Id > 0");

            if (ativo == "A")
                sb.AppendLine(" AND Prod_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Prod_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public IQueryable<Produto> Listar(string nome)
        {
            return _uow.RepositorioProduto.Get(x => x.Nome.Contains(nome) && x.Ativo == true).OrderBy(b => b.Nome);
        }

        public Produto ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioProduto.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Produto não Cadastrado");
            return model;
        }

        public Produto ObterPorId(int id)
        {
            return _uow.RepositorioProduto.find(id);
        }

        public int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioProduto.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public void Salvar(Produto model)
        {
            if (model.Codigo <= 0)
                throw new Exception("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");
            
            _uow.RepositorioProduto.Salvar(model);
            _uow.SaveChanges();
        }
    }
}
