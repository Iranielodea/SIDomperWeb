using SIDomper.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.ViewModel
{
    public class OrcamentoNovoViewModel
    {
        public OrcamentoNovoViewModel()
        {
            Orcamento = new Orcamento();
            Produtos = new List<Produto>();
            Modulos = new List<Modulo>();
        }
        public List<Produto> Produtos { get; set; }
        public List<Modulo> Modulos { get; set; }
        public Orcamento Orcamento { get; set; }
    }
}
