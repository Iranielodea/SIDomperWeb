using SIDomper.Dominio.Entidades;
using SIDomper.Infra.EF.Map;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SIDomper.Infra.DataBase
{
    public class Contexto : DbContext
    {
        public Contexto(): base("SIDomper")
        {            
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<Revenda> Revendas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<ClienteEmail> ClientesEmail { get; set; }
        public DbSet<ClienteModulo> ClientesModulos { get; set; }
        public DbSet<ContaEmail> ContasEmails { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<FormaPagto> FormaPagtos { get; set; }
        public DbSet<FormaPagtoItens> FormaPagtoItens { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<OrcamentoEmail> OrcamentoEmails { get; set; }
        public DbSet<OrcamentoItem> OrcamentoItens { get; set; }
        public DbSet<OrcamentoItemModulo> OrcamentoItemModulos { get; set; }
        public DbSet<OrcamentoNaoAprovado> OrcamentoNaoAprovados { get; set; }
        public DbSet<OrcamentoOcorrencia> OrcamentoOcorrencias { get; set; }
        public DbSet<OrcamentoVencimento> OrcamentoVencimentos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<UsuarioPermissao> UsuarioPermissoes { get; set; }
        public DbSet<Observacao> Observacoes { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<ChamadoStatus> ChamadosStatus { get; set; }
        public DbSet<ChamadoOcorrencia> ChamadoOcorrencias { get; set; }
        public DbSet<ChamadoOcorrenciaColaborador> ChamadoOcorrenciaColaboradores { get; set; }
        public DbSet<DepartamentoAcesso> DepartamentoAcessos { get; set; }
        public DbSet<DepartamentoEmail> DepartamentoEmails { get; set; }
        public DbSet<RevendaEmail> RevendaEmails { get; set; }
        public DbSet<ClienteEspecifiacao> ClienteEspecifiacoes { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Versao> Versoes { get; set; }
        public DbSet<SolicitacaoCronograma> SolicitacaoCronogramas { get; set; }
        public DbSet<SolicitacaoOcorrencia> SolicitacaoOcorrencias { get; set; }
        public DbSet<SolicitacaoStatus> SolicitacaoStatus { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<BaseConhecimento> BaseConhecimentos { get; set; }
        public DbSet<Ramal> Ramais { get; set; }
        public DbSet<RamalItem> RamaItens { get; set; }
        public DbSet<Feriado> Feriados { get; set; }
        public DbSet<Escala> Escalas { get; set; }
        public DbSet<Licenca> Licencas { get; set; }
        public DbSet<LicencaItem> LicencaItens { get; set; }
        public DbSet<PlanoBackup> PlanosBackups { get; set; }
        public DbSet<PlanoBackupItem> PlanosBackupItens { get; set; }
        public DbSet<Recado> Recados{ get; set; }
        public DbSet<ModeloRelatorio> ModelosRelatorios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new TipoMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new ParametroMap());
            modelBuilder.Configurations.Add(new ContaEmailMap());
            modelBuilder.Configurations.Add(new DepartamentoEmailMap());
            modelBuilder.Configurations.Add(new DepartamentoMap());
            modelBuilder.Configurations.Add(new RevendaMap());
            modelBuilder.Configurations.Add(new RevendaEmailMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new ModuloMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new ClienteEmailMap());
            modelBuilder.Configurations.Add(new ClienteModuloMap());
            modelBuilder.Configurations.Add(new VisitaMap());
            modelBuilder.Configurations.Add(new FormaPagtoMap());
            modelBuilder.Configurations.Add(new FormaPagtoItensMap());
            modelBuilder.Configurations.Add(new ProspectMap());
            modelBuilder.Configurations.Add(new OrcamentoMap());
            modelBuilder.Configurations.Add(new OrcamentoEmailMap());
            modelBuilder.Configurations.Add(new OrcamentoItemMap());
            modelBuilder.Configurations.Add(new OrcamentoItemModuloMap());
            modelBuilder.Configurations.Add(new OrcamentoNaoAprovadoMap());
            modelBuilder.Configurations.Add(new OrcamentoOcorrenciaMap());
            modelBuilder.Configurations.Add(new OrcamentoVencimentoMap());
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new UsuarioPermissaoMap());
            modelBuilder.Configurations.Add(new ObservacaoMap());
            modelBuilder.Configurations.Add(new ChamadoMap());
            modelBuilder.Configurations.Add(new ChamadoStatusMap());
            modelBuilder.Configurations.Add(new ChamadoOcorrenciaMap());
            modelBuilder.Configurations.Add(new ChamadoOcorrenciaColaboradorMap());
            modelBuilder.Configurations.Add(new DepartamentoAcessoMap());
            modelBuilder.Configurations.Add(new ClienteEspecificacaoMap());
            modelBuilder.Configurations.Add(new SolicitacaoMap());
            modelBuilder.Configurations.Add(new VersaoMap());
            modelBuilder.Configurations.Add(new SolicitacaoCronogramaMap());
            modelBuilder.Configurations.Add(new SolicitacaoOcorrenciaMap());
            modelBuilder.Configurations.Add(new SolicitacaoStatusMap());
            modelBuilder.Configurations.Add(new AgendamentoMap());
            modelBuilder.Configurations.Add(new BaseConhecimentoMap());
            modelBuilder.Configurations.Add(new RamalMap());
            modelBuilder.Configurations.Add(new RamalItemMap());
            modelBuilder.Configurations.Add(new FeriadoMap());
            modelBuilder.Configurations.Add(new EscalaMap());
            modelBuilder.Configurations.Add(new LicencaMap());
            modelBuilder.Configurations.Add(new LicencaItemMap());
            modelBuilder.Configurations.Add(new PlanoBackupMap());
            modelBuilder.Configurations.Add(new PlanoBackupItemMap());
            modelBuilder.Configurations.Add(new RecadoMap());
            modelBuilder.Configurations.Add(new ModeloRelatorioMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
        }
    }
}
