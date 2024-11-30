using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeldenCableInspection.Views
{
    public partial class Loading : UserControl
    {
        private int panelBorderPixels = 5;
        public Loading()
        {
            InitializeComponent();
        }
        private void panelLeft_Paint(object sender, PaintEventArgs e) => paint_PanelBorders(sender as Panel, e, Color.Yellow, true, true, true, true);
        private void paint_PanelBorders(Panel panel, PaintEventArgs e, Color color, bool left, bool top, bool right, bool bottom)
        {
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
               left ? color : Color.Transparent, left ? panelBorderPixels : 0, left ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
               top ? color : Color.Transparent, top ? panelBorderPixels : 0, top ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
               right ? color : Color.Transparent, right ? panelBorderPixels : 0, right ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
               bottom ? color : Color.Transparent, bottom ? panelBorderPixels : 0, bottom ? ButtonBorderStyle.Solid : ButtonBorderStyle.None
           );
        }
    }
}
