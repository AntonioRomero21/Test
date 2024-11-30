using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeldenCableInspection.Controls
{
    public partial class Table : UserControl
    {
        public Table()
        {
            InitializeComponent();
            programs.ScrollBars = ScrollBars.Horizontal;
            programsScrollbar.Scroll += programsScrollBar_Scroll;
            programs.Scroll += Programs_Scroll;
        }
        private void Programs_Scroll(object sender, ScrollEventArgs e)
        {
            //programsScrollbar.Value = e.NewValue;
        }
        private void programsScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            programs.FirstDisplayedScrollingRowIndex = e.NewValue;
        }
        public int SelectedID()
        {
            if (programs.CurrentCell is null)
            {
                return -1;
            }
            else
            {
                object id = programs.Rows[programs.CurrentCell.RowIndex].Cells[0].Value;
                return (int)id;
            }
        }
        internal void SetDataSource(DataTable dataTable)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    programs.DataSource = dataTable;
                    programs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    programs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    programs.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    programsScrollbar.Maximum = programs.RowCount;
                });
            }
        }

    }
}
