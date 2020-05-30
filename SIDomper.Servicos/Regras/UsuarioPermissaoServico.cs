using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Servicos.Regras
{
    public class UsuarioPermissaoServico
    {
        private readonly UsuarioPermissaoEF _rep;
        private readonly UsuarioServico _repUsuario;

        public UsuarioPermissaoServico()
        {
            _rep = new UsuarioPermissaoEF();
            _repUsuario = new UsuarioServico();
        }

        public UsuarioPermissao ObterPorId(int id)
        {
            return _rep.ObterPorId(id);
        }

        public List<UsuarioPermissao> ObterPorUsuario(int idUsuario)
        {
            return _rep.ObterPorUsuario(idUsuario).ToList();
        }

        public UsuarioPermissao ObterPorSigla(string sigla)
        {
            return _rep.ObterPorSigla(sigla);
        }

        public bool PermissaoOrcamentoUsuario(int idUsuario)
        {
            var model = ObterPorSigla("Lib_Orcamento_Usuario");
            return (model != null);
        }

        public bool PermissaoAlterarDataHoraChamado(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Chamado_Ocorr_Alt_Data_Hora");
            return (model != null);
        }

        private UsuarioPermissao PermissaoPorUsuarioSigla(int idUsuario, string sigla)
        {
            return _rep.ObterPorUsuarioSigla(idUsuario, sigla);
        }

        public bool PermissaoOcorrenciaChamadoAlterar(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Chamado_Ocorr_Alt");
            return (model != null);
        }

        public bool PermissaoOcorrenciaChamadoExcluir(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Chamado_Ocorr_Exc");
            return (model != null);
        }

        public bool PermissaoAlterarDataHoraAtividade(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Atividade_Ocorr_Alt_Data_Hora");
            return (model != null);
        }

        public bool PermissaoOcorrenciaAlterarAtividade(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Atividade_Ocorr_Alt");
            return (model != null);
        }

        public bool PermissaoOcorrenciaAtividadeExcluir(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Atividade_Ocorr_Exc");
            return (model != null);
        }

        public bool PermissaoSolicitacaoTempo(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Solicitacao_Tempo");
            return (model != null);
        }

        public bool PermissaoConferenciaTempoGeral(int idUsuario)
        {
            var model = PermissaoPorUsuarioSigla(idUsuario, "Lib_Conferencia_Tempo_Geral");
            return (model != null);
        }
    }
}
