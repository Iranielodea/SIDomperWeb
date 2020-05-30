using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIDomper.Win.Utilitarios
{
    public class GridColunas<T>
    {
        public void OrdenarColunas(ref DataGridView grade, List<T> lista, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string strColumnName = grade.Columns[e.ColumnIndex].DataPropertyName;
                SortOrder strSortOrder = ObterOrdem(e.ColumnIndex, ref grade);

                if (strSortOrder == SortOrder.Ascending)
                {
                    lista = lista.OrderBy(x => typeof(T).GetProperty(strColumnName).GetValue(x, null)).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(x => typeof(T).GetProperty(strColumnName).GetValue(x, null)).ToList();
                }
                grade.DataSource = lista;
                grade.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
            }
            catch
            {
                // nada
            }
        }

        private SortOrder ObterOrdem(int columnIndex, ref DataGridView grid)
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
    }
}
