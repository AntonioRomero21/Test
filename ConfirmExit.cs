using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeldenCableInspection
{
    public partial class ConfirmExit : Form
    {
        public event EventHandler Exit;
        public event EventHandler Cancel;
        public ConfirmExit()
        {
            InitializeComponent();
            exit.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            cancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
        }
        private void exit_Click(object sender, EventArgs e) => Exit?.Invoke(this, EventArgs.Empty);

        private void cancel_Click(object sender, EventArgs e) => Cancel?.Invoke(this, EventArgs.Empty);
        #region Flicker fix (DO NOT REMOVE)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        #endregion
    }
}
