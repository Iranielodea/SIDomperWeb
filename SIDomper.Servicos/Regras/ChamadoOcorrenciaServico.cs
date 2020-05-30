using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class ChamadoOcorrenciaServico
    {
        private readonly ChamadoOcorrenciaEF _rep;
        private readonly UsuarioServico _repUsuario;
        private readonly UsuarioPermissaoServico _repUsuarioPermissao;

        public ChamadoOcorrenciaServico()
        {
            _rep = new ChamadoOcorrenciaEF();
            _repUsuario = new UsuarioServico();
            _repUsuarioPermissao = new UsuarioPermissaoServico();
        }

        public ChamadoOcorrencia Novo(int idUsuario)
        {
            var ocorrencia = new ChamadoOcorrencia();
            ocorrencia.Usuario = _repUsuario.ObterPorId(idUsuario);
            return ocorrencia;
        }

        public ChamadoOcorrencia ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public IEnumerable<ChamadoOcorrencia> ObterPorChamado(int idChamado)
        {
            var result = _rep.ObterPorChamado(idChamado).ToList();
            return result;
        }

        public IEnumerable<ChamadoOcorrenciaConsulta> ObterConsultaPorChamado(int idChamado)
        {
            var resultado = _rep.ObterConsultaPorChamado(idChamado).ToList();
            return resultado;
        }

        public bool UsuarioIgualCadastro(int id, int usuarioId, int tipoOperacao)
        {
            bool resultado = false;
            if (tipoOperacao == 2 || tipoOperacao == 3)
            {
                var model = ObterPorId(id);
                if (model != null)
                {
                    resultado = (model.UsuarioId == usuarioId);
                }
            }
            return resultado;
        }

        public void Excluir(int id, bool commit = true)
        {
            var model = new ChamadoOcorrencia();
            model = ObterPorId(id);
            if (model != null)
            {
                _rep.Excluir(model);
                if (commit)
                    _rep.Commit();
            }
        }

        public void Salvar(ChamadoOcorrencia model, bool commit = true)
        {
            if (model.Data < model.Chamado.DataAbertura)
                throw new Exception("Data de Ocorrência menor que Data de Abertura!");
            if (model.HoraInicio > model.HoraFim)
                throw new Exception("Hora Inicial maior que Hora Final na Ocorrência!");
            if (model.UsuarioId == 0)
                throw new Exception("Informe o Usuário!");
            if (string.IsNullOrWhiteSpace(model.DescricaoTecnica) && string.IsNullOrWhiteSpace(model.DescricaoSolucao))
                throw new Exception("Informe uma descrição!");

            double HoraInicio = Funcoes.Horas.HoraToDecimal(model.HoraInicio.ToString());
            double HoraFim = Funcoes.Horas.HoraToDecimal(model.HoraFim.ToString());
            model.TotalHoras = HoraFim - HoraInicio;

            _rep.Salvar(model);

            if (commit)
                _rep.Commit();
        }

        public bool PermissaoChamadoOcorrenciaDataHora(int idUsuarioGravado, ref string mensagem, EnumChamado tipo, Usuario usuario)
        {
            if (usuario.Adm)
            {
                mensagem = "OK";
                return true;
            }

            if (usuario.Id != idUsuarioGravado)
            {
                mensagem = "Somente o mesmo usuário poderá alterar!";
                return false;
            }

            bool permissao;

            if (tipo == EnumChamado.Chamado)
                permissao = _repUsuarioPermissao.PermissaoAlterarDataHoraChamado(usuario.Id);
            else
                permissao = _repUsuarioPermissao.PermissaoAlterarDataHoraAtividade(usuario.Id);

            mensagem = (permissao) ? "OK" : "Usuário sem Permissão!";

            return permissao;
        }

        public bool PermissaoChamadoOcorrenciaAlterar(int idUsuarioGravado, int idOcorrencia, EnumChamado tipo, Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            bool permissao = true;

            if (tipo == EnumChamado.Chamado)
                permissao = _repUsuarioPermissao.PermissaoOcorrenciaChamadoAlterar(usuario.Id);
            else
                permissao = _repUsuarioPermissao.PermissaoOcorrenciaAlterarAtividade(usuario.Id);

            if (permissao)
            {
                if (idOcorrencia > 0)
                    permissao = (usuario.Id == idUsuarioGravado);
            }
            return permissao;
        }

        public bool PermissaoChamadoOcorrenciaExcluir(int idUsuarioGravado, int idOcorrencia, EnumChamado tipo, Usuario usuario)
        {
            if (usuario.Adm)
                return true;

            bool permissao = true;

            if (tipo == EnumChamado.Chamado)
                permissao = _repUsuarioPermissao.PermissaoOcorrenciaChamadoExcluir(usuario.Id);
            else
                permissao = _repUsuarioPermissao.PermissaoOcorrenciaAtividadeExcluir(usuario.Id);

            if (permissao)
            {
                if (idOcorrencia > 0)
                    permissao = (usuario.Id == idUsuarioGravado);
            }
            return permissao;
        }

        public void ExcluirUmaOcorrencia(Repositorio<Chamado> repositorio, ChamadoOcorrencia model, bool commit = true)
        {
            _rep.ExcluirUmaOcorrencia(repositorio, model.Id);
            if (commit)
                _rep.Commit();
        }

        public List<ProblemaSolucao> ProblemaSolucao(string texto, int idUsuario, int idCliente, EnumChamado enumChamado)
        {
            return _rep.ProblemaSolucao(texto, idUsuario, idCliente, EnumChamado.Chamado).ToList();
        }
    }
}
