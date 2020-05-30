using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class DepartamentoServico
    {
        private readonly DepartamentoEF _rep;
        private readonly EnProgramas _tipoPrograma;
        private readonly UsuarioServico _repUsuario;

        public DepartamentoServico()
        {
            _rep = new DepartamentoEF();
            _repUsuario = new UsuarioServico();
            _tipoPrograma = EnProgramas.Departamento;
        }

        public IEnumerable<DepartamentoConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true)
        {
            return _rep.Filtrar(campo, texto, ativo, contem);
        }

        public Departamento Novo(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Incluir);
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
            model.Codigo = _rep.ProximoCodigo();

            model.DepartamentoAcessos.Add(new DepartamentoAcesso {Acesso = false, Editar = true, Excluir = true, Incluir=true, Programa = 1, Relatorio = true });
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
            return model;
        }

        public Departamento ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public Departamento ObterPorCodigo(int codigo)
        {
            var model = _rep.ObterPorCodigo(codigo);

            if (model != null)
            {
                if (model.Ativo == false)
                    throw new Exception("Registro Inativo!");
            }
            return model;
        }

        public Departamento Editar(int idUsuario, int id, ref string permissaoMensagem)
        {
            bool permissao = _repUsuario.PermissaoUsuario(idUsuario, _tipoPrograma, EnTipoManutencao.Editar);
            permissaoMensagem = permissao ? "OK" : "Usuário sem permissão!";
            return _rep.ObterPorId(id);
        }

        public string RetornarEmail(Departamento departamento)
        {
            string email = "";
            foreach (var item in departamento.DepartamentosEmail)
            {
                if (email == "")
                    email = email + item.Email;
                else
                    email = email + ";" + item.Email;
            }

            return email;
        }

        public void Salvar(Departamento model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Nome))
                    throw new Exception("É obrigatório o nome");
                if (model.Codigo <= 0)
                    throw new Exception("É obrigatório o código");

                if (model.Id == 0)
                    _rep.Salvar(model);
                else
                {
                    var departamento = _rep.ObterPorId(model.Id);
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

                    _rep.Salvar(departamento);
                }
                _rep.Commit();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                _rep.ExcluirItem(idDelecao);
        }

        public void AdicionarEmail(DepartamentoEmail model)
        {
            _rep.AdicionarEmail(model);
        }

        //public void AlterarEmail(Departamento model, DepartamentoEmail email)
        //{
        //    if (string.IsNullOrWhiteSpace(email.Email))
        //        throw new Exception("Informe o email!");

        //    _rep.AlterarEmail(model, email);
        //}

        //public void ExcluirEmail(int id)
        //{
        //    if (id > 0)
        //        _rep.ExcluirEmail(id);
        //}

        public void Excluir(int idUsuario, Departamento model)
        {
            _repUsuario.PermissaoMensagem(idUsuario, _tipoPrograma, EnTipoManutencao.Excluir);

            _rep.Excluir(model);
            _rep.Commit();
        }

        public Departamento Duplicar(int idUsuario, Departamento model)
        {
            _rep.Duplicar(model);
            _rep.Commit();

            model = ObterPorId(model.Id);

            return model;
        }

        public void AlterarAcesso(Departamento model, DepartamentoAcesso acesso)
        {
            _rep.AlterarAcesso(model, acesso);
        }

        public void Relatorio(int idUsuario)
        {
            _repUsuario.PermissaoMensagem(idUsuario, EnProgramas.Departamento, EnTipoManutencao.Imprimir);
        }
    }
}
