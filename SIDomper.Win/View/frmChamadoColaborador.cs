using SIDomper.Dominio.Enumeracao;
using SIDomper.Dominio.ViewModel;
using SIDomper.Win.Utilitarios;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmChamadoColaborador : Form
    {
        private ChamadoOcorrenciaViewModel _chamadoOcorrenciaViewModel;
        int _id = 0;

        public frmChamadoColaborador()
        {
            Iniciar();
        }

        public frmChamadoColaborador(ChamadoOcorrenciaViewModel chamadoOcorrenciaViewModel)
        {
            Iniciar();
            _chamadoOcorrenciaViewModel = chamadoOcorrenciaViewModel;
        }

        private void Iniciar()
        {
            InitializeComponent();
            Grade.Configurar(ref dgvDados);
            UsrUsuario.Programa(EnProgramas.Usuario, true, true, "Colaborador", true);
        }

        private void LimparTela()
        {
            UsrUsuario.LimparTela();
            txtHoraInicial.Clear();
            txtHoraFinal.Clear();
        }

        private void Novo()
        {
            _id = RetorarIdMinimo();
            if (_id > 0)
                _id = 0;
            LimparTela();
            UsrUsuario.txtCodigo.Focus();
        }

        private void Editar()
        {
            //_id = 0;
            _id = Convert.ToInt32(dgvDados.CurrentRow.Cells["ChaOCol_Id"].Value.ToString());
            SetarDados(_id);
            //LimparTela();
            //var model = _chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores.FirstOrDefault(x => x.Id == _id);
            //if (model != null)
            //{
            //    _id = model.Id;
            //    txtHoraInicial.Text = model.HoraInicio.ToString();
            //    txtHoraFinal.Text = model.HoraFim.ToString();
            //    UsrUsuario.txtId.Text = model.UsuarioId.ToString();
            //    UsrUsuario.txtCodigo.txtValor.Text = model.CodUsuario.ToString();
            //    UsrUsuario.txtNome.Text = model.NomeUsuario;
            //}
            UsrUsuario.txtCodigo.Focus();
        }

        private void Salvar()
        {
            try
            {
                if (UsrUsuario.txtId.Text == "")
                    throw new Exception("Informe o Colaborador!");
                if (txtHoraInicial.Text == "  :")
                    throw new Exception("Informe a Hora Inicial!");
                if (txtHoraFinal.Text == "  :")
                    throw new Exception("Informe a Hora Final!");

                var model = new ChamadoOcorrColaboradorViewModel();
                if (_id > 0)
                    model = _chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores.FirstOrDefault(x => x.Id == _id);

                model.ChamadoOcorrenciaId = _chamadoOcorrenciaViewModel.Id;
                model.Id = _id;
                model.HoraInicio = TimeSpan.Parse(txtHoraInicial.Text);
                model.HoraFim = TimeSpan.Parse(txtHoraFinal.Text);
                model.UsuarioId = Convert.ToInt32(UsrUsuario.txtId.Text);
                model.NomeUsuario = UsrUsuario.txtNome.Text;
                if (_id <= 0)
                {
                    _chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores.Add(model);
                    CarregaGrid(_chamadoOcorrenciaViewModel);
                }
                LimparTela();
                UsrUsuario.txtCodigo.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtHoraInicial.Focus();
            }
        }

        private void Excluir()
        {
            if (dgvDados.RowCount > 0)
            {
                int id = Grade.RetornarId(ref dgvDados, "ChaOCol_Id");

                var model = _chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores.FirstOrDefault(x => x.Id == id);
                if (model != null)
                    _chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores.Remove(model);

                int selectedIndex = dgvDados.CurrentCell.RowIndex;
                if (selectedIndex > -1)
                {
                    dgvDados.Rows.RemoveAt(selectedIndex);
                    dgvDados.Refresh();
                }
            }
        }

        private void CarregaGrid(ChamadoOcorrenciaViewModel chamadoOcorrenciaViewModel)
        {
            dgvDados.Rows.Clear();
            if (chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores != null)
            {
                foreach (var item in chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores)
                {
                    dgvDados.Rows.Add(item.Id, item.HoraInicio, item.HoraFim, item.NomeUsuario);
                    //dgvDados.Rows.Add(item);
                }
            }
        }

        private int RetorarIdMinimo()
        {
            try
            {
                return _chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores.Min(x => x.Id) - 1;
            }
            catch
            {
                return 0;
            }
        }

        private void frmChamadoColaborador_Load(object sender, EventArgs e)
        {
            CarregaGrid(_chamadoOcorrenciaViewModel);
            if (dgvDados.RowCount > 0)
            {
                _id = Convert.ToInt32(dgvDados.CurrentRow.Cells["ChaOCol_Id"].Value.ToString());
                SetarDados(_id);
            }
        }

        private void SetarDados(int id)
        {
            //_id = Convert.ToInt32(dgvDados.CurrentRow.Cells["ChaOCol_Id"].Value.ToString());
            LimparTela();
            var model = _chamadoOcorrenciaViewModel.ChamadoOcorrenciaColaboradores.FirstOrDefault(x => x.Id == id);
            if (model != null)
            {
                _id = model.Id;
                txtHoraInicial.Text = model.HoraInicio.ToString();
                txtHoraFinal.Text = model.HoraFim.ToString();
                UsrUsuario.txtId.Text = model.UsuarioId.ToString();
                UsrUsuario.SetCodigoMask(model.CodUsuario.ToString());
                UsrUsuario.txtNome.Text = model.NomeUsuario;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void dgvDados_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvDados.RowCount > 0)
            {
                _id = Convert.ToInt32(dgvDados.CurrentRow.Cells["ChaOCol_Id"].Value.ToString());
                SetarDados(_id);
            }
        }

        private void dgvDados_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvDados.RowCount > 0)
            {
                _id = Convert.ToInt32(dgvDados.CurrentRow.Cells["ChaOCol_Id"].Value.ToString());
                SetarDados(_id);
            }
        }

        private void frmChamadoColaborador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmChamadoColaborador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (UsrUsuario.txtCodigo.txtValor.Focused)
                    UsrUsuario.PressionarF9(EnProgramas.Usuario);
            }
                if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
