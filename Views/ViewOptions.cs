using BeldenCableInspection.Controls;
using BeldenCableInspection.Properties;
using BeldenCableInspection.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BeldenCableInspection.Controllers;
using System.Threading;

namespace BeldenCableInspection.Views
{
    public partial class ViewOptions : UserControl
    {
        private ConnectorConfig configA, configB;
        private Wire wire = new Wire();
        Button button;
        Keyboard keyboard; 
        private bool updateFile = false;
        int[] poleA = new int[0], poleB = new int[0];
        Side side;
        private IEnumerable<IGrouping<int, Test>> wires { get; set; }
        private Test test;
        private File file;
        private int PosCamera, PosAngle, numberprogram;
        private ModbusSlave slave;
        private CameraIV3 camera; 
        private Int32 positionA = 13973, positionB = -15621;
        private event EventHandler sendPositionA, sendPositionB, TestOptionChange, ConfigChanged;

        private TestOption testoption;
        public event EventHandler Active;

        private Dictionary<string, (int[] config, TestOption testOption)> connectorConfigs = new Dictionary<string, (int[] config, TestOption testOption)>
        {
            {"M 1,2,3,4", (new int[] {1, 2, 3, 4}, TestOption.FourColor)},
            {"M 1,2,3,4,5", (new int[] {1, 2, 3, 4, 5}, TestOption.FiveColor)},
            {"M 1,3,4", (new int[] {1, 3, 4}, TestOption.ThreeColor)},
            {"M 2,3,4", (new int[] {2, 3, 4}, TestOption.ThreeColor)},
            {"M 3,4,5", (new int[] {3, 4, 5}, TestOption.ThreeColor)},
            {"F 1,2,3,4", (new int[] {1, 2, 3, 4}, TestOption.FourColor)},
            {"F 1,2,3,4,5", (new int[] {1, 2, 3, 4, 5}, TestOption.FiveColor)},
            {"F 1,2,3", (new int[] {1, 2, 3}, TestOption.ThreeColor)},
            {"F 1,3,4", (new int[] {1, 3, 4}, TestOption.ThreeColor)},
            {"F 2,3,4", (new int[] {2, 3, 4}, TestOption.ThreeColor)},
        };

        public ViewOptions(File file, Test test, ModbusSlave slave, CameraIV3 cam)
        {
            InitializeComponent();
            camera = cam;
            this.test = test;
            this.slave = slave;
            this.file = file;
            camera._pictureBox = pictureBox1; 
            fileName.Text = file.Name; 
            cam.CleanUp();
            fileName.TextChanged += SearchBox_TextChanged;
            sendPositionA += SendPosition;
            sendPositionB += SendPosition;
        }
        private void connectorA_Click(object sender, EventArgs e)
        {
            sendPositionA?.Invoke("A", EventArgs.Empty);

            ConfigSelector selector = new ConfigSelector();
            selector.OnConfigClick += new EventHandler(delegate (object se, EventArgs ea)
            {
                if (configA != null)
                {
                    string oldConfig = String.Join(",", configA.Config);
                    string newConfig = String.Join(",", selector.ConnectorConfig.Config);
                    Console.WriteLine(String.Format("Old: {0} {1} {2} | New: {3} {4} {5}",
                        oldConfig, selector.ConnectorConfig.ConnectorType, selector.ConnectorConfig.Side,
                        newConfig, configA.ConnectorType, configA.Side));
                    if (oldConfig == newConfig
                    && selector.ConnectorConfig.ConnectorType == configA.ConnectorType
                    && selector.ConnectorConfig.Side == configA.Side)
                    {
                        Console.WriteLine("Same Config");
                    }
                    else
                    {
                        Console.WriteLine("New Config");
                        ConfigChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
                connectorA.BackgroundImage = GetConfigImage(selector.ConnectorConfig);
                configA = selector.ConnectorConfig;
                configA.Side = Side.A;
                ConfigConnector(selector.ConnectorConfig,"A");
                file.AddConnectorConfig(selector.ConnectorConfig);
                selector.Dispose();
            });
            selector.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(selector);
            selector.BringToFront();
            Active?.Invoke(this, EventArgs.Empty);
        }
      
        public void LoadItems(object sender, EventArgs e)
        {
            int count = 0;
            updateFile = true;

            file.ConnectorConfigs.ForEach(connector =>
            {

                var btn = connector.Side == Side.A ? connectorA : connectorB;
                btn.BackgroundImage = GetConfigImage(connector);
                ConfigConnector(connector, connector.Side == Side.A ? "A" : "B");
                side = connector.Side;
                if (connector.Side == Side.A)
                    poleA = connector.Config;
                else
                    poleB = connector.Config;
            });
            string val = String.Join(",", poleA.Concat(poleB).ToArray());
            string[] poles = val.Split(',');
            foreach (Test test in file.Tests)
            {
                if (file.ConnectorConfigs.Count == 2)
                {
                    if (count < (file.Tests.Count / 2))
                        SetInfoControls(int.Parse(poles[count]), tbconfigA, test.Wire.WireColor, test.Wire.PosWire, test.Wire.PosCam);
                    else
                        SetInfoControls(int.Parse(poles[count]) + 5, tbconfigB, test.Wire.WireColor, test.Wire.PosWire, test.Wire.PosCam);
                }
                else
                {
                    SetInfoControls(side == Side.A ? int.Parse(poles[count]) : int.Parse(poles[count]) + 5,
                        side == Side.A ? tbconfigA : tbconfigB, test.Wire.WireColor, test.Wire.PosWire, test.Wire.PosCam);
                }
                count++;
            }
            wires = file.Tests.GroupBy(x => x.Wire.ProgID);
            Active?.Invoke(this, EventArgs.Empty);
            int index = comboBox1.SelectedIndex = file.Tests.First().Wire.ProgID;
            camera.programSwitch(index);
            Task t = Task.Run(async () => await slave.PositionCamera(file.Tests.First().Wire.PosCam));
            NameProgram(comboBox1.Items[index].ToString());
        }
        public void NameProgram(string prog) => comboBox1.Text = prog;
        private Image GetConfigImage(ConnectorConfig conf)
        {
            string val = String.Format("{0} {1}", conf.ConnectorType == ConnectorType.Male ? "M" : "F", String.Join(",", conf.Config));
            switch (val)
            {
                case "M 1,2,3,4": return Resources.M_1_2_3_4;
                case "M 1,2,3,4,5": return Resources.M_1_2_3_4_5;
                case "M 1,3,4": return Resources.M_1_3_4;
                case "M 2,3,4": return Resources.M_2_3_4;
                case "M 3,4,5": return Resources.M_3_4_5;
                case "F 1,2,3,4": return Resources.F_1_2_3_4;
                case "F 1,2,3,4,5": return Resources.F_1_2_3_4_5;
                case "F 1,2,3": return Resources.F_1_2_3;
                case "F 1,3,4": return Resources.F_1_3_4;
                case "F 2,3,4": return Resources.F_2_3_4;
                default: return null;
            }
        }
        public void SetVisibilityControls(int[] config,string side,Control control)
        {
            // Utiliza un bucle para establecer la visibilidad de los controles
            foreach (var numero in config)
            {
                int number = side == "A" ? numero : (numero + 5);
                // Busca el botón y el label correspondiente al número
                var btn = (Button)control.Controls.Find($"Pole{number}", false).FirstOrDefault();
                var pole = (Label)control.Controls.Find($"Pole{numero}{side}", false).FirstOrDefault();
                var positionAngle = (Label)control.Controls.Find($"PositionAngle{number}", false).FirstOrDefault();
                var positionCamera = (Label)control.Controls.Find($"PositionCamera{number}", false).FirstOrDefault();

                // Establece la visibilidad del botón y el label
                if (btn != null)
                    btn.Visible = true;
                if (pole != null)
                    pole.Visible = true;
                if (positionAngle != null)
                    positionAngle.Visible = true;
                if (positionCamera != null)
                    positionCamera.Visible = true;
            }
        }
        private void SetInfoControls(int number, Control control,Enum color,int angle,int camera)
        {
            var btn = (Button)control.Controls.Find($"Pole{number}", false).FirstOrDefault();
            var positionCamera = (Label)control.Controls.Find($"PositionCamera{number}", false).FirstOrDefault();
            var positionAngle = (Label)control.Controls.Find($"PositionAngle{number}", false).FirstOrDefault();
            
            if (btn != null)
                btn.BackColor = SelectorColores.GetColor(color.ToString());
            if (positionCamera != null)
                positionCamera.Text = camera.ToString();
            if (positionAngle != null)
                positionAngle.Text = angle.ToString();
        }
        private void ConfigConnector(ConnectorConfig conf,string side)                                     
        {
            Control control = side == "A" ? tbconfigA : tbconfigB;
            Label lbl1 = side == "A" ? label5 : label8; Label lbl2 = side == "A" ? label6 : label9; Label lbl3 = side == "A" ? label7 : label10;
            control.Visible = true; lbl1.Visible = true; lbl2.Visible = true; lbl3.Visible = true;
            string val = String.Format("{0} {1}", conf.ConnectorType == ConnectorType.Male ? "M" : "F", String.Join(",", conf.Config));
            if (connectorConfigs.TryGetValue(val, out var config))
            {
                if (!updateFile)
                    ReceivedCameraPositions(config.config, side, side == "A" ? tbconfigA : tbconfigB);
                SetVisibilityControls(config.config, side, side == "A" ? tbconfigA : tbconfigB);
                testoption = config.testOption;
            }
        }
        private void toggleKeyboard(object sender, EventArgs e)
        {
            bool hasTable = false;
            foreach (Control control in this.Controls)
            {
                if (control.Name == "Keyboard")
                    hasTable = true;
            }
            Control focus = fileName;
            if ((sender as Control) == fileName || (sender as Control) == searchPanel)
                focus = fileName;
            if (!hasTable)
            {
                if (focus != null)
                {
                    keyboard = new Keyboard(focus);
                    keyboard.Dock = DockStyle.Bottom;
                    keyboard.Disposed += new EventHandler((object s, EventArgs ea) =>
                    {
                        if (fileName.Text == "")
                            fileName.Text = "Enter file name.";
                    });
                }
                this.Controls.Add(keyboard);
            }
        }
        private void SearchBox_TextChanged(object sender, EventArgs e) => file.Name = fileName.Text;
        private void searchBox_Enter(object sender, EventArgs e)
        {
            if (keyboard != null)
                keyboard.FocusControl(fileName);
            if (fileName.Text == "Enter file name.")
                fileName.SelectAll();
        }
        private void connectorB_Click(object sender, EventArgs e)      
        {
            sendPositionB?.Invoke("B", EventArgs.Empty);
            ConfigSelector selector = new ConfigSelector();
            selector.OnConfigClick += new EventHandler(delegate (object se, EventArgs ea)
            {
                if (configB != null)
                {
                    string oldConfig = String.Join(",", configB.Config);
                    string newConfig = String.Join(",", selector.ConnectorConfig.Config);
                    Console.WriteLine(String.Format("Old: {0} {1} {2} | New: {3} {4} {5}",
                        oldConfig, selector.ConnectorConfig.ConnectorType, selector.ConnectorConfig.Side,
                        newConfig, configB.ConnectorType, configB.Side));
                    if (oldConfig == newConfig
                    && selector.ConnectorConfig.ConnectorType == configB.ConnectorType
                    && selector.ConnectorConfig.Side == configB.Side)
                    {
                        Console.WriteLine("Same Config");
                    }
                    else
                    {
                        Console.WriteLine("New Config");
                        ConfigChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
                connectorB.BackgroundImage = GetConfigImage(selector.ConnectorConfig);
                configB = selector.ConnectorConfig;
                configB.Side = Side.B;
                ConfigConnector(selector.ConnectorConfig,"B");
                file.AddConnectorConfig(selector.ConnectorConfig);
                selector.Dispose();
            });
            selector.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(selector);
            selector.BringToFront();
        }
        private void ChangedColor_Click(object sender, EventArgs e)
        {
            SelectorColores.Show();  
            Button clickedButton = (Button)sender;
            button = clickedButton;
        }
        private void OptionsEvents()
        {
            test.File = file;
            Test testFound = FindTest(testoption, wire);
            if (testFound is null)
                file.AddTest(new Test(file, testoption, new Wire(SelectorColores.wirecolor, Convert.ToInt32(numberprogram), PosCamera, PosAngle)));
            else
                UpdateTest(testFound);
        }
        internal void UpdateTest(Test testFound)
        {
            file.Tests.ForEach(e =>
            {
                if (e.ID == testFound.ID)
                {
                    if (e.Wire.WireColor != SelectorColores.wirecolor)
                        e.Wire.WireColor = SelectorColores.wirecolor;
                    if (e.Wire.PosWire != PosAngle)
                        e.Wire.PosWire = PosAngle;
                }
            });
        }
        private async void SelectorColores_OnClickPic(object sender, EventArgs e)
        {
            button.BackColor = SelectorColores.SelectedColor;
            string buttonName = button.Name;
            string pattern = @"\d+";
            Match match = Regex.Match(buttonName, pattern);
            if (match.Success)
            {
                Control control = int.Parse(match.Value) <= 5 ? tbconfigA : tbconfigB;
                PosCamera = control == tbconfigA ? positionA : positionB;
                await ReceivedAngle(int.Parse(match.Value), control);
                OptionsEvents();
            }
            SelectorColores.Hide();
        }
        private void SendPosition(object sender, EventArgs e)
        {
            Task t = Task.Run(async () =>
            {
                await slave.PositionCamera((string)sender == "A" ? positionA : positionB);
            });
        }
        private void ReceivedCameraPositions(int[] config, string side, Control control)
        {
            PosCamera = side == "A" ? positionA : positionB;
            foreach (var numero in config)
            {
                int number = side == "A" ? numero : (numero + 5);
                var positionCamera = (Label)control.Controls.Find($"PositionCamera{number}", false).FirstOrDefault();

                if (positionCamera != null)
                    positionCamera.Text = side == "A" ? Convert.ToString(positionA) : Convert.ToString(positionB);
            }
        }
        private async Task ReceivedAngle(int number, Control control)
        {
            await slave.ReceivedPositionWire();
            numberprogram = progID();
            var label = (Label)control.Controls.Find($"PositionAngle{number}", false).FirstOrDefault();
            label.Text = Convert.ToString(slave.posangle);
            PosAngle = int.Parse(label.Text);
        }
        private int progID()
        {
            if (int.Parse(comboBox1.SelectedIndex.ToString()) == -1)
                return 0;
            else
                return int.Parse(comboBox1.SelectedIndex.ToString());
        }
        private void ViewOptions_Load(object sender, EventArgs e)
        {
            camera.nameprogram.ForEach(prog => { comboBox1.Items.Add(prog); });
            SelectorColores.OnClickPic += SelectorColores_OnClickPic;
        }
        public Test FindTest(TestOption testOption, Wire wire)
        {
            if (file.Tests is null) file.Tests = new List<Test>();

            if (!updateFile)
            {
                Test foundTest = file.Tests.FirstOrDefault(test => test.TestOption == testOption && test.Wire.PosWire == PosAngle);
                return foundTest;
            }
            else
            {
                Test foundTest = file.Tests
                    .FirstOrDefault(test => test.TestOption == testOption && wires.Any(group => group.Any(wire => wire.Wire.ProgID == progID())));
                return foundTest;
            }
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            slave.TriggerModOFF();
            await Task.Delay(150);
            camera.programSwitch(progID());
            await Task.Delay(150);
            slave.TriggerModON();
        }
    }
}