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
    public partial class Message : Form
    {

        public event EventHandler Continue;
        public Message()
        {
            InitializeComponent();
        }
        public Message(String message)
        {
            InitializeComponent();
            msg.Text = message.Trim();
        }
        public Message(String title, String message)
        {
            InitializeComponent();
            ttle.Text = title;
            msg.Text = message.Trim();
        }
        private void continue_Click(object sender, EventArgs e) => Continue?.Invoke(this, EventArgs.Empty);
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
