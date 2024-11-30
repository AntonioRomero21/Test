using BeldenCableInspection.Controls;
using BeldenCableInspection.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace BeldenCableInspection.Controls
{
    public partial class Connector : UserControl
    {
        private ConnectorSelection selection = ConnectorSelection.Multiple;
        private bool ringValue = false;
        private bool ringEnabled;
        private bool bodyValue = false;
        private bool bodyEnabled;
        private Image connectorOn = Resources.ConnectorOn_min;
        private Image connectorOff = Resources.ConnectorOff_min;
        //Uri uriConnectorOn = new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"/Resources/ConnectorOn-min.png", UriKind.Absolute);
        //Uri uriConnectorOff = new Uri(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"/Resources/ConnectorOff-min.png", UriKind.Absolute);
        /// <summary>
        /// <param name="Config">The poles in the cable. Format example: 3,4,5.</param>
        /// </summary>
        private ConnectorType type;
        private int[] config;
        /// <summary>
        /// <param name="Variation">The variation specification for the color cabling.</param>
        /// </summary>
        //private int variation = 1;
        public event EventHandler PoleClick;
        public event EventHandler RingClick;
        public event EventHandler BodyClick;
        public System.Drawing.Color PoleBackColor
        {
            get
            {
                Pole pole = Controls.Find("pole1", true)[0] as Pole;
                return pole.PoleBackColor;
            }
            set
            {
                foreach (Control control in Controls)
                    if (control is Pole)
                        (control as Pole).PoleBackColor = value;
            }
        }
        public Connector()
        {
            InitializeComponent();
            type = ConnectorType.Male;
            if (config is null) Config = new int[] { 1, 2, 3, 4, 5 };
        }
        private void SetPolesConfig(int[] config, ConnectorType type)
        {
            RemovePoles();
            foreach (int pole in config)
            {
                foreach (Control control in Controls)
                {
                    if (control is Pole)
                    {
                        if ((control as Pole).Number == pole)
                        {
                            (control as Pole).Visible = true;
                        }
                    }
                }
            }
        }
        public void SetActivePoles(int[] activePoles)
        {
            SetActivePoles(String.Join(",", activePoles));
        }
        public void SetActivePole(int activePole)
        {
            SetActivePoles(activePole.ToString());
        }
        private void SetActivePoles(string poles)
        {
            TurnOffPoles();
            string[] polesArr = poles.Split(',');
            foreach (string pole in polesArr)
            {
                foreach (Control control in Controls)
                {
                    if (control is Pole)
                        if ((control as Pole).Number.ToString() == pole)
                            (control as Pole).Active = true;
                }
            }
        }
        private void RemovePoles()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Pole)
                    control.Visible = false;
            }
        }
        private void TurnOff()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Pole)
                    (control as Pole).Active = false;
            }
            RingValue = false;
        }
        private void TurnOffPoles()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Pole)
                    (control as Pole).Active = false;
            }
        }
        private void body_Click(object sender, EventArgs e)
        {
            if (bodyEnabled)
            {
                BodyValue = !BodyValue;
                BodyClick?.Invoke(this, e);
            }
        }
        private void ring_Click(object sender, EventArgs e)
        {
            if (ringEnabled)
            {
                RingValue = !ringValue;
                //PictureBox b = sender as PictureBox;
                //b.BackgroundImage = RingValue ? connectorOn : connectorOff;
                //b.BackgroundImageLayout = ImageLayout.Stretch;
                RingClick?.Invoke(this, e);
            }
        }
        private void pole_Click(object sender, EventArgs e)
        {
            switch (selection)
            {
                case ConnectorSelection.Single:
                    int pole = (sender as Pole).Number;
                    SetActivePoles(pole.ToString());
                    PoleClick?.Invoke(sender, new PoleClickEventArgs(pole));
                    break;
                case ConnectorSelection.Multiple:
                    List<int> selectedPoles = new List<int>();
                    foreach (Control control in Controls)
                    {
                        if (control is Pole)
                            if ((control as Pole).Active)
                                selectedPoles.Add((control as Pole).Number);
                    }
                    int[] poles = new int[selectedPoles.ToArray().Length];
                    Array.Copy(selectedPoles.ToArray(), poles, selectedPoles.ToArray().Length);
                    PoleClick?.Invoke(sender, new PoleClickEventArgs(poles));
                    break;
            }
        }

        internal void AllPolesOn(bool value)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Pole)
                    (control as Pole).Active = value;
            }
        }

        public ConnectorSelection Selection { get => selection; set => selection = value; }
        public bool RingValue
        {
            get => ringValue;
            set
            {
                if (ringValue != value)
                {
                    ringValue = value;
                    try
                    {
                        ring.Image = value ? connectorOn : connectorOff;
                    }
                    catch (Exception e)
                    {
                        new Thread(() => System.Windows.Forms.MessageBox.Show(e.StackTrace)).Start();
                    }
                    //ring.LoadAsync(value ? uriConnectorOn.AbsolutePath : uriConnectorOff.AbsolutePath);
                }
            }
        }
        public bool RingEnabled
        {
            get => ringEnabled;
            set => ringEnabled = value;
        }
        public bool BodyValue
        {
            get => bodyValue;
            set
            {
                bodyValue = value;
                body.BackColor = value ?
                    System.Drawing.Color.FromArgb(Colors.Green.R, Colors.Green.G, Colors.Green.B) :
                    System.Drawing.Color.FromArgb(153, 153, 153);
            }
        }
        public bool BodyEnabled
        {
            get => bodyEnabled; set
            {
                bodyEnabled = value;
                if (value)
                {
                    body.Visible = true;
                }
                else
                {
                    BodyValue = false;
                    body.Visible = false;
                    body.BackColor = System.Drawing.Color.FromArgb(113, 113, 113);
                    body.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(113, 113, 113);
                    body.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(113, 113, 113);
                }
            }
        }
        public int[] Config
        {
            get => config;
            set
            {
                if (value != null)
                {
                    config = value;
                    SetPolesConfig(config, Type);
                }
            }
        }
        public ConnectorType Type
        {
            get => type;
            set
            {
                type = value;
                if (type == ConnectorType.Male)
                {
                    pole1.Number = 1;
                    pole2.Number = 2;
                    pole3.Number = 3;
                    pole4.Number = 4;
                }
                else if (type == ConnectorType.Female)
                {
                    pole2.Number = 1;
                    pole1.Number = 2;
                    pole4.Number = 3;
                    pole3.Number = 4;
                }
                pole5.Number = 5;
            }
        }
    }
}
