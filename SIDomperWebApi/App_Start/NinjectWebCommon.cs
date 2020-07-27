[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SIDomperWebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SIDomperWebApi.App_Start.NinjectWebCommon), "Stop")]

namespace SIDomperWebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using SIDomper.Dominio.Interfaces;
    using SIDomper.Dominio.Interfaces.Repositorios;
    using SIDomper.Dominio.Interfaces.Servicos;
    using SIDomper.Dominio.Servicos;
    using SIDomper.Infra.DataBase;
    using SIDomper.Infra.RepositorioDapper;
    using SIDomper.Infra.RepositorioEF;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<Contexto>().ToSelf();
            kernel.Bind<IUnitOfWork>().To<UnitOfWorkEF>();

            //REPOSITORIOS
            kernel.Bind(typeof(IRepositorio<>)).To(typeof(Repositorio<>));
            kernel.Bind(typeof(IRepositoryReadOnly<>)).To(typeof(RepositorioDapper<>));
            kernel.Bind(typeof(IRepositoryWriteOnly)).To(typeof(RepositorioWriteDapper));

            kernel.Bind<IRepositorioProduto>().To<RepositorioProduto>();
            kernel.Bind<IRepositorioUsuario>().To<RepositorioUsuario>();
            kernel.Bind<IRepositorioModulo>().To<RepositorioModulo>();
            kernel.Bind<IRepositorioCategoria>().To<RepositorioCategoria>();
            kernel.Bind<IRepositorioCidade>().To<RepositorioCidade>();
            kernel.Bind<IRepositorioFeriado>().To<RepositorioFeriado>();
            kernel.Bind<IRepositorioContaEmail>().To<RepositorioContaEmail>();
            kernel.Bind<IRepositorioObservacao>().To<RepositorioObservacao>();
            kernel.Bind<IRepositorioTipo>().To<RepositorioTipo>();
            kernel.Bind<IRepositorioStatus>().To<RepositorioStatus>();
            kernel.Bind<IRepositorioEscala>().To<RepositorioEscala>();
            kernel.Bind<IRepositorioParametro>().To<RepositorioParametro>();
            kernel.Bind<IRepositorioRevenda>().To<RepositorioRevenda>();
            kernel.Bind<IRepositorioCliente>().To<RepositorioCliente>();
            kernel.Bind<IRepositorioRamal>().To<RepositorioRamal>();
            kernel.Bind<IRepositorioDepartamento>().To<RepositorioDepartamento>();
            kernel.Bind<IRepositorioBaseConhecimento>().To<RepositorioBaseConhecimento>();
            kernel.Bind<IRepositorioAgendamento>().To<RepositorioAgendamento>();
            kernel.Bind<IRepositorioVersao>().To<RepositorioVersao>();
            kernel.Bind<IRepositorioVisita>().To<RepositorioVisita>();
            kernel.Bind<IRepositorioRecado>().To<RepositorioRecado>();

            kernel.Bind<IRepositorioUsuarioWrite>().To<RepositorioUsuarioWriteDapper>();

            //SERVICOS
            kernel.Bind<IServicoProduto>().To<ServicoProduto>();
            kernel.Bind<IServicoUsuario>().To<ServicoUsuario>();
            kernel.Bind<IServicoModulo>().To<ServicoModulo>();
            kernel.Bind<IServicoCategoria>().To<ServicoCategoria>();
            kernel.Bind<IServicoCidade>().To<ServicoCidade>();
            kernel.Bind<IServicoFeriado>().To<ServicoFeriado>();
            kernel.Bind<IServicoContaEmail>().To<ServicoContaEmail>();
            kernel.Bind<IServicoObservacao>().To<ServicoObservacao>();
            kernel.Bind<IServicoTipo>().To<ServicoTipo>();
            kernel.Bind<IServicoStatus>().To<ServicoStatus>();
            kernel.Bind<IServicoCliente>().To<ServicoCliente>();

            kernel.Bind<IServicoParametro>().To<ServicoParametro>();
            kernel.Bind<IServicoRevenda>().To<ServicoRevenda>();
            kernel.Bind<IServicoRamal>().To<ServicoRamal>();
            kernel.Bind<IServicoDepartamento>().To<ServicoDepartamento>();
            kernel.Bind<IServicoBaseConhecimento>().To<ServicoBaseConhecimento>();
            kernel.Bind<IServicoAgendamento>().To<ServicoAgendamento>();
            kernel.Bind<IServicoVersao>().To<ServicoVersao>();
            kernel.Bind<IServicoVisita>().To<ServicoVisita>();
            kernel.Bind<IServicoRecado>().To<ServicoRecado>();
        }
    }
}