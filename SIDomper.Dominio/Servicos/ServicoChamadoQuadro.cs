using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.Interfaces;
using SIDomper.Dominio.Interfaces.Servicos;
using SIDomper.Dominio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Dominio.Servicos
{
    public class ServicoChamadoQuadro : IServicoChamadoQuadro
    {
        private readonly IRepositoryReadOnly<QuadroViewModelChamado> _repositoryQuadroReadOnly;
        private readonly IUnitOfWork _uow;

        public ServicoChamadoQuadro(IRepositoryReadOnly<QuadroViewModelChamado> repositoryQuadroReadOnly,
            IUnitOfWork uow)
        {
            _repositoryQuadroReadOnly = repositoryQuadroReadOnly;
            _uow = uow;
        }

        public ChamadoQuadroViewModel AbrirQuadro(int idUsuario, int idRevenda, EnProgramas enProgramas)
        {
            var lista = new List<QuadroViewModelChamado>();
            var quadroViewModel = new ChamadoQuadroViewModel();

            if (enProgramas == EnProgramas.Chamado)
            {
                //lista = _repADO.QuadroChamado(idUsuario, idRevenda, EnumChamado.Chamado).ToList();
                lista = QuadroChamado(idUsuario, idRevenda, EnumChamado.Chamado).ToList();

                quadroViewModel.Quadro1 = lista.Where(x => x.QuadroTela == "Q1").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro2 = lista.Where(x => x.QuadroTela == "Q2").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro3 = lista.Where(x => x.QuadroTela == "Q3").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro4 = lista.Where(x => x.QuadroTela == "Q4").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro5 = lista.Where(x => x.QuadroTela == "Q5").OrderBy(x => x.Id).ToList();
                quadroViewModel.Quadro6 = lista.Where(x => x.QuadroTela == "Q6").OrderBy(x => x.Id).ToList();

                var listaStatus = BuscarTitulosQuadro();

                quadroViewModel.Titulo1 = listaStatus[0].Nome;
                quadroViewModel.Titulo2 = listaStatus[1].Nome;
                quadroViewModel.Titulo3 = listaStatus[2].Nome;
                quadroViewModel.Titulo4 = listaStatus[3].Nome;
                quadroViewModel.Titulo5 = listaStatus[4].Nome;
                quadroViewModel.Titulo6 = listaStatus[5].Nome;

                //var codStatusAbertura = StatusAbertura();
                //var codStatusOcorrencia = StatusAtendimentoChamado();

                int.TryParse(StatusAbertura(), out int codigoStatusAbertura);
                int.TryParse(StatusAtendimentoChamado(), out int codigoStatusOcorrencia);

                //var modelServico = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusAbertura);
                string statusAbertura = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusAbertura).Nome;


                //modelServico = statusServico.ObterPorCodigo(int.Parse(codStatusOcorrencia));
                string statusOcorrencia = _uow.RepositorioStatus.First(x => x.Codigo == codigoStatusOcorrencia).Nome;

                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo1, quadroViewModel.Quadro1);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo2, quadroViewModel.Quadro2);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo3, quadroViewModel.Quadro3);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo4, quadroViewModel.Quadro4);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo5, quadroViewModel.Quadro5);
                PreencherQuadro(statusAbertura, statusOcorrencia, quadroViewModel.Titulo6, quadroViewModel.Quadro6);
            }
            else
                lista = QuadroChamado(idUsuario, idRevenda, EnumChamado.Atividade).ToList();

            return quadroViewModel;
            //return _repADO.QuadroChamado(idUsuario, idRevenda, EnumChamado.Atividade).ToList();
        }

        public string StatusAtendimentoChamado()
        {
            return _uow.RepositorioChamado.StatusAtendimentoChamado();
        }

        public string StatusAbertura()
        {
            return _uow.RepositorioChamado.StatusAbertura();
        }

        public string StatusAberturaAtividade()
        {
            return _uow.RepositorioChamado.StatusAberturaAtividade();
        }

        private List<Status> BuscarTitulosQuadro()
        {
            var listaParametros = BuscarTitulosChamados();

            var listaStatus = _uow.RepositorioStatus.Get(x => x.Ativo == true);
            var lista = new List<Status>();

            foreach (var item in listaParametros)
            {
                var model = listaStatus.First(x => x.Codigo == Convert.ToInt32(item.Valor));
                lista.Add(model);
            }

            return lista;
        }

        private IEnumerable<Parametro> BuscarTitulosChamados()
        {
            var parametro = _uow.RepositorioParametro.Get(x => x.Codigo == 3 || x.Codigo == 4 || x.Codigo == 5 || x.Codigo == 6 || x.Codigo == 7 || x.Codigo == 8);
            return parametro.OrderBy(x => x.Codigo);
        }

        private void PreencherQuadro(string nomeStatusAbertura, string nomeStatusOcorrencia, string tituloQuadro, List<QuadroViewModelChamado> quadro)
        {
            /*
                    se titulo1 = statusAbertura
                        ler quadro1 calcularTempo
                    se titulo1 = statusOcorrencia
                        ler quadro1 calcularPar10
                    se nao
                        ler quadro1 = tempoOutro
                 */

            foreach (var item in quadro)
            {
                if (tituloQuadro == nomeStatusAbertura)
                    item.Tempo = CalcularTempo(DateTime.Parse(item.DataAbertura), TimeSpan.Parse(item.HoraAbertura));
                else if (tituloQuadro == nomeStatusOcorrencia)
                    item.Tempo = CalcularTempoParametro10(TimeSpan.Parse(item.HoraAtendeAtual));
                else
                    item.Tempo = CalcularTempo(DateTime.Parse(item.UltimaData), TimeSpan.Parse(item.UltimaHora));
            }
        }

        public string CalcularTempoParametro10(TimeSpan horaAtendimento)
        {
            try
            {
                TimeSpan horaAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                TimeSpan tempo = Funcoes.Utils.CalcularHoras(horaAtual, horaAtendimento);
                return Funcoes.Utils.FormatarHora(tempo);
            }
            catch
            {
                return "00:00";
            }
        }

        public string CalcularTempo(DateTime dataChamado, TimeSpan horaChamado)
        {
            try
            {
                if (DateTime.Now.Date == dataChamado)
                {
                    TimeSpan horaAtual = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                    TimeSpan hora = Funcoes.Utils.CalcularHoras(horaChamado, horaAtual);
                    return Funcoes.Utils.FormatarHora(hora);
                }
                else
                {
                    double dias = Funcoes.Utils.CalcularDatas(dataChamado, DateTime.Now.Date);
                    return dias.ToString();
                }
            }
            catch
            {
                return "00:00";
            }
        }

        private IEnumerable<QuadroViewModelChamado> QuadroChamado(int idUsuario, int idRevenda, EnumChamado tipo)
        {
            var sb = new StringBuilder();

            if (tipo == EnumChamado.Chamado)
                sb.AppendLine(RetornarChamadoQuadro(idUsuario, idRevenda));
            else
                sb.AppendLine(RetornarAtividadeQuadro(idUsuario, idRevenda));

            var lista = _repositoryQuadroReadOnly.GetAll(sb.ToString());

            return lista;
        }

        private string RetornarAtividadeQuadro(int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 25, "'Q1' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 26, "'Q2' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 27, "'Q3' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 28, "'Q4' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 29, "'Q5' AS Quadro,", EnumChamado.Atividade));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 30, "'Q6' AS Quadro,", EnumChamado.Atividade));

            return sb.ToString();
        }

        private string RetornarChamadoQuadro(int idUsuario, int idRevenda)
        {
            var sb = new StringBuilder();
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 3, "'Q1' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 4, "'Q2' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 5, "'Q3' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 6, "'Q4' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 7, "'Q5' AS Quadro,", EnumChamado.Chamado));
            sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 8, "'Q6' AS Quadro,", EnumChamado.Chamado));

            return sb.ToString();
        }

        private string RetornarSQLQuadro(int idUsuario, int idRevenda, int codigoParametro, string campoQuadro, EnumChamado tipo)
        {
            string sConsulta = _uow.RepositorioUsuario.PermissaoUsuario(idUsuario);

            var sb = new StringBuilder();

            sb.AppendLine(" SELECT");
            sb.Append(campoQuadro);
            sb.AppendLine("	Cha_Id as Id,");
            sb.AppendLine("	Cha_DataAbertura as DataAbertura,");
            sb.AppendLine("	Cha_HoraAbertura as HoraAbertura,");
            sb.AppendLine("	Cli_Nome as NomeCliente,");
            sb.AppendLine("	Cli_Perfil as Perfil,");
            sb.AppendLine("	CASE cha_Nivel");
            sb.AppendLine("		WHEN 1 THEN '1-Baixo'");
            sb.AppendLine("		WHEN 2 THEN '2-Normal'");
            sb.AppendLine("		WHEN 3 THEN '3-Alto'");
            sb.AppendLine("		WHEN 4 THEN '4-Crítico'");
            sb.AppendLine("	END as NivelDescricao,");
            sb.AppendLine("  Cha_Nivel as Nivel,");
            sb.AppendLine("  Cha_UsuarioAtendeAtual as UsuarioAtendeAtualId,");
            sb.AppendLine("  Sta_Codigo as CodigoStatus,");
            sb.AppendLine("  Cli_Codigo as CodigoCliente,");
            sb.AppendLine("	Tip_Nome as NomeTipo,");
            sb.AppendLine("  UltimaHora = dbo.Func_Chamado_BuscarUltimaHoraOcorrencia (Cha_Id),");
            sb.AppendLine("	cha_HoraAtendeAtual as HoraAtendeAtual,");
            sb.AppendLine("  (");
            sb.AppendLine("	   SELECT MAX(CHAO.ChOco_Data) FROM dbo.Chamado_Ocorrencia AS CHAO");
            sb.AppendLine("		WHERE CHAO.ChOco_Chamado = dbo.Chamado.Cha_Id");
            sb.AppendLine(" 	) AS UltimaData,");
            sb.AppendLine("  Par_Codigo as CodigoParametro,");
            sb.AppendLine("	Usu_Nome as NomeUsuario");
            sb.AppendLine("FROM Chamado");
            sb.AppendLine("	INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("	INNER JOIN Tipo ON Cha_Tipo = Tip_Id");
            sb.AppendLine("	INNER JOIN Status ON Cha_Status = Sta_Id");
            sb.AppendLine("	LEFT JOIN Parametros ON Sta_Codigo = COALESCE(Par_Valor, 0)");
            sb.AppendLine("  LEFT JOIN Usuario ON Cha_UsuarioAtendeAtual = Usu_Id");
            sb.AppendLine("WHERE par_Codigo = " + codigoParametro);
            sb.AppendLine(sConsulta);

            if (idRevenda > 0)
                sb.AppendLine("AND (Cli_Revenda = " + idUsuario + ")");

            sb.AppendLine(" --=============================================================================");

            if (tipo == EnumChamado.Chamado)
            {
                if (codigoParametro < 8)
                    sb.AppendLine(" UNION ");
            }
            else
            {
                if (codigoParametro < 30)
                    sb.AppendLine(" UNION ");
            }
            return sb.ToString();
        }
    }
}
