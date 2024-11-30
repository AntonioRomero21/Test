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
    public partial class Config : UserControl
    {
        private ConnectorConfig connectorConfig;
        private ConnectorType type;
        private string value;
        public event EventHandler ConfigClick;
        public new Image BackgroundImage
        {
            get
            {
                return button.BackgroundImage;
            }
            set
            {
                button.BackgroundImage = value;
                button.Text = String.Empty;
            }
        }
        public string Value
        {
            get { return value; }
            set
            {
                this.value = value;
                label.Text = value;
            }
        }
        public Config()
        {
            InitializeComponent();
        }
        private void config_Click(object sender, EventArgs e)
        {
            int[] arr = value.Substring(2).Split(',').Select(Int32.Parse).ToArray();
            type = value.Substring(0, 2).Contains("M") ? ConnectorType.Male : ConnectorType.Female;
            connectorConfig = new ConnectorConfig(type, arr);
            ConfigClick?.Invoke(this, EventArgs.Empty);
        }
        public ConnectorConfig ConnectorConfig { get => connectorConfig; }
    }
}
