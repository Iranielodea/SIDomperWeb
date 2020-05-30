using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.Utilitarios
{
    public static class Grade
    {
        public static void Configurar(ref DataGridView grid, bool editar = false, bool incluir = false)
        {
            grid.AutoGenerateColumns = false;

            if (incluir)
            {
                grid.AllowUserToAddRows = true;
                grid.ReadOnly = false;
                grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
            
            if (editar == true)
            {
                if (!incluir)
                    grid.AllowUserToAddRows = false;
                grid.ReadOnly = false;
                grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }

            if (incluir == false && editar == false)
            {
                grid.AllowUserToAddRows = false;
                grid.ReadOnly = true;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            grid.MultiSelect = false;
            grid.RowsDefaultCellStyle.BackColor = Color.Gray;
            grid.RowsDefaultCellStyle.ForeColor = Color.Black;
            grid.RowsDefaultCellStyle.SelectionBackColor = Color.Maroon;
            grid.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.Silver;
        }

        public static int RetornarId(ref DataGridView grid, string id)
        {
            if (grid.RowCount > 0)
            {
                string texto = grid.CurrentRow.Cells[id].Value.ToString();
                int resultado = Convert.ToInt32(texto);
                return resultado;
            }
            throw new Exception("Não há Registro!");
        }

        public static string RetornarValorCampo(ref DataGridView grid, string campo)
        {
            if (grid.RowCount > 0)
            {
                try
                {
                    return grid.CurrentRow.Cells[campo].Value.ToString();
                }
                catch
                {
                    return "";
                }
            }
            throw new Exception("Não há Registro!");
        }

        public static List<string> ListarCampos(ref DataGridView grid)
        {
            var lista = new List<string>();
            for(int i = 0; i < grid.Columns.Count; i++)
            {
                if (grid.Columns[i].Visible)
                    lista.Add(grid.Columns[i].HeaderText);
            }
            return lista;
        }

        public static string BuscarCampo(ref DataGridView grid, string campo)
        {
            string resultado = "";
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                if(grid.Columns[i].HeaderText == campo)
                {
                    resultado = grid.Columns[i].Name;
                }
            }
            if (resultado == "")
                resultado = grid.Columns[0].Name;
            return resultado;
        }

        public static SortOrder ObterOrdem(int columnIndex, ref DataGridView grid)
        {
            if (grid.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
       grid.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                grid.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                grid.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }

        public static void ProximoRegistro(ref DataGridView grid)
        {
            if (grid.CurrentRow != null)
                grid.CurrentCell =
                    grid
                    .Rows[Math.Min(grid.CurrentRow.Index + 1, grid.Rows.Count - 1)]
                    .Cells[grid.CurrentCell.ColumnIndex];
        }

        public static void RegistroAnterior(ref DataGridView grid)
        {
            try
            {
                if (grid.CurrentRow != null)
                    grid.CurrentCell =
                        grid
                        .Rows[Math.Min(grid.CurrentRow.Index - 1, grid.Rows.Count - 1)]
                        .Cells[grid.CurrentCell.ColumnIndex];
            }
            catch
            {
                // nada
            }
        }

        public static void TeclaEnterKeyDown(ref DataGridView grid, KeyEventArgs e, int colunaInicial)
        {
            if (e.KeyData == Keys.Enter)
            {
                int col = grid.CurrentCell.ColumnIndex;
                int row = grid.CurrentCell.RowIndex;

                if (col < grid.ColumnCount - 1)
                {
                    col++;
                }
                else
                {
                    col = colunaInicial; // 1;
                    row++;
                }

                if (row == grid.RowCount)
                    grid.Rows.Add();

                grid.CurrentCell = grid[col, row];
                e.Handled = true;
            }
        }

        public static void TelcaEnterSelectionChanged(ref DataGridView grid, int colunaInicial, DataGridViewCell celWasEndEdit)
        {
            //if (MouseButtons != 0) return;

            if (celWasEndEdit != null && grid.CurrentCell != null)
            {
                // if we are currently in the next line of last edit cell 
                if (grid.CurrentCell.RowIndex == celWasEndEdit.RowIndex + 1 &&
                 grid.CurrentCell.ColumnIndex == celWasEndEdit.ColumnIndex)
                {
                    int iColNew;
                    int iRowNew = 0;
                    if (celWasEndEdit.ColumnIndex >= grid.ColumnCount - 1)
                    {
                        iColNew = colunaInicial; // 1;
                        iRowNew = grid.CurrentCell.RowIndex;
                    }
                    else
                    {
                        iColNew = celWasEndEdit.ColumnIndex + 1;
                        iRowNew = celWasEndEdit.RowIndex;
                    }
                    grid.CurrentCell = grid[iColNew, iRowNew];
                }
            }
            celWasEndEdit = null;
        }

        public static void FormatoTime(ref DataGridView grid, string campo)
        {
            /*
             * informar no evento do grid dgvDados_CellFormatting
             */
            try
            {
                grid.Columns[campo].DefaultCellStyle.Format = @"hh\:mm";
            }
            catch
            {
                // nada
            }
        }

        public static void ExcluirRegistro(ref DataGridView grid)
        {
            if (grid.RowCount > 0)
            {
                int selectedIndex = grid.CurrentCell.RowIndex;
                if (selectedIndex > -1)
                {
                    grid.Rows.RemoveAt(selectedIndex);
                    grid.Refresh();
                }
            }
        }
    }
}
