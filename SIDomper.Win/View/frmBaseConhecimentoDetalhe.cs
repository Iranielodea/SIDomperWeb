using SIDomper.Apresentacao.App;
using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmBaseConhecimentoDetalhe : Form
    {
        public frmBaseConhecimentoDetalhe()
        {
            InitializeComponent();
        }

        public frmBaseConhecimentoDetalhe(int id, EnProgramas enProgramas)
        {
            InitializeComponent();
            if (enProgramas == EnProgramas.BaseConh)
                CarregarBaseConhecimento(id);
            else if (enProgramas == EnProgramas.Chamado)
                CarregarChamado(id);

            txtTexto.ReadOnly = true;
        }


        private void CarregarChamado(int id)
        {
            var chamadoApp = new ChamadoApp();
            var model = chamadoApp.ObterPorId(id);

            // ver permissao para abertura

            string nivel = "";

            switch(model.Nivel)
            {
                case 1: nivel = "Baixo";
                    break;
                case 2:
                    nivel = "Normal";
                    break;
                case 3:
                    nivel = "Alto";
                    break;
                case 4:
                    nivel = "Crítico";
                    break;
            }

            SubTitulo("ABERTURA");

            FormatarLinha("Id: " + model.Id.ToString("000000")
                + " - Data Abertura: " + model.DataAbertura.ToShortDateString()
                + " - Hora: " + model.HoraAbertura
                + " - Usuário Abertura: " + model.NomeUsuario);
            FormatarLinha("Cliente: " + model.NomeCliente);
            FormatarLinha("Contato: " + model.Contato);
            FormatarLinha("Nível: " + nivel);
            FormatarLinha("Módulo: " + model.NomeModulo);
            FormatarLinha("Produto: " + model.NomeProduto);
            FormatarLinha("Tipo: " + model.NomeTipo);
            FormatarLinha("Status: " + model.NomeStatus);
            FormatarLinha("Revenda: " + model.NomeRevenda);
            FormatarLinha("Consultor: " + model.NomeConsultor);
            FormatarLinha("Descrição: " + model.Descricao);
            FormatarLinha("");
            FormatarLinha(Traco());

            CarregarChamadoOcorrencia(model);
            CarregarChamadoStatus(model);
            FormatarLinha(Traco());
            SubTitulo("Status Atual: " + model.NomeStatus);
        }

        private void CarregarChamadoStatus(ChamadoViewModel model)
        {
            if (model.ChamadosStatus != null)
            {
                foreach (var item in model.ChamadosStatus)
                {
                    if (!string.IsNullOrWhiteSpace(item.NomeStatus))
                    {
                        SubTitulo("STATUS");
                        FormatarLinha("Data: " + item.Data);
                        FormatarLinha("Hora: " + item.Hora);
                        FormatarLinha("Status: " + item.NomeStatus);
                        FormatarLinha("Usuário: " + item.NomeUsuario);
                        FormatarLinha("");
                        FormatarLinha(Traco());
                        FormatarLinha("");
                    }
                }
                SubTitulo(model.NomeStatus);
            }
        }

        private void SubTitulo(string texto)
        {
            txtTexto.SelectionColor = Color.Red;
            FormatarLinha(texto);
            txtTexto.SelectionColor = Color.Black;
        }

        private void CarregarChamadoOcorrencia(ChamadoViewModel model)
        {
            // permissao de ocorrencias
            if (model.ChamadoOcorrencias != null)
            {
                foreach (var item in model.ChamadoOcorrencias)
                {
                    if (item.HoraInicio.Minutes > 0)
                    {
                        SubTitulo("OCORRÊNCIA");
                        FormatarLinha("Documento: " + item.Documento);
                        FormatarLinha("Data: " + item.Data.ToShortDateString());
                        FormatarLinha("Hora Inicial: " + item.HoraInicio);
                        FormatarLinha("Hora Final: " + item.HoraFim);
                        FormatarLinha("Usuário: " + item.NomeUsuario);

                        if (item.ChamadoOcorrenciaColaboradores != null)
                        {
                            foreach (var colaborador in item.ChamadoOcorrenciaColaboradores)
                            {
                                FormatarLinha("Colaborador: " + colaborador.NomeUsuario);
                            }

                            FormatarLinha("Anexo: " + item.Anexo);
                            FormatarLinha("Descrição Problema: " + item.DescricaoTecnica);
                            FormatarLinha("Descrição Solução: " + item.DescricaoSolucao);
                            FormatarLinha("");
                            FormatarLinha(Traco());
                            FormatarLinha("");
                        }
                    }
                }

                double totalHoras = model.ChamadoOcorrencias.Sum(x => x.TotalHoras);
                SubTitulo("TEMPO TOTAL: " + Dominio.Funcoes.Utils.DecimalToHora(totalHoras));
            }
        }

        private void FormatarLinha(string texto, bool novaLinha = true)
        {
            txtTexto.AppendText(texto);
            if (novaLinha)
                txtTexto.AppendText(Environment.NewLine);
        }

        private void CarregarBaseConhecimento(int id)
        {
            var baseConhApp = new BaseConhApp();
            var model = baseConhApp.ObterPorId(id);

            SubTitulo("ABERTURA");
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("ID: " + model.Id.ToString("000000"));
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Data: " + model.Data.ToShortDateString());
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Nome: " + model.Nome);
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Usuário: " + model.NomeUsuario);
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Módulo: " + model.NomeModulo);
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Produto: " + model.NomeProduto);
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Tipo: " + model.NomeTipo);
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Status: " + model.NomeStatus);
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText("Anexo: " + model.Anexo);
            txtTexto.AppendText(Environment.NewLine);

            txtTexto.AppendText(Traco());
            txtTexto.AppendText(Environment.NewLine);

            SubTitulo("DESCRIÇÃO");
            txtTexto.AppendText(Environment.NewLine);
            txtTexto.AppendText(model.Descricao);
            txtTexto.SelectionStart = 1;
        }

        private string Traco()
        {
            int i;
            string traco = "_";
            for (i = 0; i < 120; i++)
                traco += "_";
            return traco;
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
