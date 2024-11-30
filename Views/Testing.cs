using BeldenCableInspection.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeldenCableInspection.Views
{
    public partial class Testing : UserControl
    {
        private int panelBorderPixels = 5;
        public System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private File file;
        private CameraIV3 cam;
        private ModbusSlave slave;
        public Stopwatch stopwatch = new Stopwatch();
        List<List<int>> positions = new List<List<int>>();
        List<int>progID = new List<int>();
        public bool disconnect = false;
        string employeeNo = null, employeeName = null;
        public event EventHandler SaveResult;
        public event EventHandler FinishedTest;
        public event EventHandler StartedAutomaticTest;
        public event EventHandler WireCodeNotSet;
        public event EventHandler DataSend;
        PictureBox[] pictureBoxesA, pictureBoxesB, pictureBoxes;
        private Boolean employeeIsAdmin = false, employeeIsAdminCesat = false;

        public Testing(File file, ModbusSlave slave, string employeeNo, string employeeName, CameraIV3 cam, Boolean employeeIsAdmin, Boolean employeeIsAdminC )
        {
            InitializeComponent();
            
            this.cam = cam;
            cam.CleanUp();
            pictureBoxesA = new PictureBox[] { TestPole1, TestPole2, TestPole3, TestPole4, TestPole5 };
            pictureBoxes = new PictureBox[] { TestPole1, TestPole2, TestPole3, TestPole4, TestPole5, TestPole6, TestPole7, TestPole8, TestPole9, TestPole10 };
            pictureBoxesB = new PictureBox[] { TestPole6, TestPole7, TestPole8, TestPole9, TestPole10 };
            this.employeeIsAdmin = employeeIsAdmin;
            this.employeeIsAdminCesat = employeeIsAdminC;
            if (employeeIsAdminC ||employeeIsAdmin)
                wirePanel.Visible = true;
            cable.Click += toggleKeyboard;
            cam._pictureBox = pictureBox1;
            cam.pictureBoxesA = pictureBoxesA;
            cam.pictureBoxes = pictureBoxes;
            cam.pictureBoxesB = pictureBoxesB;
            cam.initTesting();
            this.employeeNo = employeeNo;
            this.employeeName = employeeName;
            employee.Text = employeeNo + " " + employeeName;
            testName.Text = file.Name;
            panelTestType.Size = new Size(64, 64);
            this.file = file;
            this.slave = slave;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(delegate (object sender, EventArgs evt)
            {
                long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                double elapsedSeconds = (double)elapsedMilliseconds / 1000; // Convert milliseconds to seconds (use double for precision)
                string elapsedTime = elapsedSeconds.ToString("0"); // Format as seconds only, no leading zeros
                labelTime.Text = elapsedTime + " (s)";
            });

            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Click += cam.PictureBox_Click;
            }
            UploadData(file, slave);
            
        }


        private void panelRight_Paint(object sender, PaintEventArgs e) => paint_PanelBorders(sender as Panel, e, Color.Yellow, true, true, true, true);
        private void paint_PanelBorders(Panel panel, PaintEventArgs e, Color color, bool left, bool top, bool right, bool bottom)
        {
            ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                left ? color : Color.Transparent, left ? panelBorderPixels : 0, left ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
                top ? color : Color.Transparent, top ? panelBorderPixels : 0, top ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
                right ? color : Color.Transparent, right ? panelBorderPixels : 0, right ? ButtonBorderStyle.Solid : ButtonBorderStyle.None,
                bottom ? color : Color.Transparent, bottom ? panelBorderPixels : 0, bottom ? ButtonBorderStyle.Solid : ButtonBorderStyle.None
            );
        } 
        
        private async void UploadData(File file, ModbusSlave slave)
        {
            //cable.Text = $"{cableRnd.Next(0000, 9999).ToString()}";
            slave.NextOFF();
            if (slave.ready)
            {
                file.Tests.ForEach(test =>
                {
                    positions.Add(new List<int>() { test.Wire.PosCam, test.Wire.PosWire });
                });

                if (file.ConnectorConfigs.Count() == 2)
                    cam.numberside = 2;
                else
                {
                    file.ConnectorConfigs.ForEach(connector => 
                    {
                        if (connector.Side == Side.A)
                            cam.side = Side.A;
                        else
                            cam.side = Side.B;
                        
                    });
                }
                cam.numberpackage = file.Tests.Count;
                await slave.AllMov(positions, ushort.Parse(file.Tests.Count.ToString()));
                cam.programSwitch(file.Tests.First().Wire.ProgID);
                DataSend?.Invoke(this, EventArgs.Empty);
            }
        }
        private bool StopIO(ModbusSlave slave)
        {
            bool stop = slave.EmergencyStopActive;
            return stop;
        }

        Random cableRnd = new Random();
        Results results;
        private async void Test(File file, ModbusSlave slave)
        {
            ushort movingcount = 0;
            cam.ClearPictures();
            cam.currentIndex = 0; cam.currentIndexB = 0; cam.currentIndexA = 0;
            if (slave.ready)
            {
                slave.Started();
                results = new Results(employeeNo, employeeName, file.Name, cable.Text);
                this.BackColor = log.BackColor = Color.FromArgb(229, 107, 0);
                log.Text = String.Empty;
                bool stop = false;

                stopwatch.Start();
                if (!timer.Enabled) timer.Start();
                string result = String.Empty;

                foreach (Test test in file.Tests)
                {
                    cam.color = test.Wire.WireColor;

                    Console.WriteLine("Wire Test: " + test.Wire.WireColor + " : " + movingcount);
                    if (movingcount == (file.Tests.Count / 2))
                    {
                        Stopwatch waiting = new Stopwatch();
                        cam.programSwitch(test.Wire.ProgID);
                        waiting.Start();
                        while (true)
                        {
                            if (waiting.ElapsedMilliseconds >= 200)
                            {
                                Task x = Task.Run(() => slave.NextON());
                                waiting.Stop();
                                break;
                            }
                        }
                    }
                    if (movingcount != (file.Tests.Count / 2))
                    {
                        await Task.Delay(150);
                        slave.NextON();
                    }
                    /*//IA Program
                    cam.programSwitch(test.Wire.ProgID);
                    waiting.Start();
                    while (true)
                    {
                        if (waiting.ElapsedMilliseconds >= 200)
                        {
                            Task x = Task.Run(() => slave.NextON());
                            waiting.Stop();
                            break;
                        }
                    }
                     */
                  
                    result = await cam.FindColor(test.Wire.WireColor);
                    slave.NextOFF();
                    await Task.Delay(150);

                    if (result is null)
                    {
                        Console.WriteLine("Result is null for " + test.Wire.WireColor);
                        StartedAutomaticTest?.Invoke(this, EventArgs.Empty);
                        stop = true;
                        break;  
                    }

                    if (StopIO(slave)) stop = true;
                    if (!result.Contains("OK"))
                    {
                        result = cam.CheckColor();
                        if (!result.Contains("OK"))
                            stop = true;
                    }

                    ResultWireColor resultwire = new ResultWireColor(test.Wire.ID, test.Wire.WireColor.ToString(), result);
                    results.ResultWire.Add(resultwire);
                    log.Text += test.Wire.WireColor.ToString() + " " + result + Environment.NewLine;
                    log.Text += Environment.NewLine;
                    
                    if (stop) break;
                    movingcount++;

                }
                if (timer.Enabled)
                {
                    timer.Stop();
                    stopwatch.Stop();
                }
                if (stop)
                    this.BackColor = log.BackColor = Color.Red;
                else
                    this.BackColor = log.BackColor = Color.Green;
                
                slave.Finished();
            }
            else
            {
                log.Text = "1.- Check cable is correctly inserted in the nest configured before testing.\n\n" +
                    "2.- Make sure the machine detects both cable connectors.";
                slave.NextOFF();
            }
            Thread y = new Thread(() => cam.programSwitch(file.Tests.First().Wire.ProgID));
            y.Start();
            Debug.WriteLine("All Test time?: " + stopwatch.Elapsed);
            Debug.WriteLine("All Test time(ms): " + stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();
            FinishedTest?.Invoke(this, EventArgs.Empty);
            SaveResult?.Invoke(this, new SaveResultsEventArgs(results));
            y.Abort();
            //cable.Text = cableRnd.Next(0000, 9999).ToString();
        }


        Controls.Keyboard keyboard;
        private void toggleKeyboard(object sender, EventArgs e)
        {
            bool keyboardOpen = false;
            foreach (Control control in this.Controls)
            {
                if (control.Name == "Keyboard")
                    keyboardOpen = true;
            }
            Control focus = (Control)sender;
            if (!keyboardOpen)
            {
                if (focus != null)
                {
                    keyboard = new Controls.Keyboard(focus);
                    keyboard.Dock = DockStyle.Bottom;
                }
                this.Controls.Add(keyboard);
                keyboard.BringToFront();
            }
          (focus as TextBox).SelectAll();
        }
        internal void HideWirePanel() => wirePanel.Visible = false;
        internal void ShowWirePanel() => wirePanel.Visible = true;

        public void StartTest()
        {
            if((wirePanel.Visible == true && cable.Text != "") || (wirePanel.Visible == false))
                Test(file, slave);
            else if(wirePanel.Visible == true && cable.Text == "")
                WireCodeNotSet?.Invoke(this, EventArgs.Empty);
        }

      
        public class SaveResultsEventArgs : EventArgs
        {
            private Results result;
            public SaveResultsEventArgs(Results result) => this.result = result;

            public Results Result { get => result; set => result = value; }
        }
        public class Results
        {
            int id;
            string userNumber;
            string userName;
            string fileName;
            string wireLabel;
            public Results(string userNumber, string userName, string fileName, string wireLabel)
            {
                this.userNumber = userNumber;
                this.userName = userName;
                this.FileName = fileName;
                this.wireLabel = wireLabel;
            }
            List<ResultWireColor> resultColor = new List<ResultWireColor>();
            public int Id { get => id; set => id = value; }
            public string UserNumber { get => userNumber; set => userNumber = value; }
            public string UserName { get => userName; set => userName = value; }
            public string FileName { get => fileName; set => fileName = value; }
            public string WireLabel { get => wireLabel; set => wireLabel = value; } 
            public List<ResultWireColor> ResultWire { get => resultColor; set => resultColor = value; }
        }

        public class ResultWireColor
        {
            int id;
            int resultId;
            int wire;
            string wireColor;
            string status; 

            public ResultWireColor(int wire, string wireColor, string status)
            {
                this.wire = wire;
                this.wireColor = wireColor;
                this.status = status;
            }
            public int ID { get => id; set => id = value; }
            public int ResultID { get => resultId; set => resultId = value; }
            public int Wire { get => wire; set => wire = value; }
            public string WireColor { get => wireColor; set => wireColor = value; }
            public string Status { get => status; set => status = value; }

        }    
    }
}
