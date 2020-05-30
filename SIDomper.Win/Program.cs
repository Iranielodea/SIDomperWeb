using SIDomper.Apresentacao.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            View.frmSplash formulario = new View.frmSplash();

            //Abre o formulário de apresentação           
            formulario.Show();
            Application.DoEvents();
            //Carregar configurações do usuário

            Thread.Sleep(1000);

            //Carrega configurações do banco de dados
            var usuarioApp = new UsuarioApp();
            usuarioApp.ObterPorCodigo(21);

            Thread.Sleep(1000);

            //Abre conexão com banco de dados

            Thread.Sleep(1000);

            //Fecha formulário de apresentação

            formulario.Dispose();

            Application.Run(new frmMenuPrincipal());
        }
    }
}
