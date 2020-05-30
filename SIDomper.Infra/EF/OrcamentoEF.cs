using SIDomper.Dominio.Entidades;
using SIDomper.Infra.Comun;
using SIDomper.Infra.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDomper.Infra.EF
{
    public class OrcamentoEF
    {
        private readonly Repositorio<Orcamento> _rep;

        public OrcamentoEF()
        {
            _rep = new Repositorio<Orcamento>();
        }

        public Orcamento ObterPorId(int id)
        {
            return _rep.find(id);
        }

        public Orcamento ObterPorNumero(int numero)
        {
            return _rep.First(x => x.Numero == numero);
        }

        public void Salvar(Orcamento model)
        {
            if (model.Id > 0)
                _rep.Update(model);
            else
                _rep.Add(model);

            //_rep.Salvar(model);
            _rep.Commit();
        }

        public void Disposed()
        {
            _rep.Dispose();
        }

        public void Excluir(int id)
        {
            var model = ObterPorId(id);
            _rep.Deletar(model);
            _rep.Commit();
        }

        public void Replicar(int id)
        {
            Repositorio<OrcamentoItem> repItem = new Repositorio<OrcamentoItem>();
            Repositorio<OrcamentoEmail> repEmail = new Repositorio<OrcamentoEmail>();
            Repositorio<Contato> repContato = new Repositorio<Contato>();
            Repositorio<OrcamentoVencimento> repVencimento = new Repositorio<OrcamentoVencimento>();
            Repositorio<OrcamentoItemModulo> repItemModulo = new Repositorio<OrcamentoItemModulo>();

            DateTime dataOrcamento = DateTime.Now.Date;

            Orcamento orcamento = new Orcamento();

            var model = _rep.context.Orcamentos.AsNoTracking().Single(x => x.Id == id);
            if (model != null)
            {
                dataOrcamento = model.Data;
                orcamento = model;
                orcamento.Numero = IncrementarNumero();
                orcamento.Data = DateTime.Now.Date;
                orcamento.DataSituacao = orcamento.Data;

                _rep.Add(orcamento);
                _rep.Commit();
            }

            //=================================================================
            // itens
            //List<OrcamentoItem> Itens = new List<OrcamentoItem>();
            var Itens = _rep.context.OrcamentoItens.AsNoTracking().Where(x => x.OrcamentoId == id).ToList();
            if (Itens != null)
            {
                foreach (var item in Itens)
                {
                    int idItem = item.Id;
                    item.Id = 0;
                    item.OrcamentoId = orcamento.Id;
                    repItem.Add(item);

                    repItem.Commit();
                    //=================================================================
                    // itens modulos

                    var itensModulos = repItemModulo.context.OrcamentoItemModulos.AsNoTracking().Where(x => x.OrcamentoItemId == idItem).ToList();
                    if (itensModulos != null)
                    {
                        foreach (var modulo in itensModulos)
                        {
                            modulo.Id = 0;
                            modulo.OrcamentoItemId = item.Id;
                            repItemModulo.Add(modulo);
                        }
                        repItemModulo.Commit();
                    }
                }
            }
            //=================================================================
            // emails
            var emails = _rep.context.OrcamentoEmails.AsNoTracking().Where(x => x.OrcamentoId == id).ToList();
            if (emails != null)
            {
                foreach (var email in emails)
                {
                    email.Id = 0;
                    email.OrcamentoId = orcamento.Id;
                    repEmail.Add(email);
                }
                repEmail.Commit();
            }

            //=================================================================
            // contatos
            var contatos = _rep.context.Contatos.AsNoTracking().Where(x => x.OrcamentoId == id).ToList();
            if (contatos != null)
            {
                foreach (var contato in contatos)
                {
                    contato.Id = 0;
                    contato.OrcamentoId = orcamento.Id;
                    repContato.Add(contato);
                }
                repContato.Commit();
            }

            //=================================================================
            // Vencimentos
            var vencimentos = _rep.context.OrcamentoVencimentos.AsNoTracking().Where(x => x.OrcamentoId == id).ToList();
            if (vencimentos != null)
            {
                foreach (var vencto in vencimentos)
                {
                    vencto.Id = 0;
                    vencto.OrcamentoId = orcamento.Id;

                    // calcular novo vencimento vencimento - data do orcamento
                    DateTime dataVencimento = vencto.Data;
                    TimeSpan dias = dataVencimento.Subtract(dataOrcamento);
                    vencto.Data = DateTime.Now.Date + dias;

                    repVencimento.Add(vencto);
                }
                repVencimento.Commit();
            }
        }

        public int IncrementarNumero()
        {
            ParametroEF parametroEF = new ParametroEF();
            var parametroModel = parametroEF.ObterPorParametro(37, 0);

            int valor = 0;
            if (parametroModel != null)
            {
                valor = Convert.ToInt32(parametroModel.Valor);
                valor++;

                parametroModel.Valor = valor.ToString();
                parametroEF.Salvar(parametroModel);
            }
            return valor;
        }

        public List<OrcamentoConsulta> Filtrar(int idUsuario, OrcamentoFiltro filtro, string campo, string texto)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT ");
            sb.AppendLine("Orc_Data as DataD,");
            sb.AppendLine("Orc_Id as Id,");
            sb.AppendLine("Orc_Numero as Numero,");
            sb.AppendLine("Orc_Situacao as SituacaoI,");
            sb.AppendLine("Orc_RazaoSocial as NomeCliente,");
            sb.AppendLine("Orc_EmailEnviado as EmailEnviadoB,");
            sb.AppendLine("Usu_Nome as NomeUsuario ");
            sb.AppendLine("FROM Orcamento");
            sb.AppendLine("LEFT JOIN Prospect ON Orc_Prospect = Pros_Id   ");
            sb.AppendLine("LEFT JOIN Usuario ON Orc_Usuario = Usu_Id   ");
            sb.AppendLine("LEFT JOIN Cliente ON Orc_Cliente = Cli_Id   ");
            sb.AppendLine("LEFT JOIN Cidade ON Orc_Cidade = Cid_Id   ");
            sb.AppendLine("LEFT JOIN Tipo ON Orc_Tipo = Tip_Id ");
            sb.AppendLine(" WHERE Orc_Id IS NOT NULL");
            sb.AppendLine(" AND " + campo + " like '%" + texto + "%'");

            sb.AppendLine(Filtro(idUsuario, filtro));

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Revenda = Usu_Revenda) OR (Usu_Revenda IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            sb.AppendLine(" AND EXISTS(");
            sb.AppendLine(" 	SELECT 1 FROM Usuario WHERE ((Cli_Id = Usu_Cliente) OR (Usu_Cliente IS NULL))");
            sb.AppendLine(" 	AND Usu_Id = " + idUsuario + ")");

            if (!PermissaoOrcamentoUsuario(idUsuario))
                sb.AppendLine(" AND Orc_Usuario = " + idUsuario);


            List<OrcamentoConsulta> lista = _rep.context.Database.SqlQuery<OrcamentoConsulta>(sb.ToString()).ToList();

            var listaOrcamento = new List<OrcamentoConsulta>();

            foreach(var item in lista)
            {
                var model = new OrcamentoConsulta();
                string emailEnviado = "Não";
                if (item.EmailEnviadoB)
                    emailEnviado = "Sim";

                model.EmailEnviado = emailEnviado;
                model.Data = item.DataD.ToString("dd/MM/yyyy");
                model.NomeCliente = item.NomeCliente;
                model.NomeUsuario = item.NomeUsuario;
                model.Numero = item.Numero;
                model.Id = item.Id;
                model.Situacao = item.Situacao;

                listaOrcamento.Add(model);
            }

            return listaOrcamento;
        }

        private string Filtro(int idUsuario, OrcamentoFiltro filtro)
        {
            var sb = new StringBuilder();

            if (filtro.DataInicial != null)
                sb.AppendLine(" AND Orc_Data >= " + Funcoes.DataIngles(filtro.DataInicial));
            if (filtro.DataFinal != null)
                sb.AppendLine(" AND Orc_Data <= " + Funcoes.DataIngles(filtro.DataFinal));
            if (filtro.DataSituacaoInicial != null)
                sb.AppendLine(" AND Orc_DataSituacao >= " + Funcoes.DataIngles(filtro.DataSituacaoInicial));
            if (filtro.DataSituacaoFinal != null)
                sb.AppendLine(" AND Orc_DataSituacao <= " + Funcoes.DataIngles(filtro.DataSituacaoFinal));
            if (filtro.CidadeId > 0)
                sb.AppendLine(" AND Orc_Cidade = " + filtro.CidadeId);
            if (filtro.ClienteId > 0)
                sb.AppendLine(" AND Orc_Cliente <= " + filtro.ClienteId);
            if (filtro.EmailEnviado == "S")
                sb.AppendLine(" AND Orc_EmailEnviado = 1");
            if (filtro.EmailEnviado == "N")
                sb.AppendLine(" AND Orc_EmailEnviado = 0");
            if (filtro.Situacao > 0)
                sb.AppendLine(" AND Orc_Situacao = " + filtro.Situacao);
            if (filtro.SubTipo > 0)
                sb.AppendLine(" AND Orc_SubTipo = " + filtro.SubTipo);
            if (filtro.TipoId > 0)
                sb.AppendLine(" AND Orc_Tipo = " + filtro.TipoId);
            if (filtro.UsuarioId > 0)
                sb.AppendLine(" AND Orc_Usuario = " + filtro.UsuarioId);
            if (filtro.Numero > 0)
                sb.AppendLine(" AND Orc_Numero = " + filtro.Numero);

            return sb.ToString();
        }

        private bool PermissaoOrcamentoUsuario(int idUsuario)
        {
            var query = from usu in _rep.context.Usuarios
                        join per in _rep.context.UsuarioPermissoes on usu.Id equals per.UsuarioId
                        where usu.Id == idUsuario && per.Sigla == "Lib_Orcamento_Usuario"
                        select new
                        {
                            usu.Id
                        };

            return query.Any();
        }
    }
}
