﻿namespace SIDomper.Dominio.ViewModel
{
    public class ContaEmailViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SMTP { get; set; }
        public int Porta { get; set; }
        public bool Ativo { get; set; }
        public bool Autenticar { get; set; }
        public bool AutenticarSSL { get; set; }
    }

    public class ContaEmailConsultaViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
