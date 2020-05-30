using System;
using System.Collections.Generic;

namespace SIDomper.Dominio.Entidades
{
    public class Versao
    {
        public Versao()
        {
            Solicitacoes = new List<Solicitacao>();
        }
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataLiberacao { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public string VersaoStr { get; set; }
        public int? ProdutoId { get; set; } 

        public virtual Usuario Usuario { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Status Status { get; set; }
        public virtual Produto Produto { get; set; }

        public virtual ICollection<Solicitacao> Solicitacoes { get; set; }
    }

    public class VersaoConsulta
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

    public class VersaoFiltro
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
    }
}
