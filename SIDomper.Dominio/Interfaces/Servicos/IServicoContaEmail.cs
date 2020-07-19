using SIDomper.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace SIDomper.Dominio.Interfaces.Servicos
{
    public interface IServicoContaEmail
    {
        IEnumerable<ContaEmailConsulta> Filtrar(string campo, string texto, string ativo = "A", bool contem = true);
        ContaEmail Novo(int idUsuario);
        ContaEmail Editar(int id, int idUsuario, ref string mensagem);
        ContaEmail ObterPorId(int id);
        ContaEmail ObterPorCodigo(int codigo);
        void Relatorio(int idUsuario);
        void Excluir(ContaEmail model, int idUsuario);
        void Salvar(ContaEmail model);
        void EnviarEmail(int idUsuario, string destinatiario, string copiaOculta, string assunto, string texto, string arquivoAnexo, bool aviso = false);
    }
}
