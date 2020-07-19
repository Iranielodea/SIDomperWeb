using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoFeriado : IServicoFeriado
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<Feriado> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoFeriado(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<Feriado> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Feriado;
        }

        public Feriado Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Feriado model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioFeriado.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<Feriado> Filtrar(string campo, string texto)
        {
            string sTexto = "";
            sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Fer_Id as Id,");
            sb.AppendLine(" Fer_Descricao as Descricao,");
            sb.AppendLine(" Fer_Data as Data");
            sb.AppendLine(" FROM Feriado");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Fer_Id > 0");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Feriado Novo(int idUsuario)
        {
            var feriado = new Feriado();
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            return feriado;
        }

        public Feriado ObterPorId(int id)
        {
            return _uow.RepositorioFeriado.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Feriado model)
        {
            if (string.IsNullOrEmpty(model.Descricao))
                throw new Exception("Informe a Descrição!");

            _uow.RepositorioFeriado.Salvar(model);
            _uow.SaveChanges();
        }
    }
}
