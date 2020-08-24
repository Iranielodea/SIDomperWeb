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
    public class ServicoDepartamento : IServicoDepartamento
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepositoryReadOnly<DepartamentoConsulta> _repositoryReadOnly;
        private readonly EnProgramas _enProgramas;

        public ServicoDepartamento(IUnitOfWork unitOfWork,
           IRepositoryReadOnly<DepartamentoConsulta> repositoryReadOnly)
        {
            _uow = unitOfWork;
            _repositoryReadOnly = repositoryReadOnly;
            _enProgramas = EnProgramas.Departamento;
        }

        public Departamento Duplicar(Departamento model)
        {
            var departamento = _uow.RepositorioDepartamento.Duplicar(model);
            _uow.SaveChanges();

            return departamento;
        }

        public Departamento Editar(int id, int idUsuario, ref string mensagem)
        {
            mensagem = "OK";
            if (!_uow.RepositorioUsuario.PermissaoEditar(idUsuario, _enProgramas))
                mensagem = Mensagem.UsuarioSemPermissao;

            return ObterPorId(id);
        }

        public void Excluir(Departamento model, int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoExcluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            _uow.RepositorioDepartamento.Deletar(model);
            _uow.SaveChanges();
        }

        public IEnumerable<DepartamentoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            string sTexto = "";

            sTexto = "'" + texto + "'";
            if (contem)
                sTexto = "'%" + texto + "%'";

            var sb = new StringBuilder();

            sb.AppendLine("  SELECT");
            sb.AppendLine(" Dep_Id as Id,");
            sb.AppendLine(" Dep_Codigo as Codigo,");
            sb.AppendLine(" Dep_Nome as Nome");
            sb.AppendLine(" FROM Departamento");

            if (!string.IsNullOrWhiteSpace(texto))
                sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
            else
            {
                sb.AppendLine("WHERE Dep_Id > 0");
            }

            if (ativo == "A")
                sb.AppendLine(" AND Dep_Ativo = 1");

            if (ativo == "I")
                sb.AppendLine(" AND Dep_Ativo = 0");

            sb.AppendLine(" ORDER BY " + campo);
            return _repositoryReadOnly.GetAll(sb.ToString());
        }

        public Departamento Novo(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoIncluir(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);

            var model = new Departamento();
            model.Ativo = true;
            model.AgencamentoQuadro = false;
            model.AtividadeAbertura = false;
            model.AtividadeOcorrencia = false;
            model.AtividadeQuadro = false;
            model.AtividadeStatus = false;
            model.ChamadoAbertura = false;
            model.ChamadoOcorrencia = false;
            model.ChamadoQuadro = false;
            model.ChamadoStatus = false;
            model.SolicitaAbertura = false;
            model.SolicitaAnalise = false;
            model.SolicitacaoOcorrenciaGeral = false;
            model.SolicitacaoOcorrenciaTecnica = false;
            model.SolicitacaoQuadro = false;
            model.SolicitacaoStatus = false;
            model.Codigo = ProximoCodigo();

            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 1, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 2, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 3, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 4, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 6, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 100, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 101, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 102, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 103, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 104, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 105, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 106, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 107, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 108, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 109, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 110, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 111, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 112, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 114, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 115, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 116, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 117, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 118, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 119, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 120, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 121, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 122, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 123, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 124, Relatorio = true });
            model.DepartamentoAcessos.Add(new DepartamentoAcesso { Acesso = false, Editar = true, Excluir = true, Incluir = true, Programa = 125, Relatorio = true });
            return model;
        }

        public Departamento ObterPorCodigo(int codigo)
        {
            var model = _uow.RepositorioDepartamento.First(x => x.Codigo == codigo);
            if (model == null)
                throw new Exception("Departamento não Cadastrado!");
            if (model.Ativo == false)
                throw new Exception("Departamento Inativa!");
            return model;
        }

        public Departamento ObterPorId(int id)
        {
            return _uow.RepositorioDepartamento.find(id);
        }

        public void Relatorio(int idUsuario)
        {
            if (!_uow.RepositorioUsuario.PermissaoRelatorio(idUsuario, _enProgramas))
                throw new Exception(Mensagem.UsuarioSemPermissao);
        }

        public void Salvar(Departamento model)
        {
            if (model.Codigo <= 0)
                _uow.Notificacao.Add("Informe o Código!");

            if (string.IsNullOrWhiteSpace(model.Nome))
                _uow.Notificacao.Add("Informe o Nome!");

            if (!_uow.IsValid())
                throw new Exception(_uow.RetornoNotificacao());

            if (model.Id == 0)
                _uow.RepositorioDepartamento.Salvar(model);
            else
            {
                var departamento = _uow.RepositorioDepartamento.find(model.Id);
                if (departamento == null)
                    departamento = new Departamento();

                AlterarEmail(departamento, model);
                ExcluirEmail(departamento, model);
                AlterarAcesso(departamento, model);

                departamento.AgencamentoQuadro = model.AgencamentoQuadro;
                departamento.AtividadeAbertura = model.AtividadeAbertura;
                departamento.AtividadeOcorrencia = model.AtividadeOcorrencia;
                departamento.AtividadeQuadro = model.AtividadeQuadro;
                departamento.AtividadeStatus = model.AtividadeStatus;
                departamento.Ativo = model.Ativo;
                departamento.ChamadoAbertura = model.ChamadoAbertura;
                departamento.ChamadoOcorrencia = model.ChamadoOcorrencia;
                departamento.ChamadoQuadro = model.ChamadoQuadro;
                departamento.ChamadoStatus = model.ChamadoStatus;
                departamento.Codigo = model.Codigo;
                departamento.HoraFinal = model.HoraFinal;
                departamento.HoraInicial = model.HoraInicial;
                departamento.MostrarAnexos = model.MostrarAnexos;
                departamento.Nome = model.Nome;
                departamento.SolicitaAbertura = model.SolicitaAbertura;
                departamento.SolicitaAnalise = model.SolicitaAnalise;
                departamento.SolicitacaoOcorrenciaGeral = model.SolicitacaoOcorrenciaGeral;
                departamento.SolicitacaoOcorrenciaRegra = model.SolicitacaoOcorrenciaRegra;
                departamento.SolicitacaoOcorrenciaTecnica = model.SolicitacaoOcorrenciaTecnica;
                departamento.SolicitacaoQuadro = model.SolicitacaoQuadro;
                departamento.SolicitacaoStatus = model.SolicitacaoStatus;
                departamento.AgencamentoQuadro = model.AgencamentoQuadro;

                _uow.RepositorioDepartamento.Salvar(departamento);
            }
            _uow.SaveChanges();
        }

        private void AlterarEmail(Departamento departamento, Departamento model)
        {
            foreach (var item in model.DepartamentosEmail)
            {
                if (item.Id == 0)
                {
                    if (string.IsNullOrWhiteSpace(item.Email))
                        throw new Exception("Informe o email!");

                    departamento.DepartamentosEmail.Add(item);
                }
                else
                {
                    var temp = departamento.DepartamentosEmail.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Email = item.Email;
                    }
                }
            }
        }

        private void ExcluirEmail(Departamento departamento, Departamento model)
        {
            string idDelecao = "";
            int i = 1;
            foreach (var itemBanco in departamento.DepartamentosEmail)
            {
                var dados = model.DepartamentosEmail.FirstOrDefault(x => x.Id == itemBanco.Id);
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
                _uow.Executar("DELETE FROM Departamento_Email WHERE DepEm_Id in (" + idDelecao + ")");
        }

        private void AlterarAcesso(Departamento departamento, Departamento model)
        {
            foreach (var item in model.DepartamentoAcessos)
            {
                if (item.Id == 0)
                {
                    departamento.DepartamentoAcessos.Add(item);
                }
                else
                {
                    var temp = departamento.DepartamentoAcessos.FirstOrDefault(x => x.Id == item.Id);
                    if (temp != null)
                    {
                        temp.Acesso = item.Acesso;
                        temp.Editar = item.Editar;
                        temp.Excluir = item.Excluir;
                        temp.Incluir = item.Incluir;
                        temp.Programa = item.Programa;
                        temp.Relatorio = item.Relatorio;
                    }
                }
            }
        }

        private int ProximoCodigo()
        {
            try
            {
                return _uow.RepositorioDepartamento.GetAll().Max(x => x.Codigo) + 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
