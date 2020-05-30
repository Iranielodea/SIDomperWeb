﻿using System;

namespace SIDomper.Dominio.ViewModel
{
    public class ClienteEspecificacaoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Item { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public string Anexo { get; set; }
        public string Nome { get; set; }
        public int CodUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int CodCliente { get; set; }
        public string NomeCliente { get; set; }
    }

    public class ClienteEspecificacaoConsultaViewModel
    {
        public int Id { get; set; }
        public int Item { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
    }
}
