using SIDomper.Dominio.Entidades;
using SIDomper.Infra.ADO;
using SIDomper.Infra.EF;
using SIDomper.Dominio.Enumeracao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Linq;

namespace SIDomper.Servicos.Regras
{
    public class OrcamentoServico
    {
        private readonly List<OrcamentoItem> _orcamentoItems = new List<OrcamentoItem>();

        private readonly OrcamentoEF _rep;
        private readonly OrcamentoADO _repADO;
        private UsuarioServico _usuarioServico;

        public OrcamentoServico()
        {
            _rep = new OrcamentoEF();
            _repADO = new OrcamentoADO();
            _usuarioServico = new UsuarioServico();
        }

        public Orcamento ObterPorId(int id)
        {
            var model = _rep.ObterPorId(id);
            decimal TotalItem = 0;
            decimal TotalParcela = 0;
            foreach (var item in model.OrcamentoItens)
            {
                TotalItem += item.ValorLicencaImpl;
            }

            foreach (var item in model.OrcamentoVencimentos)
            {
                TotalParcela += item.Valor;
            }

            model.TotalOrcamento = TotalItem;
            model.TotalParcelas = TotalParcela;

            return model;
        }

        public Orcamento ObterPorNumero(int numero)
        {
            return _rep.ObterPorNumero(numero);
        }

        public List<OrcamentoConsulta> Filtrar(int idUsuario, OrcamentoFiltro filtro, string campo, string texto)
        {
            //return _repADO.Filtrar(idUsuario, filtro, campo, texto);
            return _rep.Filtrar(idUsuario, filtro, campo, texto);
        }

        public void GerarParcelas(Orcamento model)
        {
            decimal ValorPrimeira = 0;
            decimal ValorOutras = 0;
            int contador = 1;

            var forma = new FormaPagtoServico().ObterPorId(model.FormaPagtoId.Value);
            if (forma != null)
            {
                var listaFormas = forma.FormaPagtoItens;

                Funcoes.FuncaoGeral.CalcularParcelas(listaFormas.Count, model.TotalParcelas, ref ValorPrimeira, ref ValorOutras);

                foreach (var item in listaFormas)
                {
                    var parcela = new OrcamentoVencimento();
                    DateTime data = model.Data.AddDays(item.Dias);
                    parcela.Data = data;
                    parcela.Descricao = "";
                    parcela.Orcamento = model;
                    parcela.Parcela = contador;

                    if (contador == 1)
                        parcela.Valor = ValorPrimeira;
                    else
                        parcela.Valor = ValorOutras;

                    model.OrcamentoVencimentos.Add(parcela);
                    contador++;
                }
            }
        }

        public void Salvar(Orcamento model)
        {
            if (model.UsuarioId == 0)
                throw new Exception("Informe o Usuário do Orçamento!");

            if (string.IsNullOrEmpty(model.RazaoSocial))
                throw new Exception("Informe a Razão Social do Orçamento!");

            if (model.TipoId == 0)
                throw new Exception("Informe o Tipo");

            if (model.Id > 0)
            {
                if (model.FormaPagtoId == 0)
                    throw new Exception("Informe a Forma de Pagamento!");

                if (model.SubTipo == 0 || model.SubTipo == null)
                    throw new Exception("Informe o Tipo (Telefone Ativo, Passivo, Visita Cliente...)!");
            }

            if (model.Data == null)
                throw new Exception("Informe a Data do Orçamento!");

            if (string.IsNullOrWhiteSpace(model.RazaoSocial))
                throw new Exception("Informe a Razão Social do Orçamento!");

            string documento = Funcoes.FuncaoGeral.SomenteNumero(model.Dcto);
            bool valido = true;

            if (documento.Length == 11)
                valido = Funcoes.Validacao.IsCpf(documento);
            if (documento.Length > 11)
                valido = Funcoes.Validacao.IsCnpj(documento);

            if (valido == false)
                throw new Exception("CPF ou CNPJ inválido!");

            documento = Funcoes.FuncaoGeral.SomenteNumero(model.CPFRespresentanteLegal);
            if (documento.Length == 11)
                valido = Funcoes.Validacao.IsCpf(documento);

            if (valido == false)
                throw new Exception("CPF do representante legal inválido!");

            ValidarItens(model);
            ValidarOcorrencia(model);
            ValidarVencimentos(model);
            ValidarEmail(model);

            using (var scope = new TransactionScope())
            {
                if (model.Id == 0)
                {
                    model.Numero = _rep.IncrementarNumero();
                    model.Situacao = 1; // em analise
                    model.EmailEnviado = false;
                }

                _rep.Salvar(model);
                scope.Complete();
            }
        }

        public void Replicar(int idOrcamento)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    _rep.Replicar(idOrcamento);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        {
            if (id > 0)
                _rep.Excluir(id);
        }

        public void AtualizarSituacao(int codigo, int id)
        {
            string opcao = "1234";
            if (!opcao.Contains(codigo.ToString()))
            {
                throw new Exception("Código da Situação Inválida!");
            }

            var model = ObterPorId(id);
            if (model != null)
            {
                ValidarSituacao(model, codigo);
                model.DataSituacao = DateTime.Now.Date;
                model.Situacao = codigo;
                _rep.Salvar(model);
            }
        }

        public void EnviarEmailParaSupervisor(Orcamento model, int idUsuario, bool ocorrencia = false)
        {
            string email = RetornarEmailSupervisor(idUsuario);
            if (model.Situacao == 2 || model.Situacao == 4) // aprovado ou faturado
            {
                string emailParametro = BuscarEmailOrcamentoAprovado();
                if (!string.IsNullOrEmpty(emailParametro))
                {
                    email = email + ";" + emailParametro;
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine("Orçamento enviado para:");
            sb.AppendLine("");
            sb.AppendLine("Número: " + model.Numero.ToString("000000"));
            sb.AppendLine("Razão Social: " + model.RazaoSocial);
            sb.AppendLine("Contato: " + model.Contato);
            sb.AppendLine("Usuário: " + model.Usuario.Nome);

            if (model.Situacao == 4)
                sb.AppendLine("Situação: A Faturar");
            else
                sb.AppendLine("Situação: " + RetornarSituacao(model.Situacao));
            sb.AppendLine("");

            if (ocorrencia)
            {
                int contador = 1;
                foreach (var item in model.OrcamentoOcorrencias)
                {
                    if (contador == 1)
                        sb.AppendLine("Ocorrências");
                    sb.AppendLine("Data: " + item.Data.ToShortDateString());
                    sb.AppendLine("Usuário: " + item.Usuario.Nome);
                    sb.AppendLine("Descrição:");
                    sb.AppendLine(item.Descricao);

                    contador++;
                }
            }

            string assunto = "Orçamento: " + model.Numero.ToString("000000");

            var ContaEmailServico = new ContaEmailServico();
            ContaEmailServico.EnviarEmail(idUsuario, email, "", assunto, sb.ToString(), "");
        }

        public void EmAnalise(Orcamento model, int idUsuario)
        {
            int id = AtualizarStatus(model, 1, idUsuario, true);

            if (id > 0)
                EnviarEmailParaSupervisor(model, idUsuario);
        }

        public void Aprovado(Orcamento model, int idUsuario)
        {
            ValidarSituacao(model, 2);
            int id = AtualizarStatus(model, 2, idUsuario, true);

            if (id > 0)
                EnviarEmailParaSupervisor(model, idUsuario, true);
        }

        public void NaoAprovado(Orcamento model, int idUsuario)
        {
            int id = AtualizarStatus(model, 3, idUsuario, true);
            if (id > 0)
                EnviarEmailParaSupervisor(model, idUsuario, true);
        }

        public void Faturado(Orcamento model, int idUsuario)
        {
            ValidarSituacao(model, 4);
            int id = AtualizarStatus(model, 4, idUsuario, true);

            if (id > 0)
                EnviarEmailParaSupervisor(model, idUsuario, true);
        }

        public Observacao ObservacaoPadrao()
        {
            var model = new ObservacaoServico().ObterPadrao(9);
            return model;
        }

        public Observacao ObservacaoEmailPadrao()
        {
            var model = new ObservacaoServico().ObterEmailPadrao(9);
            return model;
        }

        public bool PermissaoAcesso(int idUsuario)
        {
            return _usuarioServico.PermissaoUsuario(idUsuario, EnProgramas.Orcamento, EnTipoManutencao.Acessar);
        }

        public bool PermissaoIncluir(int idUsuario)
        {
            return _usuarioServico.PermissaoUsuario(idUsuario, EnProgramas.Orcamento, EnTipoManutencao.Incluir);
        }

        public bool PermissaoEditar(int idUsuario)
        {
            return _usuarioServico.PermissaoUsuario(idUsuario, EnProgramas.Orcamento, EnTipoManutencao.Editar);
        }

        public bool PermissaoExcluir(int idUsuario)
        {
            return _usuarioServico.PermissaoUsuario(idUsuario, EnProgramas.Orcamento, EnTipoManutencao.Excluir);
        }

        public bool PermissaoRelatorio(int idUsuario)
        {
            return _usuarioServico.PermissaoUsuario(idUsuario, EnProgramas.Orcamento, EnTipoManutencao.Imprimir);
        }

        private int AtualizarStatus(Orcamento model, int tipoSituacao, int idUsuario, bool atualizar)
        {
            int id = 0;
            if (ValidarUsuario(model, tipoSituacao, idUsuario))
            {
                if (atualizar)
                {
                    id = model.Id;

                    //if (tipoSituacao == 3)
                    // ver MotivoNaoAprovado
                    AtualizarSituacao(tipoSituacao, model.Id);
                }
            }
            return id;
        }

        private bool ValidarUsuario(Orcamento model, int tipoSituacao, int idUsuario) // faturado
        {
            if (model.Situacao == 4 && tipoSituacao == 4)
                throw new Exception("Situação atual já está faturado!");

            if (model.Situacao != 4) // nao faturado
                return true;

            bool retorno = false;
            var Usuario = new UsuarioServico().ObterPorId(idUsuario);
            if (Usuario.Adm)
                retorno = true;

            if (!retorno)
            {
                string texto = "Lib_Orcamento_Alt_Situacao";
                foreach (var item in Usuario.UsuariosPermissao)
                {
                    if (item.Sigla.ToUpper() == texto.ToUpper())
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        private string RetornarEmailSupervisor(int usuarioId)
        {
            DepartamentoEmailServico departamentoEmailServico = new DepartamentoEmailServico();
            var listaEmail = departamentoEmailServico.RetornarEmail(usuarioId);

            string email = "";
            int contador = 1;
            foreach (var item in listaEmail)
            {
                if (contador == 1)
                    email = item.Email;
                else
                    email = email + ";" + item.Email;

                return email;
            }
            return email;
        }

        private void ValidarItens(Orcamento model)
        {
            decimal TotalItem = 0;
            foreach (var item in model.OrcamentoItens)
            {
                if (item.ProdutoId == 0)
                    throw new Exception("Informe o Produto no Orçamento!");

                if (item.ValorLicencaImpl < 0)
                    throw new Exception("Valor Licença Negativo!");
                if (item.ValorDescontoImpl < 0)
                    throw new Exception("Valor Desconto de implantação Negativo!");
                if (item.ValorLicencaMensal < 0)
                    throw new Exception("Valor Licença mensal Negativo!");
                if (item.ValorDescontoMensal < 0)
                    throw new Exception("Valor Desconto Mensal Negativo");
                if (item.ValorDescontoImpl > item.ValorLicencaImpl)
                    throw new Exception("Valor Desconto Implantação maior que Valor Implantação!");
                if (item.ValorDescontoMensal > item.ValorLicencaMensal)
                    throw new Exception("Valor Desconto Mensal maior que Valor Mensal!");

                TotalItem += item.ValorLicencaImpl;

                foreach (var modulo in item.OrcamentoItemModulos)
                {
                    if (modulo.ModuloId == 0)
                        throw new Exception("Informe o módulo do item no Orçamento!");
                }
            }

            model.TotalOrcamento = TotalItem;
        }

        private void ValidarOcorrencia(Orcamento model)
        {
            foreach (var item in model.OrcamentoOcorrencias)
            {
                if (item.Data < model.Data)
                    throw new Exception("Data da Ocorrência Menor que Data do Orçamento!");
            }
        }

        private void ValidarVencimentos(Orcamento model)
        {
            decimal totalItem = 0;
            foreach (var item in model.OrcamentoVencimentos)
            {
                totalItem += item.Valor;
                if (item.Data < model.Data)
                    throw new Exception("Data do Vencimento Menor que a Data do Orçamento!");
            }

            model.TotalParcelas = totalItem;

            if (model.TotalOrcamento != model.TotalParcelas)
                throw new Exception("Valor Total das Parcelas diferente do Valor do Orçamento!");
        }

        private void ValidarEmail(Orcamento model)
        {
            foreach (var item in model.OrcamentoEmails)
            {
                if (string.IsNullOrEmpty(item.Email))
                    throw new Exception("Informe o Email!");
            }
        }

        private void ValidarSituacao(Orcamento model, int situacao)
        {
            StringBuilder sb = new StringBuilder();
            if (situacao == 2 || situacao == 4) // aprovado e faturado
            {
                if (string.IsNullOrEmpty(model.Fantasia))
                    sb.AppendLine("Informe o nome da Fantasia!");
                if (string.IsNullOrEmpty(model.Dcto))
                    sb.AppendLine("Informe o CNPJ!");
                if (string.IsNullOrEmpty(model.Logradouro))
                    sb.AppendLine("Informe o Endereço!");
                if (string.IsNullOrEmpty(model.Bairro))
                    sb.AppendLine("Informe o Bairro!");
                if (model.CidadeId == 0)
                    sb.AppendLine("Informe a Cidade!");
                if (string.IsNullOrEmpty(model.CEP))
                    sb.AppendLine("Informe o CEP!");
                if (string.IsNullOrEmpty(model.Fone1))
                    sb.AppendLine("Informe o Fone1!");
            }

            if (situacao == 4)
            {
                if (string.IsNullOrEmpty(model.RepresentanteLegal))
                    sb.AppendLine("Informe o Representante Legal!");
                if (string.IsNullOrEmpty(model.CPFRespresentanteLegal))
                    sb.AppendLine("Informe o CPF do Representante Legal!");
            }

            if (sb.ToString() != "")
                throw new Exception(sb.ToString());
        }

        private string BuscarEmailOrcamentoAprovado()
        {
            var parametroServico = new ParametroServico();
            var model = parametroServico.ObterPorParametro(39, 0);
            return model.Valor;
        }

        private string RetornarSituacao(int situacao)
        {
            return new OrcamentoNaoAprovadoServico().RetornarDescricaoSituacao(situacao);
        }

        public void AdicionarItem(OrcamentoItem orcamentoItem)
        {
            OrcamentoItem item = _orcamentoItems.FirstOrDefault(x => x.Id == orcamentoItem.Id);

            if (item == null)
            {
                _orcamentoItems.Add(orcamentoItem);
            }
        }

        public void RemoverItem(OrcamentoItem orcamentoItem)
        {
            _orcamentoItems.RemoveAll(l => l.Id == orcamentoItem.Id);
        }

        public void LimparItens()
        {
            _orcamentoItems.Clear();
        }

        public IEnumerable<OrcamentoItem> ItensOrcamento
        {
            get { return _orcamentoItems; }
        }
    }
}
