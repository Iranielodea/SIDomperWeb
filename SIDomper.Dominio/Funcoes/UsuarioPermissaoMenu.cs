namespace SIDomper.Dominio.Funcoes
{
    public static class UsuarioPermissaoMenu
    {
        public static bool Lib_Solicitacao_Ocorr_Geral_Alt { get; set; }
        public static bool Lib_Solicitacao_Ocorr_Geral_Exc { get; set; }
        public static bool Lib_Solicitacao_Ocorr_Tecnica_Alt { get; set; }
        public static bool Lib_Solicitacao_Ocorr_Tecnica_Exc { get; set; }
        public static bool Lib_Solicitacao_Ocorr_Regra_Alt { get; set; }
        public static bool Lib_Solicitacao_Ocorr_Regra_Exc { get; set; }
        public static bool Lib_Solicitacao_Tempo { get; set; }

        public static bool Lib_Chamado_Ocorr_Alt_Data_Hora { get; set; }
        public static bool Lib_Chamado_Ocorr_Alt { get; set; }
        public static bool Lib_Chamado_Ocorr_Exc { get; set; }

        public static bool Lib_Atividade_Ocorr_Alt_Data_Hora { get; set; }
        public static bool Lib_Atividade_Ocorr_Alt { get; set; }
        public static bool Lib_Atividade_Ocorr_Exc { get; set; }

        public static bool Lib_Conferencia_Tempo_Geral { get; set; }
        public static bool Lib_Orcamento_Alt_Situacao { get; set; }
        public static bool Lib_Orcamento_Usuario { get; set; }
    }
}
