using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace BeldenCableInspection.Controls
{
    public partial class TitleBar : UserControl
    {
        private String version = String.Empty;
        public String Version
        {
            get => version;
            set
            {
                version = value;
                title.Text += " " + version;
            }
        }
        public event EventHandler Close;
        public TitleBar()
        {
            InitializeComponent();
        }
        private void buttonClose_Click(object sender, EventArgs e) => Close?.Invoke(sender, e);

        internal void DisableClose() => buttonClose.Visible = false;
        internal void EnableClose() => buttonClose.Visible = true;
    }
}
