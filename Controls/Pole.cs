using BeldenCableInspection.Properties;
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
    public partial class Pole : UserControl
    {
        private bool active;
        private Image poleOn = Resources.PoleOn_min;
        private Image poleOff = Resources.PoleOff_min;
        private int number;
        public Color PoleBackColor { get => button.BackColor; set => button.BackColor = value; }
        public new event EventHandler Click;
        public bool Active
        {
            get => active;
            set
            {
                if (active != value)
                {
                    active = value;
                    button.Image = active ? poleOn : poleOff;
                    /*
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.LoadAsync(active ? uriPoleOn.AbsolutePath : uriPoleOff.AbsolutePath);
                     */
                    label1.BackColor = active ? Color.FromArgb(0, 200, 0) : Color.FromArgb(153, 153, 153);
                }
            }
        }
        public int Number
        {
            get => number;
            set
            {
                number = value;
                label1.Text = number.ToString();
            }
        }
        public Pole() => InitializeComponent();

        private void button_Click(object sender, EventArgs e) => Click.Invoke(this, e);
    }
}
