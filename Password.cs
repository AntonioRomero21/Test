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
    public partial class Password : Form
    {
        public event EventHandler PasswordCorrect;
        public event EventHandler @continue;
        public event EventHandler PasswordIncorrect;
        public Password()
        {
            InitializeComponent();
            txtpassword.PasswordChar = '*';
        }
        private void Continue_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "1122")
                PasswordCorrect?.Invoke(this, EventArgs.Empty);
            else
                PasswordIncorrect?.Invoke(this, EventArgs.Empty);
            @continue?.Invoke(this, EventArgs.Empty);
        }
        public void Clear(object sender, EventArgs e) => txtpassword.Clear();
    }
}
