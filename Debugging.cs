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
    public partial class Debugging : Form
    {
        public RichTextBox LogData { get => logData; }
        //public RichTextBox LogModbus { get => logModbus; }
        public new event FormClosingEventHandler Closing;
        public Debugging()
        {
            InitializeComponent();
        }
        private void Debugging_FormClosing(object sender, FormClosingEventArgs e) => Closing?.Invoke(this, e);
        private void log_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(logData.Text);
        }
    }
}
