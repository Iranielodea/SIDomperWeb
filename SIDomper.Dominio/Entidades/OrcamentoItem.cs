using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Entidades
{
    public class OrcamentoItem
    {
        public OrcamentoItem()
        {
            OrcamentoItemModulos = new List<OrcamentoItemModulo>();
        }
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal ValorLicencaImpl { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal ValorDescontoImpl { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal ValorLicencaMensal { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal ValorDescontoMensal { get; set; }
        public int? TipoId { get; set; }
        public int? StatusId { get; set; }

        public virtual Orcamento Orcamento { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<OrcamentoItemModulo> OrcamentoItemModulos { get; set; }
    }
}
