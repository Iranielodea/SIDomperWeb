using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.ViewModel
{
    public class ClienteViewModelApi : BaseViewModel
    {
        public ClienteViewModelApi()
        {
            Ativo = true;
            Enquadramento = "00";
        }
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Dcto { get; set; }
        public string Enquadramento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Contato { get; set; }
        public int RevendaId { get; set; }
        public bool Ativo { get; set; }
        public bool Restricao { get; set; }
        public int? UsuarioId { get; set; }
        public string Versao { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public int? CidadeId { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Celular { get; set; }
        public string OutroFone { get; set; }
        public string ContatoFinanceiro { get; set; }
        public string FoneContatoFinanceiro { get; set; }
        public string ContatoCompraVenda { get; set; }
        public string FoneContatoCompraVenda { get; set; }
        public string IE { get; set; }
        public string RepresentanteLegal { get; set; }
        public string CPFRepresentanteLegal { get; set; }
        public int? EmpresaVinculada { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Perfil { get; set; }
        public int? CodigoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        public virtual RevendaViewModel Revenda { get; set; }
        public virtual CidadeViewModel Cidade { get; set; }
        public virtual ICollection<ContatoViewModelApi> Contatos { get; set; }
        public virtual ICollection<ClienteEmailViewModelApi> Emails { get; set; }
        public virtual ICollection<ClienteModuloViewModelApi> ClienteModulos { get; set; }
        //public virtual UsuarioViewModel Usuario { get; set; }
    }

    public class ClienteConsultaViewModelApi
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Perfil { get; set; }
        public string Razao { get; set; }
        public string Fantasia { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string NomeConsultor { get; set; }
        public string NomeRevenda { get; set; }
        public string Enquadramento { get; set; }
        //public string Enquadramento
        //{
        //    get
        //    {
        //        if (Enquadramento == "01")
        //            return "01-Simples";
        //        if (Enquadramento == "02")
        //            return "02-Lucro Presumido";
        //        if (Enquadramento == "03")
        //            return "03-Lucro Real";
        //        else
        //            return "00-Não Definido";

        //    }
        //    set {; }
        //}

        public string Versao { get; set; }
    }

    public class ContatoViewModelApi
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public int? OrcamentoId { get; set; }
        public string Nome { get; set; }
        public string Fone1 { get; set; }
        public string Fone2 { get; set; }
        public string Departamento { get; set; }
        public string Email { get; set; }
    }


    public class ClienteEmailViewModelApi
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Notificar { get; set; }
    }

    public class ClienteModuloViewModelApi
    {
        public int Id { get; set; }
        public int ModuloId { get; set; }
        public int? ProdutoId { get; set; }
        public int CodModulo { get; set; }
        public int? CodProduto { get; set; }
        public string NomeModulo { get; set; }
        public string NomeProduto { get; set; }
    }

    public class ClienteFiltroViewModelApi
    {
        public int Id { get; set; }
        public string Ativo { get; set; }
        public int Restricao { get; set; }
        public string Versao { get; set; }
        public string EmpresaVinculada { get; set; }
        public int UsuarioId { get; set; }
        public int RevendaId { get; set; }
        public int CidadeId { get; set; }
        public int ModuloId { get; set; }
        public int ProdutoId { get; set; }
        public string Enquadramento { get; set; }
        public string NomeCliente { get; set; }
        public string Perfil { get; set; }
        public string Campo { get; set; }
        public string Valor { get; set; }
        public int Modelo { get; set; }
        public string FiltroIdUsuario { get; set; }
        public string FiltroIdRevenda { get; set; }
        public string FiltroIdCidade { get; set; }
        public string filtroIdModulo { get; set; }
        public string FiltroIdProduto { get; set; }

    }
}
