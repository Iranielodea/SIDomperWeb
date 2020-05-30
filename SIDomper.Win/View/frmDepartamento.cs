using SIDomper.Apresentacao.App;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Base;
using SIDomper.Win.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmDepartamento : frmBase
    {
        private DepartamentoViewModel _departamento;
        private DepartamentoApp _departamentoApp;
        int _Id;
        List<DepartamentoConsultaViewModel> _listaConsulta = new List<DepartamentoConsultaViewModel>();
        GridColunas<DepartamentoConsultaViewModel> _grid = new GridColunas<DepartamentoConsultaViewModel>();
        GridColunas<DepartamentoAcessoViewModel> _gridAcesso = new GridColunas<DepartamentoAcessoViewModel>();

        public frmDepartamento()
        {
            Iniciar();
            FiltrarDados("ABCDE");
            ModoPesquisa = false;
        }

        public frmDepartamento(string texto)
        {
            Iniciar();
            FiltrarDados(texto);
            ModoPesquisa = true;
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            EsconderTodasAbas();

            Grade.Configurar(ref dgvDados);
            Grade.Configurar(ref dgvAcesso, true, false);
            Grade.Configurar(ref dgvEmail, false, true);

            cbCampos.DataSource = Grade.ListarCampos(ref dgvDados);
            cbCampos.SelectedIndex = 1;
            cbPesquisa.Enabled = false;
        }

        private void FiltrarDados(string texto)
        {
            string sCampo = Grade.BuscarCampo(ref dgvDados, cbCampos.Text);

            _departamentoApp = new DepartamentoApp();
            string ativo = cboAtivo.Text;

            if (sCampo == "DescPrograma")
                throw new Exception("Não será possível pesquisar por este campo.");

            _listaConsulta = _departamentoApp.Filtrar(sCampo, texto, ativo.Substring(0, 1)).ToList();
            dgvDados.DataSource = _listaConsulta;
        }

        public override void Novo()
        {
            txtCodigo.txtValor.ReadOnly = false;
            try
            {
                _departamentoApp = new DepartamentoApp();
                _departamento = new DepartamentoViewModel();
                _departamento = _departamentoApp.Novo(Funcoes.IdUsuario);
                Funcoes.VerificarMensagem(_departamento.Mensagem);

                base.Novo();

                LimparTela();
                txtCodigo.txtValor.Text = _departamento.Codigo.ToString("0000");
                chkAtivo.Checked = _departamento.Ativo;
                chkAnexo.Checked = _departamento.MostrarAnexos;

                CarregarAcessos();
                MostrarQuadros();

                txtCodigo.txtValor.Focus();
                _Id = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparTela()
        {
            Tela.LimparTela(tbPrincipal);
            Tela.LimparTela(tpChamado);
            Tela.LimparTela(tpAtividade);
            Tela.LimparTela(tpSolicitacao);
            Tela.LimparTela(tpAgendamento);
            Tela.LimparTela(tpHorario);
            dgvAcesso.Rows.Clear();
            dgvEmail.Rows.Clear();
        }

        private void MostrarAbaChamado()
        {
            tcProgramas.Visible = true;
            tcProgramas.TabPages.Remove(tpChamado);
            tcProgramas.TabPages.Add(tpChamado);
            tcProgramas.TabPages.Remove(tpAtividade);
            tcProgramas.TabPages.Remove(tpSolicitacao);
            tcProgramas.TabPages.Remove(tpAgendamento);
        }

        private void MostrarAbaAtividade()
        {
            tcProgramas.Visible = true;
            tcProgramas.TabPages.Remove(tpChamado);
            tcProgramas.TabPages.Remove(tpAtividade);
            tcProgramas.TabPages.Add(tpAtividade);
            tcProgramas.TabPages.Remove(tpSolicitacao);
            tcProgramas.TabPages.Remove(tpAgendamento);
        }

        private void MostrarAbaSolicitacao()
        {
            tcProgramas.Visible = true;
            tcProgramas.TabPages.Remove(tpChamado);
            tcProgramas.TabPages.Remove(tpAtividade);
            tcProgramas.TabPages.Remove(tpSolicitacao);
            tcProgramas.TabPages.Add(tpSolicitacao);
            tcProgramas.TabPages.Remove(tpAgendamento);
        }

        private void MostrarAbaAgendamento()
        {
            tcProgramas.Visible = true;
            tcProgramas.TabPages.Remove(tpChamado);
            tcProgramas.TabPages.Remove(tpAtividade);
            tcProgramas.TabPages.Remove(tpSolicitacao);
            tcProgramas.TabPages.Remove(tpAgendamento);
            tcProgramas.TabPages.Add(tpAgendamento);
        }

        private void EsconderTodasAbas()
        {
            tcProgramas.TabPages.Remove(tpChamado);
            tcProgramas.TabPages.Remove(tpAtividade);
            tcProgramas.TabPages.Remove(tpSolicitacao);
            tcProgramas.TabPages.Remove(tpAgendamento);
        }

        public override void Editar()
        {
            try
            {
                _departamentoApp = new DepartamentoApp();
                _departamento = new DepartamentoViewModel();
                _departamento = _departamentoApp.Editar(Grade.RetornarId(ref dgvDados, "Dep_Id"), Funcoes.IdUsuario);
                btnSalvar.Enabled = Funcoes.PermitirEditar(_departamento.Mensagem);

                base.Editar();

                LimparTela();

                txtCodigo.txtValor.Text = _departamento.Codigo.ToString("0000");
                txtNome.Text = _departamento.Nome;
                chkAtivo.Checked = _departamento.Ativo;
                chkAnexo.Checked = _departamento.MostrarAnexos;

                chkChaAbertura.Checked = _departamento.ChamadoAbertura;
                chkChaOcorrencia.Checked = _departamento.ChamadoOcorrencia;
                chkChaQuadro.Checked = _departamento.ChamadoQuadro;
                chkChaStatus.Checked = _departamento.ChamadoStatus;

                chkAtiAbertura.Checked = _departamento.AtividadeAbertura;
                chkAtiOcorrencia.Checked = _departamento.AtividadeOcorrencia;
                chkAtiQuadro.Checked = _departamento.AtividadeQuadro;
                chkAtiStatus.Checked = _departamento.AtividadeStatus;

                chkSolAbertura.Checked = _departamento.SolicitaAbertura;
                chkSolAnalise.Checked = _departamento.SolicitaAnalise;
                chkSolOcorGeral.Checked = _departamento.SolicitacaoOcorrenciaGeral;
                chkSolOcorRegra.Checked = _departamento.SolicitacaoOcorrenciaRegra;
                chkSolOcorTecnica.Checked = _departamento.SolicitacaoOcorrenciaTecnica;
                chkSolQuadro.Checked = _departamento.SolicitacaoQuadro;
                chkSolStatus.Checked = _departamento.SolicitacaoStatus;

                txtHoraInicial.Text = _departamento.HoraInicial.ToString();
                txtHoraFinal.Text = _departamento.HoraFinal.ToString();

                chkAgeQuadro.Checked = _departamento.AgencamentoQuadro;

                CarregarEmail();
                CarregarAcessos();
                MostrarQuadros();

                txtNome.Focus();                
                _Id = _departamento.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CarregarEmail()
        {
            dgvEmail.Rows.Clear();

            if (_departamento.DepartamentosEmail != null)
            {
                foreach (var item in _departamento.DepartamentosEmail)
                {
                    dgvEmail.Rows.Add(item.Id, item.Email);
                }
            }
        }

        private void CarregarAcessos()
        {
            dgvAcesso.Rows.Clear();
            if (_departamento.DepartamentoAcessos != null)
            {
                foreach (var item in _departamento.DepartamentoAcessos)
                {
                    dgvAcesso.Rows.Add(item.Id, item.Programa, item.DescricaoPrograma, item.Acesso, item.Incluir, item.Editar, item.Excluir, item.Relatorio);
                }
            }
        }

        public override void Filtrar()
        {
            FiltrarDados(txtTexto.Text);
            base.Filtrar();
        }

        public override void Excluir()
        {
            base.Excluir();

            if (Funcoes.Confirmar("Confirmar Exclusão?"))
            {
                try
                {
                    _departamentoApp = new DepartamentoApp();
                    int id = Grade.RetornarId(ref dgvDados, "Dep_Id");
                    var model = _departamentoApp.Excluir(id, Funcoes.IdUsuario);
                    Funcoes.VerificarMensagem(model.Mensagem);

                    _listaConsulta.Remove(_listaConsulta.First(x => x.Id == id));
                    dgvDados.DataSource = _listaConsulta.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public override void Salvar()
        {
            try
            {
                _departamentoApp = new DepartamentoApp();
                _departamento.Id = _Id;
                _departamento.Ativo = chkAtivo.Checked;
                _departamento.Codigo = Funcoes.StrToInt(txtCodigo.txtValor.Text);
                _departamento.Nome = txtNome.Text;

                _departamento.MostrarAnexos = chkAnexo.Checked;

                _departamento.ChamadoAbertura = chkChaAbertura.Checked;
                _departamento.ChamadoOcorrencia = chkChaOcorrencia.Checked;
                _departamento.ChamadoQuadro = chkChaQuadro.Checked;
                _departamento.ChamadoStatus = chkChaStatus.Checked;

                _departamento.AtividadeAbertura = chkAtiAbertura.Checked;
                _departamento.AtividadeOcorrencia = chkAtiOcorrencia.Checked;
                _departamento.AtividadeQuadro = chkAtiQuadro.Checked;
                _departamento.AtividadeStatus = chkAtiStatus.Checked;

                _departamento.SolicitaAbertura = chkSolAbertura.Checked;
                _departamento.SolicitaAnalise = chkSolAnalise.Checked;
                _departamento.SolicitacaoOcorrenciaGeral = chkSolOcorGeral.Checked;
                _departamento.SolicitacaoOcorrenciaRegra = chkSolOcorRegra.Checked;
                _departamento.SolicitacaoOcorrenciaTecnica = chkSolOcorTecnica.Checked;
                _departamento.SolicitacaoQuadro = chkSolQuadro.Checked;
                _departamento.SolicitacaoStatus = chkSolStatus.Checked;

                _departamento.HoraInicial = Funcoes.StrToHoraNull(txtHoraInicial.Text);
                _departamento.HoraFinal = Funcoes.StrToHoraNull(txtHoraFinal.Text);

                _departamento.AgencamentoQuadro = chkAgeQuadro.Checked;

                SalvarEmail();
                SalvarAcessos();

                var model = _departamentoApp.Salvar(_departamento);

                Funcoes.VerificarMensagem(model.Mensagem);

                _listaConsulta = _departamentoApp.Filtrar("Dep_Id", model.Id.ToString(), "T", false).ToList();
                dgvDados.DataSource = _listaConsulta;

                base.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalvarEmail()
        {
            if (_departamento.DepartamentosEmail == null)
                _departamento.DepartamentosEmail = new List<DepartamentoEmailViewModel>();

            _departamento.DepartamentosEmail.Clear();
            foreach (DataGridViewRow item in this.dgvEmail.Rows)
            {
                if (item.Cells["Email"].Value == null)
                    continue;

                if (item.Cells["Email"].Value.ToString().Trim() == "")
                    throw new Exception("Informe o email!");

                var itemTemp = new DepartamentoEmailViewModel();

                int id;
                try
                {
                    id = Funcoes.StrToInt(item.Cells["Id"].Value.ToString());
                }
                catch
                {
                    id = 0;
                }

                itemTemp.Id = id;
                itemTemp.Email = item.Cells["Email"].Value.ToString();
                itemTemp.DepartamentoId = _Id;

                _departamento.DepartamentosEmail.Add(itemTemp);
            }
        }

        private void SalvarAcessos()
        {
            if(_departamento.DepartamentoAcessos == null)
                _departamento.DepartamentoAcessos = new List<DepartamentoAcessoViewModel>();

            _departamento.DepartamentoAcessos.Clear();
            foreach (DataGridViewRow item in this.dgvAcesso.Rows)
            {
                if (item.Cells["programa"].Value == null)
                    continue;

                var itemTemp = new DepartamentoAcessoViewModel();

                int id;
                try
                {
                    id = Funcoes.StrToInt(item.Cells["Id"].Value.ToString());
                }
                catch
                {
                    id = 0;
                }

                itemTemp.Id = id;
                itemTemp.DepartamentoId = _Id;
                itemTemp.Acesso = bool.Parse(item.Cells["Acesso"].Value.ToString());
                itemTemp.DescricaoPrograma = item.Cells["DescPrograma"].Value.ToString();
                itemTemp.Editar = bool.Parse(item.Cells["ProgEditar"].Value.ToString());
                itemTemp.Excluir = bool.Parse(item.Cells["ProgExcluir"].Value.ToString());
                itemTemp.Incluir = bool.Parse(item.Cells["ProgIncluir"].Value.ToString());
                itemTemp.Programa = int.Parse(item.Cells["Programa"].Value.ToString());
                itemTemp.Relatorio = bool.Parse(item.Cells["ProgRelatorio"].Value.ToString());

                _departamento.DepartamentoAcessos.Add(itemTemp);
            }
        }

        public override void Pesquisar()
        {
            if (dgvDados.RowCount > 0 && ModoPesquisa)
            {
                Funcoes.IdSelecionado = Grade.RetornarId(ref dgvDados, "Dep_Id");
                DialogResult = DialogResult.OK;
                base.Pesquisar();
            }
        }

        private void BuscarDados()
        {
            FiltrarDados(txtTexto.Text);
            cbCampos.Focus();
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    BuscarDados();
                    break;
                case Keys.Down:
                    Grade.ProximoRegistro(ref dgvDados);
                    break;
                case Keys.Up:
                    Grade.RegistroAnterior(ref dgvDados);
                    break;
            }
        }

        private void dgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //_grid.OrdenarColunas(ref dgvDados, _listaConsulta, e);
            //cbCampos.SelectedIndex = e.ColumnIndex - 1;
        }

        private void dgvAcesso_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //_gridAcesso.OrdenarColunas(ref dgvAcesso, _departamento.DepartamentoAcessos.ToList(), e);
        }

        private void ExcluirEmail()
        {
            if (Funcoes.Confirmar("Confirmar exclusão?"))
            {
                int selectedIndex = dgvEmail.CurrentCell.RowIndex;
                if (selectedIndex > -1)
                {
                    dgvEmail.Rows.RemoveAt(selectedIndex);
                    dgvEmail.Refresh();
                }
            }
        }

        private void dgvEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (tabControl2.SelectedTab == tpEmail)
                    {
                        ExcluirEmail();
                    }
                }
            }
        }

        private void btnExcluirEmail_Click(object sender, EventArgs e)
        {
            ExcluirEmail();
        }

        private void dgvAcesso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarQuadros();
        }

        private void MostrarQuadros()
        {
            int programa = Grade.RetornarId(ref dgvAcesso, "programa");
            switch (programa)
            {
                case 1:
                    MostrarAbaChamado();
                    break;
                case 3:
                    MostrarAbaSolicitacao();
                    break;
                case 111:
                    MostrarAbaAtividade();
                    break;
                case 112:
                    MostrarAbaAgendamento();
                    break;
                default:
                    tcProgramas.Visible = false;
                    break;
            }
            dgvAcesso.Focus();
        }

        private void dgvAcesso_KeyUp(object sender, KeyEventArgs e)
        {
            MostrarQuadros();
        }
    }
}
