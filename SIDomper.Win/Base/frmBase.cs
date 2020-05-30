using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.Base
{
    public partial class frmBase : Form
    {
        private int _campoSelecionado;

        public bool ModoPesquisa = false;
        public frmBase()
        {
            InitializeComponent();

            btnSair.Click += (s, e) => Sair();
            btnNovo.Click += (s, e) => Novo();
            btnEditar.Click += (s, e) => Editar();
            btnExcluir.Click += (s, e) => Excluir();
            btnSalvar.Click += (s, e) => Salvar();
            btnVoltar.Click += (s, e) => Voltar();
            btnVoltar2.Click += (s, e) => Voltar();
            btnImprimir.Click += (s, e) => Imprimir();
            btnFiltrar.Click += (s, e) => Filtrar();
            btnFiltro.Click += (s, e) => Filtro();
            cboAtivo.SelectedIndex = 0;

            btnNovo.Location = new Point(11, 14);
            btnEditar.Location = new Point(112, 14);
            btnExcluir.Location = new Point(213, 14);
            btnFiltro.Location = new Point(314, 14);
            btnSair.Location = new Point(415, 14);

            btnSalvar.Location = new Point(11, 14);
            btnVoltar2.Location = new Point(112, 14);

            btnFiltrar.Location = new Point(11, 14);
            btnImprimir.Location = new Point(112, 14);
            btnVoltar.Location = new Point(213, 14);
            cbPesquisa.SelectedIndex = 0;
        }

        public virtual void Pesquisar()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
            {
                Close();
            }
        }
        public virtual void Sair()
        {
            this.Close();
        }

        public virtual void Novo()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
                TelaEdicao();
        }

        public virtual void Editar()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
                TelaEdicao();
        }

        public virtual void Salvar()
        {
            if (tabControl1.SelectedTab == tpEditar)
            {
                TelaPesquisa();
                txtTexto.Focus();
            }
        }

        public virtual void Voltar()
        {
            TelaPesquisa();
            
            txtTexto.Focus();
        }

        public virtual void Filtrar()
        {
            if (tabControl1.SelectedTab == tpFiltro)
                TelaPesquisa();
        }

        public virtual void Filtro()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
                TelaFiltro();
        }

        public virtual void Excluir()
        {
            //
        }

        public virtual void Imprimir()
        {

        }

        private void TelaEdicao()
        {
            _campoSelecionado = cbCampos.SelectedIndex;
            tabControl1.TabPages.Remove(tpPesquisa);
            tabControl1.TabPages.Add(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);
            tabControl2.SelectedIndex = 0;
        }

        private void TelaPesquisa()
        {
            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Add(tpPesquisa);
            tabControl1.TabPages.Remove(tpFiltro);
            cbCampos.SelectedIndex = _campoSelecionado;
        }

        private void TelaFiltro()
        {
            _campoSelecionado = cbCampos.SelectedIndex;
            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpPesquisa);
            tabControl1.TabPages.Add(tpFiltro);
        }

        private void frmBase_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Novo();
                    break;
                case Keys.F2:
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Editar();
                    break;
                case Keys.F3:
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Filtro();
                    break;
                case Keys.F4:
                    if (tabControl1.SelectedTab == tpFiltro)
                        Filtrar();
                    break;
                case Keys.F8:
                    if (tabControl1.SelectedTab == tpEditar)
                    {
                        if (btnSalvar.Enabled)
                        {
                            btnSalvar.Focus();
                            Salvar();
                        }
                    }
                    break;
                case Keys.F12:
                    Pesquisar();
                    break;
                case Keys.Escape:
                    if (tabControl1.SelectedTab == tpPesquisa)
                    {
                        if (txtTexto.Focused)
                            Sair();
                        else
                            txtTexto.Focus();
                    }

                    if (tpEditar.Focus() || tpFiltro.Focus())
                    {
                        Voltar();
                    }
                    break;
            }

            if (e.Control)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Excluir();
                }
            }
        }

        private void frmBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmBase_Shown(object sender, EventArgs e)
        {
            txtTexto.Focus();
        }

        private void txtTexto_Enter(object sender, EventArgs e)
        {
            txtTexto.SelectAll();
        }
    }
}
