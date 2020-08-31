using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.View
{
    public partial class frmQuadro : Form
    {
        public frmQuadro()
        {
            InitializeComponent();
        }

        private void frmQuadro_Shown(object sender, EventArgs e)
        {
            /*
             * No ONShow do quadro fazer duas requisições:
             * QuadroViewModel
             * =====================================
             * buscar as permissoes retornar boolean
             * permissao para: chamadoQuadro, Atividade, Solicitacao, agendamento, recados
             * Coluna Tempo (chamados e atividades) Mostrar Tempos
             *  CodstatusChamadoAbertura parametro(9, 1)
             *  CodstatusChamadoOcorrenciaAtendimento parametro(10, 1)
             *  CodStatusAtividadeAbertura(31,111)
             *  CodStatusAtividadeOcorrenciaAtendimento(32,111)
             *  Chamado:
             * Se o quadro que tem o codigoStatus = parametro 9 (CodstatusChamadoAbertura)
             *      CTempo
             * SeNao CodigoStatus = CodstatusChamadoOcorrenciaAtendimento (parametro 10)
             *      CTempoPar10
             * SeNao
             *      CTempoParOutro
             * o mesmo para Atividades
             * 
             * Permissao Solicitacao, mostar as opções do PopMenu das solicitações
             * Grades Altura e lagura
             * 
             * controle titulo tempo solicitacao nas grids parametro(45,3)
             * 
             * MostrarCheckBoxRecado
             * =====================================
             * Se tem Recados Então
             *      Abrir tela dos recados
             * Se não
             *      Abrir tela dos Chamados
             * Abrir o Timer intervalo de 60000 - a cada 1 minuto
             */
        }
    }
}
