﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIDomper.Dominio.Constantes;
using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoParametro : IServicoParametro
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<ParametroConsulta> _repositoryReadOnly;
        private readonly IRepositoryReadOnly<ParametroTitulosQuadroViewModel> _repositoryTitulosQuadroReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoParametro(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<ParametroConsulta> repositoryReadOnly,
           IRepositoryReadOnly<ParametroTitulosQuadroViewModel> repositoryTitulosQuadroReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Parametro;
            _repositoryTitulosQuadroReadOnly = repositoryTitulosQuadroReadOnly;
        }

        public Parametro Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Parametro model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioParametro.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<ParametroConsulta> Filtrar(string campo, string texto, bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Par_Id as Id,");
            sb.AppendLine(" Par_Codigo as Codigo,");
            sb.AppendLine(" Par_Nome as Nome,");
            sb.AppendLine(" Par_Programa as Programa,");
            sb.AppendLine(" Par_Valor as Valor");
            sb.AppendLine(" FROM Parametros");

            if (!string.IsNullOrWhiteSpace(texto) && (texto != "0"))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
                sb.AppendLine("WHERE Par_Id > 0");

            sb.AppendLine(" ORDER BY " + campo);

            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public IEnumerable<Parametro> ListarTodos()
        {
            return _uow.RepositorioParametro.GetAll();
        }

        public Parametro Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var parametro = new Parametro
            {
                Codigo = ProximoCodigo()
            };
            return parametro;
        }

        public Parametro ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioParametro.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Parâmetro não Cadastrado!");
            return model;
        }

        public Parametro ObterPorId(int id)
        {
            return _uow.RepositorioParametro.find(id);
        }

        public Parametro ObterPorParametro(int codigo, int programa)
        {
            return _uow.RepositorioParametro.ObterPorParametro(codigo, programa);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Parametro model)
        {
            if (model.Codigo < 0)
                _uow.Notificacao.Add("O Código não pode ficar Negativo!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (string.IsNullOrWhiteSpace(model.Valor))
                _uow.Notificacao.Add("Informe o Valor do Parâmetro!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            _uow.RepositorioParametro.Salvar(model);
            _uow.SaveChanges();
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioParametro.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }

        public IEnumerable<ParametroTitulosQuadroViewModel> BuscarTitulosQuadro()
        {
            /*
             * No ONShow do quadro fazer duas requisições:
             * =====================================
             * buscar as permissoes retornar boolean
             * permissao para: chamadoQuadro, Atividade, Solicitacao, agendamento, recados
             * Coluna Tempo
             * Permissao Solicitacao, mostar as opções do PopMenu das solicitações
             * Grades Altura e lagura
             * controle titulo tempo nas grids
             * =====================================
             * Se tem Recados Então
             *      Abrir tela dos recados
             * Se não
             *      Abrir tela dos Chamados
             * Abrir o Timer intervalo de 60000 - a cada 1 minuto
             */
            var resultado = _uow.RepositorioParametro.BuscarTitulosQuadro();
            return _repositoryTitulosQuadroReadOnly.GetAll(resultado);
        }
    }
}
