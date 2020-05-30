using SIDomper.Dominio.Enumeracao;
using SIDomper.Win.Pesquisas;
using SIDomper.Win.Utilitarios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIDomper.Win.Componentes
{
    public partial class usrPesquisa : UserControl
    {
        private EnProgramas _enProgramas;
        private object _objeto = null;
        private bool _obrigatorio = false;
        private bool _mostrarBotao = true;
        private string _texto = "";
        private bool _editar = true;
        private EnTipos _enTipos;
        private EnStatus _enStatus;
        private string _mascara;
        private int _comprimento;

        public bool Modificou { get; set; }

        public usrPesquisa()
        {
            InitializeComponent();
        }

        public void SetCodigoMask(string campo)
        {
            if (!string.IsNullOrEmpty(campo))
            {
                Consultar(TipoPesquisa.Nenhum);
                int.TryParse(campo, out int valor);
                txtCodigo.txtValor.Text = valor.ToString(_mascara);
            }
            else
                txtCodigo.txtValor.Clear();
        }

        public string GetCodigoMask()
        {
            if (!string.IsNullOrEmpty(txtCodigo.txtValor.Text))
            {
                Consultar(TipoPesquisa.Nenhum);
                return Convert.ToInt32(txtCodigo.txtValor.Text).ToString(_mascara);
            }
            else
                return "";
        }

        public string FormatCodigoMask(string campo)
        {
            if (!string.IsNullOrEmpty(campo))
            {
                Consultar(TipoPesquisa.Nenhum);
                int.TryParse(campo, out int valor);
                return valor.ToString(_mascara);
            }
            else
                return "";
        }

        public object RetornarObjeto()
        {
            return _objeto;
        }

        public void Programa(EnProgramas enPrograma, bool obrigatorio = false, bool mostrarBotao = true, string texto = "", bool editar = true)
        {
            _enProgramas = enPrograma;
            _mostrarBotao = mostrarBotao;
            _obrigatorio = obrigatorio;
            _texto = texto;
            _editar = editar;
            _comprimento = txtNome.Width;
            Consultar(TipoPesquisa.Nenhum);
        }

        public void ProgramaTipo(EnProgramas enPrograma, bool obrigatorio = false, bool mostrarBotao = true, string texto = "", bool editar = true, EnTipos enTipos = EnTipos.Todos)
        {
            _enProgramas = enPrograma;
            _mostrarBotao = mostrarBotao;
            _obrigatorio = obrigatorio;
            _texto = texto;
            _editar = editar;
            _enTipos = enTipos;
            _comprimento = txtNome.Width;
            Consultar(TipoPesquisa.Nenhum);
        }

        public void ProgramaStatus(EnProgramas enPrograma, bool obrigatorio = false, bool mostrarBotao = true, string texto = "", bool editar = true, EnStatus enStatus = EnStatus.Todos)
        {
            _enProgramas = enPrograma;
            _mostrarBotao = mostrarBotao;
            _obrigatorio = obrigatorio;
            _texto = texto;
            _editar = editar;
            _enStatus = enStatus;
            _comprimento = txtNome.Width;
            Consultar(TipoPesquisa.Nenhum);
        }

        public void LimparTela()
        {
            txtId.Clear();
            txtCodigo.txtValor.Clear();
            txtNome.Clear();
        }

        public void PressionarF9(EnProgramas enPrograma)
        {
            _enProgramas = enPrograma;
            Consultar(TipoPesquisa.Tela);
        }

        private void usrPesquisa_Enter(object sender, EventArgs e)
        {
            Modificou = false;
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.txtValor.Modified)
                Consultar(TipoPesquisa.Id);
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            Consultar(TipoPesquisa.Tela);
            txtNome.Focus();
        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            if (txtNome.Modified)
                Consultar(TipoPesquisa.Descricao);
        }

        private void ConsultarUsuario(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaUsuario();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString(_mascara);
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarDepartamento(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaDepartamento();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarContaEmail(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaContaEmail();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarRevenda(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaRevenda();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarCliente(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaCliente();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString(_mascara);
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarProduto(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaProduto();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarVersao(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaVersao();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Id.ToString("000000");
                    txtNome.Text = model.VersaoStr;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarCategoria(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaCategoria();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarModulo(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaModulo();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarCidade(int codigo, string nome, TipoPesquisa tipoPesquisa)
        {
            var consulta = new ConsultaCidade();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarTipo(int codigo, string nome, TipoPesquisa tipoPesquisa, EnTipos enTipos)
        {
            var consulta = new ConsultaTipo();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa, enTipos);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void ConsultarStatus(int codigo, string nome, TipoPesquisa tipoPesquisa, EnStatus enStatus)
        {
            var consulta = new ConsultaStatus();
            try
            {
                if (tipoPesquisa != TipoPesquisa.Tela)
                {
                    txtId.Text = "";
                    txtCodigo.txtValor.Text = "";
                    txtNome.Text = "";
                }
                var model = consulta.Pesquisar(codigo, nome, tipoPesquisa, enStatus);
                if (model != null)
                {
                    txtId.Text = model.Id.ToString();
                    txtCodigo.txtValor.Text = model.Codigo.ToString("0000");
                    txtNome.Text = model.Nome;
                    _objeto = model;
                    Modificou = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtCodigo.Focus();
            }
            txtId.Modified = false;
            txtCodigo.txtValor.Modified = false;
            txtNome.Modified = false;
        }

        private void Consultar(TipoPesquisa tipoPesquisa)
        {
            _mascara = Tela.MaskProduto;
            switch ((int)_enProgramas)
            {
                case 4:
                    {
                        Verificacao("Versao");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarVersao(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 100:
                    {
                        Verificacao("Revenda");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarRevenda(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 101:
                    {
                        Verificacao("Produto");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarProduto(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 102:
                    {
                        Verificacao("Módulo");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarModulo(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 103:
                    {
                        _mascara = Tela.MaskCliente;
                        Verificacao("Cliente");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarCliente(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 104:
                    {
                        Verificacao("Usuário");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarUsuario(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 105:
                    {
                        Verificacao("Departamento");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarDepartamento(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 106:
                    {
                        Verificacao("Tipo");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarTipo(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa, _enTipos);
                        break;
                    }
                case 107:
                    {
                        Verificacao("Status");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarStatus(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa, _enStatus);
                        break;
                    }
                case 110:
                    {
                        Verificacao("Conta Email");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarContaEmail(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 121:
                    {
                        Verificacao("Cidade");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarCidade(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
                case 124:
                    {
                        Verificacao("Categoria");
                        if (tipoPesquisa != TipoPesquisa.Nenhum)
                            ConsultarCategoria(Funcoes.StrToInt(txtCodigo.txtValor.Text), txtNome.Text, tipoPesquisa);
                        break;
                    }
            }
        }

        private void Verificacao(string nome)
        {
            string sNome = _texto;
            if (_texto == "")
                sNome = nome;

            if (!_mostrarBotao)
            {
                txtNome.Location = new Point(76, 21);
                txtNome.Width = _comprimento + 37;
                btnConsulta.Visible = false;
            }

            if (_obrigatorio)
                lblNome.Text = sNome + "*";
            else
                lblNome.Text = nome;

            if (!_editar)
            {
                txtCodigo.txtValor.BackColor = Color.Silver;
                txtNome.BackColor = Color.Silver;
                txtCodigo.txtValor.ReadOnly = true;
                txtNome.ReadOnly = true;
                btnConsulta.Enabled = false;
                txtCodigo.txtValor.TabStop = false;
                txtNome.TabStop = false;
                btnConsulta.TabStop = false;
            }
        }

        private void usrPesquisa_Resize(object sender, EventArgs e)
        {
            _comprimento = txtNome.Width;
        }
    }
}
