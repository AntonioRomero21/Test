using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeldenCableInspection.Controls
{
    public partial class Keyboard : UserControl
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0x08000000;
                return param;
            }
        }
        public void FocusControl(Control control)
        {
            this.control = control;
        }
        public Control Control { get => control; set => control = value; }

        private Control control;
        public Keyboard()
        {
            InitializeComponent();
        }
        public Keyboard(Control control)
        {
            this.control = control;
            InitializeComponent();
        }

        private void tab_CheckedChanged(object sender, EventArgs e)
        {
            if (tab.Checked)
            {
                SendKeys.Send("{TAB}");
            }
            tab.Checked = false;
        }

        private void button93_Click(object sender, EventArgs e)
        {
            control.Focus();
            SendKeys.Send("{BACKSPACE}");
        }

        private void alt_CheckedChanged(object sender, EventArgs e)
        {
            if (alt.Checked == true)
            {
                altgr.Checked = true;
                alt.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                altgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
            {
                altgr.Checked = false;
                alt.BackColor = Color.FromArgb(35, 96, 155);
                altgr.BackColor = Color.FromArgb(35, 96, 155);
            }
        }

        private void altgr_CheckedChanged(object sender, EventArgs e)
        {
            if (altgr.Checked == true)
            {
                alt.Checked = true;
                alt.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
                altgr.BackColor = System.Drawing.ColorTranslator.FromHtml("#0076D7");
            }
            else
            {
                alt.Checked = false;
                alt.BackColor = Color.FromArgb(35, 96, 155);
                altgr.BackColor = Color.FromArgb(35, 96, 155);
            }
        }
        private void lshift_CheckedChanged(object sender, EventArgs e)
        {
            rshift.Checked = lshift.Checked;
            if (lshift.Checked == true)
            {
                lshift.BackColor = Color.FromArgb(229, 107, 0);
                rshift.BackColor = Color.FromArgb(229, 107, 0);

            }
            else
            {
                lshift.BackColor = Color.FromArgb(35, 96, 155);
                rshift.BackColor = Color.FromArgb(35, 96, 155);
            }

        }

        private void rshift_CheckedChanged(object sender, EventArgs e)
        {
            lshift.Checked = rshift.Checked;
            if (rshift.Checked == true)
            {
                lshift.BackColor = Color.FromArgb(229, 107, 0);
                lshift.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");

                rshift.BackColor = Color.FromArgb(229, 107, 0);
                rshift.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }
        }
        private void capslock_CheckedChanged(object sender, EventArgs e)
        {
           
            if (capslock.Checked == true)
            {
                
                capslock.BackColor = Color.FromArgb(229, 107, 0);
            }
            else
                capslock.BackColor = Color.FromArgb(35, 96, 155);

        }
        private void button49_Click(object sender, EventArgs e)
        {
            control.Focus();
            SendKeys.Send(" ");
        }
        private void button24_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("Q");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("q");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("W");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("w");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("E");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (checkBox5.Checked)
            {
                Process.Start("explorer.exe");
                checkBox5.Checked = false;
            }
            else
            {
                SendKeys.Send("e");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("R");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("r");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("T");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("t");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("Y");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("y");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("U");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("u");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("I");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("ı");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("O");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("o");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("P");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("p");
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{{}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("[");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{}}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("]");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("|");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("\\");
            }
        }
        private void button37_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("A");
                lshift.Checked = false;
                rshift.Checked = false;
            }

            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{A}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }

            else
            {
                SendKeys.Send("a");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("S");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("s");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("D");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("d");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("F");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("f");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("G");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("g");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("H");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("h");
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("J");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("j");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("K");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("k");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("L");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("l");
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send(":");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send(";");
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("\"");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("'");
            }
        }
        private void button47_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("Z");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{Z}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }
            else
            {
                SendKeys.Send("z");
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("X");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("x");
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("C");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{C}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }
            else
            {
                SendKeys.Send("c");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("V");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else if (lctrl.Checked || rctrl.Checked)
            {
                SendKeys.Send("^{V}");
                lctrl.Checked = false;
                rctrl.Checked = false;
            }
            else
            {
                SendKeys.Send("v");
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("B");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("b");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("N");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("n");
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (capslock.Checked || lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("M");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("m");
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("<");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send(",");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send(">");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send(".");
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("?");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("/");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{~}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("`");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("!");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("1");
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("@");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("2");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("#");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("3");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("$");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("4");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{%}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("5");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{^}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("6");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{&}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("7");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("*");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("8");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{(}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("9");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{)}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("0");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("_");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("-");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            control.Focus();
            if (lshift.Checked || rshift.Checked)
            {
                SendKeys.Send("{+}");
                lshift.Checked = false;
                rshift.Checked = false;
            }
            else
            {
                SendKeys.Send("=");
            }
        }
        private void button67_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //SendKeys.Send("{ENTER}");
        }
    }
}
