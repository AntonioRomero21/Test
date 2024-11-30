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
    public partial class Colores : UserControl
    {
        private string Wirecolor;
        private Color selectedColor;
        public WireColor wirecolor;
        public event EventHandler OnClickPic;
        public Color SelectedColor { get => selectedColor; set => selectedColor = value; }
        public Colores()
        {
            InitializeComponent();
            Brown.MouseClick += OnPictureBoxClick;
            Blue.MouseClick += OnPictureBoxClick;
            Black.MouseClick += OnPictureBoxClick;
            White.MouseClick += OnPictureBoxClick;
            Green.MouseClick += OnPictureBoxClick;
        }
        private Color GetPixelColor(Point location, PictureBox pictureBox = null)
        {
            Bitmap bitmap = (Bitmap)pictureBox.Image;
            return bitmap.GetPixel(location.X, location.Y);
        }
        private WireColor GetWireColor(string WireColorName)
        {
            switch (WireColorName)
            {
                case "Brown": return wirecolor = WireColor.Brown;
                case "Blue": return wirecolor = WireColor.Blue;
                case "White": return wirecolor = WireColor.White;
                case "Black": return wirecolor = WireColor.Black;
                case "Green": return wirecolor = WireColor.Green;
                default: return WireColor.NONE;
            }
        }
        private void OnPictureBoxClick(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                Color color = GetPixelColor(e.Location,pictureBox);
                selectedColor = color;
                Wirecolor = pictureBox.Name;
                GetWireColor(Wirecolor);
                OnClickPic?.Invoke(this, EventArgs.Empty);
            }
        }
        public Color GetColor(string WireColorName)
        {
            GetWireColor(WireColorName);
            PictureBox pictureBox = (PictureBox)this.Controls.Find(WireColorName, true).FirstOrDefault();
            if (pictureBox != null)
            {
                Bitmap bitmap = (Bitmap)pictureBox.Image;
                Color color = bitmap.GetPixel(50, 50);
                selectedColor = color;
                return selectedColor;
            }
            else
                return selectedColor;
        }
    }
}
