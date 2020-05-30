﻿using System;

namespace SIDomper.Dominio.ViewModel
{
    public class VersaoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public int? ProdutoId { get; set; }
        public int? ModuloId { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public string Anexo { get; set; }
        public int CodUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public int? CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public int CodTipo { get; set; }
        public string NomeTipo { get; set; }
        public int CodStatus { get; set; }
        public string NomeStatus { get; set; }
        public int CodModulo { get; set; }
        public string NomeModulo { get; set; }
        public int StatusIdParam { get; set; }
        public int StatusCodigoParam { get; set; }
        public string StatusNomeParam { get; set; }
        public string VersaoStr { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataLiberacao { get; set; }
    }

    public class VersaoConsultaViewModel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataLiberacao { get; set; }
        public string VersaoStr { get; set; }
        public string Descricao { get; set; }
        public string NomeTipo { get; set; }
        public string NomeStatus { get; set; }
        public string NomeUsuario { get; set; }
    }

    public class VersaoFiltroViewModel
    {
        public int Id { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string DataLiberacaoInicial { get; set; }
        public string DataLiberacaoFinal { get; set; }
        public string UsuarioId { get; set; }
        public string TipoId { get; set; }
        public string StatusId { get; set; }
        public string ProdutoId { get; set; }
        public string Campo { get; set; }
        public string Texto { get; set; }
    }
}
