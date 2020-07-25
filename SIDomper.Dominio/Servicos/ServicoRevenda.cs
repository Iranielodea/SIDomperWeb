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
    public class ServicoRevenda : IServicoRevenda
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<RevendaConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoRevenda(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<RevendaConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Revenda;
        }

        public Revenda Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Revenda model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioRevenda.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<RevendaConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "%'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Rev_Id as Id,");
            sb.AppendLine(" Rev_Codigo as Codigo,");
            sb.AppendLine(" Rev_Nome as Nome");
            sb.AppendLine(" FROM Revenda");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine(" WHERE Rev_Id > 0");
            }

            if (ativo == "A")
                sb.AppendLine(" AND Rev_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Rev_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Revenda Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var revenda = new Revenda();
            revenda.Codigo = ProximoCodigo();
            revenda.Ativo = true;
            return revenda;
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioRevenda.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public Revenda ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioRevenda.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Revenda não Cadastrada!");
            return model;
        }

        public Revenda ObterPorId(int id)
        {
            return _uow.RepositorioRevenda.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Revenda model)
        {
            if (model.Codigo <= 0)
                _uow.Notificacao.Add("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            foreach (var item in model.RevendaEmails)
            {
                if (string.IsNullOrEmpty(item.Email))
                    throw new Exception("É obrigatório o email!");
            }

            if (model.Id == 0)
                _uow.RepositorioRevenda.Salvar(model);
            else
            {
                var revenda = ObterPorId(model.Id);
                if (revenda == null)
                    revenda = new Revenda();

                AlterarEmail(revenda, model);
                ExcluirEmail(revenda, model);

                revenda.Codigo = model.Codigo;
                revenda.Nome = model.Nome;
                revenda.Ativo = model.Ativo;

                _uow.RepositorioRevenda.Salvar(revenda);
            }
            _uow.SaveChanges();
        }

        private void AlterarEmail(Revenda revenda, Revenda model)
        {
            foreach (var item in model.RevendaEmails)
            {
                if (string.IsNullOrWhiteSpace(item.Email))
                    throw new Exception("Informe o email!");

                if (item.Id == 0)
                    revenda.RevendaEmails.Add(item);
                else
                {
                    var rev = revenda.RevendaEmails.FirstOrDefault(x => x.Id == item.Id);
                    if (rev != null)
                    {
                        rev.Email = item.Email;
                    }
                }
            }
        }

        private void ExcluirEmail(Revenda revenda, Revenda model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in revenda.RevendaEmails)
            {
                var dados = model.RevendaEmails.FirstOrDefault(x => x.Id == itemBanco.Id);
                if (dados == null)
                {
                    if (itemBanco.Id > 0)
                    {
                        if (i == 1)
                            idDelecao += itemBanco.Id;
                        else
                            idDelecao += "," + itemBanco.Id;
                        i++;
                    }
                }
            }

            if (idDelecao != "")
                _uow.Executar("DELETE FROM Revenda_Email WHERE RevEm_Id in (" + idDelecao + ")");
        }
    }
}
