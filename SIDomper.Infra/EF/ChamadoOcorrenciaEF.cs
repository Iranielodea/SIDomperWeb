using SIDomper.Dominio.Entidades;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Infra.DataBase;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDomper.Infra.EF
{
    public class ChamadoOcorrenciaEF
    {
        private readonly Repositorio<ChamadoOcorrencia> _rep;
        private readonly UsuarioEF _repUsuario;

        public ChamadoOcorrenciaEF()
        {
            _rep = new Repositorio<ChamadoOcorrencia>();
            _repUsuario = new UsuarioEF();
        }

        public ChamadoOcorrencia ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public IQueryable<ChamadoOcorrencia> ObterPorChamado(int idChamado)
        {
            return _rep.Get(x => x.ChamadoId == idChamado);
        }

        public IQueryable<ChamadoOcorrenciaConsulta> ObterConsultaPorChamado(int idChamado)
        {
            var sb = new StringBuilder();
            //sb.AppendLine(" SELECT ");
            //sb.AppendLine(" ChOco_Id as Id,");
            //sb.AppendLine(" ChOco_Chamado as ChamadoId,");
            //sb.AppendLine(" ChOco_Docto as Documento,");
            //sb.AppendLine(" ChOco_Data as Data,");
            //sb.AppendLine(" ChOco_HoraInicio as HoraInicio,");
            //sb.AppendLine(" ChOco_HoraFim as HoraFim,");
            //sb.AppendLine(" ChOco_Usuario as UsuarioId,");
            //sb.AppendLine(" Usu_Codigo as CodUsuario,");
            //sb.AppendLine(" Usu_Nome as NomeUsuario");
            //sb.AppendLine(" FROM Chamado_Ocorrencia");
            //sb.AppendLine(" INNER JOIN Usuario On ChOco_Usuario = Usu_Id");
            //sb.AppendLine(" WHERE ChOco_Chamado = " + idChamado);

            sb.AppendLine(" SELECT ");
            sb.AppendLine(" ChOco_Id as Id,");
            sb.AppendLine(" ChOco_Docto as Documento,");
            sb.AppendLine(" ChOco_Data as Data,");
            sb.AppendLine(" ChOco_HoraInicio as HoraInicio,");
            sb.AppendLine(" ChOco_HoraFim as HoraFim,");
            sb.AppendLine(" ChOco_Usuario as UsuarioId,");
            sb.AppendLine(" Usu_Codigo as CodUsuario,");
            sb.AppendLine(" Usu_Nome as NomeUsuario");
            sb.AppendLine(" FROM Chamado_Ocorrencia");
            sb.AppendLine(" INNER JOIN Usuario On ChOco_Usuario = Usu_Id");
            sb.AppendLine(" WHERE ChOco_Chamado = " + idChamado);

            return  _rep.context.Database.SqlQuery<ChamadoOcorrenciaConsulta>(sb.ToString()).AsQueryable();

            //var query = from cha in _rep.context.ChamadoOcorrencias.AsNoTracking()
            //            join usu in _rep.context.Usuarios.AsNoTracking() on cha.UsuarioId equals usu.Id
            //            where cha.ChamadoId == idChamado
            //            select new
            //            {
            //                cha.Id,
            //                cha.ChamadoId,
            //                cha.Documento,
            //                cha.Data,
            //                cha.HoraInicio,
            //                cha.HoraFim,
            //                cha.UsuarioId,
            //                usu.Codigo,
            //                NomeUsuario = usu.Nome
            //            };

            //var resultado = query.ToList();

            //var lista = new List<ChamadoOcorrenciaConsulta>();
            //foreach (var item in resultado)
            //{
            //    var model = new ChamadoOcorrenciaConsulta();
            //    model.ChamadoId = item.ChamadoId;
            //    model.Data = item.Data;
            //    model.Documento = item.Documento;
            //    model.HoraFim = item.HoraFim;
            //    model.HoraInicio = item.HoraInicio;
            //    model.Id = item.Id;
            //    model.UsuarioId = item.UsuarioId;
            //    model.CodUsuario = item.Codigo;
            //    model.NomeUsuario = item.NomeUsuario;
            //    lista.Add(model);
            //}

            //return lista;
        }

        public void Excluir(ChamadoOcorrencia model)
        {
            _rep.Deletar(model);
        }

        public void Commit()
        {
            _rep.Commit();
        }

        public void Salvar(ChamadoOcorrencia model)
        {
            _rep.AddUpdate(model);
            //if (model.Id > 0)
            //    _rep.Update(model);
            //else
            //    _rep.Add(model);
        }

        public void Salvar(Repositorio<Chamado> repositorio, ChamadoOcorrencia model)
        {
            var item = repositorio.context.ChamadoOcorrencias.First(x => x.Id == model.Id);
            if (item == null)
                repositorio.context.ChamadoOcorrencias.Add(item);
            else
            {
                item = ObterPorId(model.Id);
                item = model;
                Salvar(item);
            }
        }        

        public void ExcluirUmaOcorrencia(Repositorio<Chamado> repositorio, int idOcorrencia)
        {
            var item = repositorio.context.ChamadoOcorrencias.First(x => x.Id == idOcorrencia);
            if (item != null)
                repositorio.context.ChamadoOcorrencias.Remove(item);
        }

        public void ExcluirOcorrenciasDoChamado(Repositorio<Chamado> repositorio, int idChamado)
        {
            var lista = repositorio.context.ChamadoOcorrencias.Where(x => x.ChamadoId == idChamado);
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    repositorio.context.ChamadoOcorrencias.Remove(item);
                }
            }
        }

        public IQueryable<ProblemaSolucao> ProblemaSolucao(string texto, int idUsuario, int idCliente, EnumChamado enumChamado)
        {
            var sb = new StringBuilder();
            string sTexto = "'%" + texto + "%'";
            sb.AppendLine(" SELECT ");
            sb.AppendLine("   ChOco_Id as Id,");
            sb.AppendLine("   ChOco_Chamado as IdChamado,");
            sb.AppendLine("   ChOco_HoraInicio as HoraInicio,");
            sb.AppendLine("   ChOco_HoraFim as HoraFim,");
            sb.AppendLine("   ChOco_DescricaoSolucao as DescricaoSolucao,");
            sb.AppendLine("   ChOco_DescricaoTecnica as DescricaoTecnica,");
            sb.AppendLine("   Usu_Nome as NomeUsuario");
            sb.AppendLine(" FROM Chamado_Ocorrencia");
            sb.AppendLine("   INNER JOIN Chamado ON ChOco_Chamado = Cha_Id");
            sb.AppendLine("   INNER JOIN Cliente ON Cha_Cliente = Cli_Id");
            sb.AppendLine("   INNER JOIN Usuario ON ChOco_Usuario = Usu_Id	");
            sb.AppendLine(" WHERE ((ChOco_DescricaoTecnica LIKE " + sTexto + ") OR (ChOco_DescricaoSolucao LIKE " + sTexto + "))");

            if (idCliente > 0)
                sb.AppendLine(" AND Cha_Cliente = " + idCliente);

            if (enumChamado == EnumChamado.Chamado)
                sb.AppendLine(" AND cha_TipoMovimento = 1");
            else
                sb.AppendLine(" AND cha_TipoMovimento = 2");

            sb.AppendLine(_repUsuario.PermissaoUsuario(idUsuario));

            sb.AppendLine(" ORDER BY ChOco_Data");

            var temp = sb.ToString();

            return _rep.context.Database.SqlQuery<ProblemaSolucao>(temp).AsQueryable();
        }

        public double BuscarTotalHorasChamado(int idChamado)
        {
            var result = _rep.context.ChamadoOcorrencias
                .Where(x => x.ChamadoId == idChamado)
                .GroupBy(b => b.ChamadoId)
                .Select(s => new { total = s.Sum(t => t.TotalHoras) });

            return result.Sum(x => x.total);
        }
    }
}
