using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Interfaces.Repositorios;

namespace SIDomper.Infra.RepositorioDapper
{
    public class RepositorioUsuarioWriteDapper : RepositorioWriteDapper, IRepositorioUsuarioWrite
    {
        public int Insert(Usuario usuario)
        {
            string instrucaoSql = @"
            INSERT INTO Usuario(
                Usu_Adm
                ,Usu_Ativo
                ,Usu_Cliente
                ,Usu_Codigo
                ,Usu_ContaEmail
                ,Usu_Departamento
                ,Usu_Email
                ,Usu_Nome
                ,Usu_Notificar
                ,Usu_OnLine
                ,Usu_Password
                ,Usu_Revenda
                ,Usu_UserName
                ,Usu_Telefone)
            VALUES (
                @Adm
                ,@Ativo
                ,@ClienteId
                ,@Codigo
                ,@ContaEmailId
                ,@DepartamentoId
                ,@Email
                ,@Nome
                ,@Notificar
                ,@OnLine
                ,@Password
                ,@RevendaId
                ,@UserName
                ,@Telefone); SELECT CAST(SCOPE_IDENTITY() as int)";


            int idUsuario = base.Insert(instrucaoSql, usuario);

            var usuarioPermissao = new UsuarioPermissao();

            foreach (var item in usuario.UsuariosPermissao)
            {
                usuarioPermissao.UsuarioId = idUsuario;
                usuarioPermissao.Sigla = item.Sigla;

                instrucaoSql = @"
                INSERT INTO Usuario_Permissao(
                    UsuP_Usuario
                    ,UsuP_Sigla)
                VALUES(
                    @UsuarioId
                    ,@Sigla)";

                base.Insert(instrucaoSql, usuarioPermissao);
            }

            return idUsuario;
        }

        public void Update(Usuario usuario)
        {
            string instrucaoSql = @"
                UPDATE Usuario SET
                    Usu_Adm = @Adm
                    ,Usu_Ativo = @Ativo
                    ,Usu_Cliente = @ClienteId
                    ,Usu_Codigo = @Codigo
                    ,Usu_ContaEmail = @ContaEmailId
                    ,Usu_Departamento = @DepartamentoId
                    ,Usu_Email = @Email
                    ,Usu_Nome = @Nome
                    ,Usu_Notificar = @Notificar
                    ,Usu_OnLine = @OnLine
                    ,Usu_Password = @Password
                    ,Usu_Revenda = @RevendaId
                    ,Usu_UserName = @UserName
                    ,Usu_Telefone = @Telefone
                WHERE Usu_Id = @Id";

            base.Update(instrucaoSql, usuario);
        }
    }
}
