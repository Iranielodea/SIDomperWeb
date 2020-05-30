using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class BaseConhecimento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public int? ProdutoId { get; set; }
        public int? ModuloId { get; set; }
        public int TipoId { get; set; }
        public int StatusId { get; set; }
        public string Descricao { get; set; }
        public string Anexo { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Status Status { get; set; }
    }

    public class BaseConhecimentoConsulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public string NomeTipo { get; set; }
        public string NomeStatus { get; set; }
    }

    public class BaseConhecimentoFiltro
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string TipoId { get; set; }
        public string StatusId { get; set; }
        public string UsuarioId { get; set; }
        public string ProdutoId { get; set; }
        public string ModuloId { get; set; }
        public string Campo { get; set; }
        public string Texto { get; set; }
    }
}
