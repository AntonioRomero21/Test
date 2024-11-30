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
    public partial class ConfigSelector : UserControl
    {
        public event EventHandler OnConfigClick;
        private ConnectorConfig config;
        public ConnectorConfig ConnectorConfig { get => config; set => config = value; }
        public ConfigSelector()
        {
            InitializeComponent();
            foreach (Control control in Controls.Find("table", false)[0].Controls)
            {
                //Console.WriteLine(control.GetType());
                if (control is Config)
                {
                    (control as Config).ConfigClick += new EventHandler(delegate (object sender, EventArgs e) {
                        ConnectorConfig = (sender as Config).ConnectorConfig;
                        OnConfigClick?.Invoke(this, e);
                    });
                }
            }
        }
    }
}
