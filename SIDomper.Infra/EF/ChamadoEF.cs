using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.Comun;
using SIDomper.Infra.DataBase;
using SIDomper.Infra.RepositorioDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ChamadoEF
    {
        private readonly Repositorio<Chamado> _rep;
        //private readonly RepositorioDapper<ChamadoConsulta> _repositorioDapper;
        //private readonly RepositorioDapper<Quadro> _repositorioDapperQuadro;

        public ChamadoEF()
        {        
            _rep = new Repositorio<Chamado>();
            //_repositorioDapper = new RepositorioDapper<ChamadoConsulta>();
            //_repositorioDapperQuadro = new RepositorioDapper<Quadro>();
        }

        public ChamadoEF(Repositorio<Chamado> repositorio)
        {
            _rep = repositorio;
        }

        public Chamado ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public void Novo()
        {

        }

        public void Excluir(Chamado model)
        {
            _rep.Deletar(model);
        }

        public IQueryable<Chamado> Filtro()
        {
            //TODO: implementar parametros
            return null;
        }

        public IQueryable<Chamado> FiltrarPorId(int id)
        {
            return _rep.Get(x => x.Id == id);
        }

        public void Salvar(Chamado model)
        {
            _rep.AddUpdate(model);
            //if (model.Id == 0)
            //    _rep.Add(model);
            //else
            //    _rep.Update(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void ExcluirUmaOcorrencia(Chamado model, int idOcorrencia)
        {
            var ChamadoOcorrencia = new ChamadoOcorrenciaEF();
            ChamadoOcorrencia.ExcluirUmaOcorrencia(_rep, idOcorrencia);
        }

        public void ExcluirOcorrenciasDoChamado(Chamado model)
        {
            var ChamadoOcorrencia = new ChamadoOcorrenciaEF();
            ChamadoOcorrencia.ExcluirOcorrenciasDoChamado(_rep, model.Id);
        }

        public void ExcluirOcorrenciaIds(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Chamado_Ocorrencia WHERE ChOco_Id in (" + ids + ")");
        }

        public void ExcluirOcorrenciaColaboradorIds(string ids)
        {
            _rep.context.Database.ExecuteSqlCommand("DELETE FROM Chamado_Ocorr_Colaborador WHERE ChaOCol_Id in (" + ids + ")");
        }

        //public IEnumerable<ChamadoConsulta> Filtrar(ChamadoFiltro filtro, string campo, string texto, int usuarioId, bool contem, EnumChamado tipo)
        //{
        //    var usuarioCliente = new UsuarioEF();
        //    var sb = new StringBuilder();
        //    string sTexto = "";

        //    sTexto = "'" + texto + "%'";
        //    if (contem)
        //        sTexto = "'" + texto + "%'";

        //    sb.AppendLine("  SELECT");
        //    sb.AppendLine(" Cha_Id as Id,");
        //    sb.AppendLine(" '' as Descricao,");
        //    sb.AppendLine(" Cha_DataAbertura as DataAbertura,");
        //    sb.AppendLine(" Cha_HoraAbertura as HoraAbertura,");
        //    sb.AppendLine(" Sta_Nome as NomeStatus,");
        //    sb.AppendLine(" Cha_Status as IdStatus,");
        //    sb.AppendLine(" Tip_Nome as NomeTipo,");
        //    sb.AppendLine(" Cli_Nome as RazaoSocial,");
        //    sb.AppendLine(" Cli_Fantasia as Fantasia,");
        //    sb.AppendLine(" CASE Cha_Nivel");
        //    sb.AppendLine("   WHEN 1 THEN '1-Baixo'");
        //    sb.AppendLine("   WHEN 2 THEN '2-Normal'");
        //    sb.AppendLine("   WHEN 3 THEN '3-Alto'");
        //    sb.AppendLine("   WHEN 4 THEN '4-Crítico'");
        //    sb.AppendLine(" END AS Nivel,");
        //    sb.AppendLine(" Usu_Nome as NomeUsuario");
        //    sb.AppendLine(" FROM Chamado");
        //    sb.AppendLine("	INNER JOIN Status  ON Cha_Status = Sta_Id");
        //    sb.AppendLine("	INNER JOIN Tipo    ON Cha_Tipo = Tip_Id");
        //    sb.AppendLine(" INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
        //    sb.AppendLine("	INNER JOIN Usuario ON Cha_UsuarioAbertura = Usu_Id");
        //    sb.AppendLine(" LEFT JOIN Revenda ON Cli_Revenda = Rev_Id");

        //    if (!string.IsNullOrWhiteSpace(texto))
        //        sb.AppendLine(" WHERE " + campo + " LIKE " + sTexto);
        //    else
        //    {
        //        sb.AppendLine("WHERE Cha_Id > 0");
        //    }

        //    if (filtro.Id > 0)
        //        sb.AppendLine(" AND Cha_Id = " + filtro.Id);

        //    if (tipo == EnumChamado.Chamado)
        //        sb.AppendLine(" AND Cha_TipoMovimento = 1");
        //    else
        //        sb.AppendLine(" AND Cha_TipoMovimento = 2");

        //    sb.AppendLine(usuarioCliente.PermissaoUsuario(usuarioId));

        //    if ((!string.IsNullOrWhiteSpace(filtro.DataInicial)) && (filtro.DataInicial.Trim() != "/  /"))
        //        sb.AppendLine(" AND Cha_DataAbertura >=" + Funcoes.DataIngles(filtro.DataInicial));

        //    if ((!string.IsNullOrWhiteSpace(filtro.DataFinal)) && (filtro.DataFinal.Trim() != "/  /"))
        //        sb.AppendLine(" AND Cha_DataAbertura <=" + Funcoes.DataIngles(filtro.DataFinal));

        //    if (!string.IsNullOrWhiteSpace(filtro.IdCliente))
        //        sb.AppendLine(" AND Cha_Cliente IN " + filtro.IdCliente);

        //    if (!string.IsNullOrWhiteSpace(filtro.idTipo))
        //        sb.AppendLine(" AND Cha_Tipo IN " + filtro.idTipo);

        //    if (!string.IsNullOrWhiteSpace(filtro.IdStatus))
        //        sb.AppendLine(" AND Cha_Status IN " + filtro.IdStatus);

        //    if (!string.IsNullOrWhiteSpace(filtro.IdModulo))
        //        sb.AppendLine(" AND Cha_Modulo IN " + filtro.IdModulo);

        //    if (!string.IsNullOrWhiteSpace(filtro.IdRevenda))
        //        sb.AppendLine(" AND Cha_Revenda IN " + filtro.IdRevenda);

        //    if (!string.IsNullOrWhiteSpace(filtro.IdUsuarioAbertura))
        //        sb.AppendLine(" AND Cha_UsuarioAbertura IN " + filtro.IdUsuarioAbertura);

        //    if (filtro.clienteFiltro.UsuarioId > 0)
        //        sb.AppendLine(" AND Cli_Usuario IN " + filtro.clienteFiltro.UsuarioId);
        //    sb.AppendLine(" ORDER BY " + campo);

        //    var lista = _repositorioDapper.GetAll(sb.ToString()); //_rep.context.Database.SqlQuery<ChamadoConsulta>(sb.ToString());

        //    return lista;
        //}

        //public IEnumerable<Quadro> QuadroChamado(int idUsuario, int idRevenda, EnumChamado tipo)
        //{
        //    var sb = new StringBuilder();

        //    if (tipo == EnumChamado.Chamado)
        //        sb.AppendLine(RetornarChamadoQuadro(idUsuario, idRevenda));
        //    else
        //        sb.AppendLine(RetornarAtividadeQuadro(idUsuario, idRevenda));

        //    var lista = _repositorioDapperQuadro.GetAll(sb.ToString()); //_rep.context.Database.SqlQuery<QuadroEF>(sb.ToString()).ToList();

        //    return lista;
        //}

        public void UpdateHoraUsuarioAtual(int idChamado, EnumChamado enumChamado, int idUsuario, int idStatus)
        {
            var model = _rep.First(x => x.Id == idChamado && x.StatusId == idStatus && x.UsuarioAtendeAtualId == idUsuario);
            if (model != null)
            {
                DateTime hora = DateTime.Now;
                model.HoraAtendeAtual = TimeSpan.Parse(hora.ToShortTimeString());
                model.StatusId = idStatus;
                model.UsuarioAtendeAtualId = idUsuario;
                model.Id = idChamado;

                Salvar(model);
            }
        }

        //private string RetornarSQLQuadro(int idUsuario, int idRevenda, int codigoParametro, string campoQuadro, EnumChamado tipo)
        //{
        //    var usuario = new UsuarioEF();
        //    string sConsulta = usuario.PermissaoUsuario(idUsuario);

        //    var sb = new StringBuilder();

        //    sb.AppendLine(" SELECT");
        //    sb.Append(campoQuadro);
        //    sb.AppendLine("	Cha_Id as Id,");
        //    sb.AppendLine("	Cha_DataAbertura as DataAbertura,");
        //    sb.AppendLine("	Cha_HoraAbertura as HoraAbertura,");
        //    sb.AppendLine("	Cli_Nome as NomeCliente,");
        //    sb.AppendLine("	CASE cha_Nivel");
        //    sb.AppendLine("		WHEN 1 THEN '1-Baixo'");
        //    sb.AppendLine("		WHEN 2 THEN '2-Normal'");
        //    sb.AppendLine("		WHEN 3 THEN '3-Alto'");
        //    sb.AppendLine("		WHEN 4 THEN '4-Crítico'");
        //    sb.AppendLine("	END as NivelDescricao,");
        //    sb.AppendLine("  Cha_Nivel as Nivel,");
        //    sb.AppendLine("  Cha_UsuarioAtendeAtual as UsuarioAtendeAtualId,");
        //    sb.AppendLine("  Sta_Codigo as CodigoStatus,");
        //    sb.AppendLine("  Cli_Codigo as CodigoCliente,");
        //    sb.AppendLine("	Tip_Nome as NomeTipo,");
        //    sb.AppendLine("  UltimaHora = dbo.Func_Chamado_BuscarUltimaHoraOcorrencia (Cha_Id),");
        //    sb.AppendLine("	cha_HoraAtendeAtual as HoraAtendeAtual,");
        //    sb.AppendLine("  (");
        //    sb.AppendLine("	   SELECT MAX(CHAO.ChOco_Data) FROM dbo.Chamado_Ocorrencia AS CHAO");
        //    sb.AppendLine("		WHERE CHAO.ChOco_Chamado = dbo.Chamado.Cha_Id");
        //    sb.AppendLine(" 	) AS UltimaData,");
        //    sb.AppendLine("  Par_Codigo as CodigoParametro,");
        //    sb.AppendLine("	Usu_Nome as NomeUsuario");
        //    sb.AppendLine("FROM Chamado");
        //    sb.AppendLine("	INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
        //    sb.AppendLine("	INNER JOIN Tipo ON Cha_Tipo = Tip_Id");
        //    sb.AppendLine("	INNER JOIN Status ON Cha_Status = Sta_Id");
        //    sb.AppendLine("	LEFT JOIN Parametros ON Sta_Codigo = COALESCE(Par_Valor, 0)");
        //    sb.AppendLine("  LEFT JOIN Usuario ON Cha_UsuarioAtendeAtual = Usu_Id");
        //    sb.AppendLine("WHERE par_Codigo = " + codigoParametro);
        //    sb.AppendLine(sConsulta);
        //    //sb.AppendLine("AND EXISTS(");
        //    //sb.AppendLine("	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
        //    //sb.AppendLine("	AND Usu_Id = " + idUsuario + ")");
        //    //sb.AppendLine("AND EXISTS(");
        //    //sb.AppendLine("	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
        //    //sb.AppendLine("	AND Usu_Id = " + idUsuario + ")");

        //    if (idRevenda > 0)
        //        sb.AppendLine("AND (Cli_Revenda = " + idUsuario + ")");

        //    sb.AppendLine(" --=============================================================================");

        //    if (tipo == EnumChamado.Chamado)
        //    {
        //        if (codigoParametro < 8)
        //            sb.AppendLine(" UNION ");
        //    }
        //    else
        //    {
        //        if (codigoParametro < 30)
        //            sb.AppendLine(" UNION ");
        //    }
        //    return sb.ToString();
        //}

        //private string RetornarChamadoQuadro(int idUsuario, int idRevenda)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 3, "'Q1' AS Quadro,", EnumChamado.Chamado));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 4, "'Q2' AS Quadro,", EnumChamado.Chamado));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 5, "'Q3' AS Quadro,", EnumChamado.Chamado));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 6, "'Q4' AS Quadro,", EnumChamado.Chamado));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 7, "'Q5' AS Quadro,", EnumChamado.Chamado));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 8, "'Q6' AS Quadro,", EnumChamado.Chamado));

        //    return sb.ToString();
        //}

        //private string RetornarAtividadeQuadro(int idUsuario, int idRevenda)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 25, "'Q1' AS Quadro,", EnumChamado.Atividade));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 26, "'Q2' AS Quadro,", EnumChamado.Atividade));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 27, "'Q3' AS Quadro,", EnumChamado.Atividade));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 28, "'Q4' AS Quadro,", EnumChamado.Atividade));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 29, "'Q5' AS Quadro,", EnumChamado.Atividade));
        //    sb.Append(RetornarSQLQuadro(idUsuario, idRevenda, 30, "'Q6' AS Quadro,", EnumChamado.Atividade));

        //    return sb.ToString();
        //}

        public List<ClienteEmail> RetornarEmailClientes(int chamadoId)
        {
            var query = from cli in _rep.context.ClientesEmail
                        join cha in _rep.context.Chamados on cli.ClienteId equals cha.ClienteId
                        join sta in _rep.context.Status on cha.StatusId equals sta.Id
                        where cha.Id == chamadoId && sta.NotificarCliente == true && cli.Notificar == true
                        select new
                        {
                            cli.Email

                        };

            var lista = new List<ClienteEmail>();
            foreach (var item in query)
            {
                var model = new ClienteEmail
                {
                    Email = item.Email
                };

                lista.Add(model);
            }

            return lista;
        }

        public List<ChamadoAnexo> RetornarAnexos(int chamadoId)
        {
            var query = from cha in _rep.context.Chamados.AsNoTracking()
                    join oco in _rep.context.ChamadoOcorrencias on cha.Id equals oco.ChamadoId
                    join cli in _rep.context.Clientes on cha.ClienteId equals cli.Id
                    where cha.Id == chamadoId
                    orderby oco.Data
                    select new
                    {
                        cha.Id,
                        cha.DataAbertura,
                        cha.HoraAbertura,
                        cha.Contato,
                        cli.Nome,
                        oco.Documento,
                        oco.Data,
                        oco.Anexo
                    };
                    
            var lista = new List<ChamadoAnexo>();
            foreach (var item in query)
            {
                var model = new ChamadoAnexo();
                model.Contato = item.Contato;
                model.DataAbertura = item.DataAbertura;
                model.DataOcorrencia = item.Data;
                model.DoctoOcorrencia = item.Documento;
                model.HoraAbertura = item.HoraAbertura;
                model.Id = item.Id;
                model.NomeAnexo = item.Anexo;
                model.NomeCliente = item.Nome;

                lista.Add(model);
            }
            return lista;
        }

        public IEnumerable<ChamadoOcorrencia> ListarProblemaSolucao(ChamadoFiltro filtro, string texto, int idUsuario, EnumChamado tipo)
        {
            var usuario = new UsuarioEF();
            string sConsulta = usuario.PermissaoUsuario(idUsuario);

            var sb = new StringBuilder();

            sb.AppendLine(" SELECT ");
            sb.AppendLine("   ChOco_Chamado,");
            sb.AppendLine("   ChOco_Data,");
            sb.AppendLine("   ChOco_HoraInicio,");
            sb.AppendLine("   ChOco_HoraFim,");
            sb.AppendLine("   ChOco_DescricaoSolucao,");
            sb.AppendLine("   ChOco_DescricaoTecnica,");
            sb.AppendLine("   Usu_Nome");
            sb.AppendLine(" FROM Chamado_Ocorrencia");
            sb.AppendLine("   INNER JOIN Chamado ON ChOco_Chamado = Cha_Id");
            sb.AppendLine("   INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("   INNER JOIN Usuario ON ChOco_Usuario = Usu_Id	");
            sb.AppendLine(" WHERE ((ChOco_DescricaoTecnica LIKE " + texto + ") OR (ChOco_DescricaoSolucao LIKE " + texto + "))");
            sb.AppendLine(sConsulta);

            if (tipo == EnumChamado.Chamado)
                sb.AppendLine(" AND cha_TipoMovimento = 1");
            else
                sb.AppendLine(" AND cha_TipoMovimento = 2");

            if (filtro.IdCliente != "")
                sb.AppendLine(" AND Cha_Cliente IN " + filtro.IdCliente);

            sb.AppendLine(" ORDER BY ChOco_Data");

            var _repositorio = new RepositorioDapper<ChamadoOcorrencia>();

            return _repositorio.GetAll(sb.ToString());
        }
    }
}
