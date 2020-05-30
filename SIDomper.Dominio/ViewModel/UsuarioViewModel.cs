using SIDomper.Dominio.ViewModel;
using System.Collections.Generic;

namespace SIDomper.Dominio.ViewModel
{
    public class UsuarioViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string UserName { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public bool Adm { get; set; }
        public bool Ativo { get; set; }
        public int? ContaEmailId { get; set; }
        public int DepartamentoId { get; set; }
        public string Email { get; set; }
        public int? RevendaId { get; set; }
        public int? ClienteId { get; set; }
        public bool OnLine { get; set; }
        public bool Notificar { get; set; }
        public bool HorarioUsoSistema { get; set; }
        public int ClienteCodigo { get; set; }
        public string NomeCliente { get; set; }

        public virtual ICollection<UsuarioPermissaoViewModel> UsuariosPermissao { get; set; }
        public virtual DepartamentoViewModel Departamento { get; set; }
        public virtual ContaEmailViewModel ContaEmail { get; set; }
        public virtual RevendaViewModel Revenda { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
    }

    public class UsuarioConsultaViewModel
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string ContaEmail { get; set; }
        public string Email { get; set; }
    }

    public class UsuarioPermissaoDepartamentoViewModel
    {
        public int IdUsuario { get; set; }
        public int IdPrograma { get; set; }
        public bool Acesso { get; set; }
        public bool Incluir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
        public bool UsuarioADM { get; set; }
    }

    public class UsuarioPermissaoViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Sigla { get; set; }
    }

    public class UsuarioFiltroViewModel
    {
        public UsuarioFiltroViewModel()
        {
            Contem = true;
        }
        public int Id { get; set; }
        public string Campo { get; set; }
        public string Texto { get; set; }
        public string IdRevenda { get; set; }
        public string IdCliente { get; set; }
        public string IdDepartamento { get; set; }
        public string Ativo { get; set; }
        public bool Contem { get; set; }
    }

}
