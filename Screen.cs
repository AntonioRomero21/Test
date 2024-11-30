using BeldenCableInspection.Controllers;
using BeldenCableInspection.Views;
using FontAwesome.Sharp;
using NLog.Time;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BeldenCableInspection.Views.Testing;

namespace BeldenCableInspection
{
    public partial class Screen : Form
    {
        Debugging debugging = new Debugging();
        private Stopwatch stopwatch = new Stopwatch();
        Stopwatch autoTest = new Stopwatch();
        bool hide = false;
        CancellationToken cn;
        FileView files = new FileView();
        private int rowIndex = -1;
        public int RowIndex { get => rowIndex; set => rowIndex = value; }
        Test activeTest = null;
        Test testing;
        File file = new File();
        public static bool testingBandera, newwfile,newBandera,editBandera;
        bool fileSearchInProgress = false;
        bool employeeSearchInProgress = false;
        string employeNo;
        string employeName;
        bool employeeIsAdmin = false, employeeadminCesat = false;
        private ModbusSlave slave;
        private CameraIV3 camera;
        private BeldenDatabase database;
        public Screen()
        {
            InitializeComponent();
            CancellationTokenSource cnSource = new CancellationTokenSource();
            cn = cnSource.Token;
            Task dataDebugging = new Task(async () => await ShowData(debugging, cn));
            dataDebugging.Start();
            debugging.Show();
            this.FormClosing += (object sender, FormClosingEventArgs eventArgs) => eventArgs.Cancel = true;
            debugging.Closing += (object sender, FormClosingEventArgs eventArgs) => ClosingHandler(cnSource);
            titleBar.Close += (object sender, EventArgs eventArgs) => ClosingHandler(cnSource);
            launcher.ClickStart += (object sender, EventArgs eventArgs) => ValitacionIp();
            debugging.Hide();


        }
        public async void LaunchView()
        {
            slave = new ModbusSlave(launcher.IPAddress, 502);
            camera = new CameraIV3(launcher.IPAddressCam, launcher.IPAddress.GetAddressBytes(), "63000");
            database = new BeldenDatabase(launcher.ConnectionString);
            files.SearchBoxTextChanged += new EventHandler(async delegate (object sender, EventArgs eventArgs)
            {
                string searchText = (sender as TextBox).Text;
                if (!fileSearchInProgress)
                {
                    fileSearchInProgress = true;
                    files.SetDataSource(await database.Reader(String.Format("use BeldenValitacion select ID as No, Name, Date from Files where Name like '%{0}%'", searchText.Equals("Enter file name.") ? "" : searchText)));
                    fileSearchInProgress = false;
                }
            });
            files.EmployeeChanged += new EventHandler(async delegate (object sender, EventArgs eventArgs)
            {
                string employee = (sender as TextBox).Text;
                if (!employeeSearchInProgress && employee != "")
                {
                    employeeSearchInProgress = true;
                    DataTable employeeDT = await database.Reader(String.Format("SELECT * FROM [User] WHERE [NUMBER] = '{0}'", employee));
                    if (employeeDT.Rows.Count == 0)
                    {
                        bar.Enabled = false;
                        files.EmployeName = String.Empty;
                    }
                    else
                    {
                        bar.Enabled = true;
                        employeNo = employeeDT.Rows[0].Field<string>("Number");
                        employeeIsAdmin = employeNo.Equals("00");
                        employeeadminCesat = employeNo.Equals("##");

                        if (employeeIsAdmin || employeeadminCesat) Admin();

                        files.EmployeName = employeName = employeeDT.Rows[0].Field<string>("Name");
                        Console.WriteLine(String.Format("Number: {0}, Name: {1}", employeNo, employeName));
                    }
                    employeeSearchInProgress = false;
                }
            });

            slave.ConfigureTimeout += Slave_ConfigureTimeout;
            slave.ReceivedBit += Slave_ConfigureTimeout;

            slave.EmergencyStopActivated += new EventHandler(delegate (object sender, EventArgs eventArgs)
            {
                Invoke((MethodInvoker)delegate
                {
                    ShowEmergency(EmergencySource.EmergencyStop);
                    slave.OffBit();
                    StopButton();
                });
            });
            slave.EmergencyStopRestored += new EventHandler(delegate (object sender, EventArgs eventArgs)
            {
                Console.WriteLine("EmergencyStop ended!");
                Invoke((MethodInvoker)async delegate
                {
                    if (GetActiveView() != null)
                    {
                        DisposeView();
                    }
                    if (testingBandera == true)
                    {
                        file = await database.GetFile(files.SelectionIndex());
                        Testing testing = new Testing(file, slave, employeNo, employeName,camera, employeeIsAdmin, employeeadminCesat);
                        testing.WireCodeNotSet += Testing_WireCodeNotSet;
                        testing.SaveResult += Testing_SaveResult;
                        bar.Enabled = true;
                        test.Visible = true;
                        home.Visible = true;
                        loadF.Visible = false;
                        SetActiveView(testing);
                    }
                    else if(newBandera)
                    {
                        await RestoreViewOptions("newFlag");
                    }
                    else if(editBandera)
                    {
                       await RestoreViewOptions("editFlag",files.SelectionIndex());
                    }
                    else
                    {
                        await Enable_Features();
                    }
                });
                slave.OnHome(this, EventArgs.Empty);

            });

            LoadR.Visible = false;
            SetActiveView(new Loading());
            slave.DataStore.HoldingRegisters[1019] = 0;
            slave.OnHomeEnd(this, EventArgs.Empty);

            await Enable_Features();
        }
        private void StopButton()
        {
            foreach (IconButton btn in ButtonsPanel.Controls.OfType<IconButton>())
            {
                if (btn.Visible && btn.Enabled)
                {
                    btn.Enabled = false;
                    btn.IconColor = Color.White;
                }
            }
        }

        private async void Slave_ConfigureTimeout(object sender, EventArgs e) {

            ShowMessage("Modbus", "Data Packet Loss, Reload Data");
            SetActiveView(files);
            await SetDataSource();
            loadF.Visible = true;
            home.Visible = false;
            test.Visible = false;

        }
        private async Task RestoreViewOptions(string flag, int? fileID = null)
        {
            slave.TriggerModON();
            bar.Enabled = true;
            copy.Visible = false;
            save.Visible = true;
            neww.Visible = false;
            loadF.Visible = false;
            edit.Visible = false;
            next.Visible = true;
            back.Visible = true;
            next.Enabled = true;
            back.Enabled = true;
            next.Text = "Right";
            back.Text = "Left";
            newwfile = true;
            testing = new Test();
            home.Visible = true;
            if (employeeadminCesat)
                btnConnection.Visible = true;
            if (flag == "newFlag")
            {
                newBandera = true;
                RowIndex = -1;
                file = new File();
                ViewOptions vo = new ViewOptions(file, testing, slave, camera);
                SetActiveView(vo);
                (GetActiveView() as ViewOptions).NameProgram($"{camera.numprog}: {camera.name}");
            }
            if (flag == "editFlag")
            {
                editBandera = true;
                file = await database.GetFile((int)fileID);
                ViewOptions vo = new ViewOptions(file, testing, slave, camera);
                SetActiveView(vo);
                (GetActiveView() as ViewOptions).Active += Screen_Active;
                (GetActiveView() as ViewOptions).LoadItems(this, EventArgs.Empty);
            }
        }
        private void ValitacionIp()
        {
            IPAddress[] direccionesIP = { launcher.IPAddressCam, launcher.IPAddress };
            int failedConnections = 0;

            foreach (var ip in direccionesIP)
            {
                if (!launcher.HacerPing(ip))
                    failedConnections++;
            }

            if (failedConnections > 0) ShowMessage("Connection", "Check PLC, Camera are on");
            if (failedConnections == 0) LaunchView();
        }

        private async Task Enable_Features()
        {
            slave.DataStore.HoldingRegisters[1019] = 0;
            stopwatch.Start();
            do
            {
                await Task.Delay(1);
            } while (slave.firstConnection && (!slave.homebit && !slave.ready));
            stopwatch.Stop();
            bar.Visible = true;
            SetActiveView(files);
            await SetDataSource();
        }
        private async Task SetDataSource() => files.SetDataSource(await database.Reader("USE BeldenValitacion select ID as No, Name, Date from Files"));
        private void Admin()
        {
            loadF.Visible = true;
            LoadR.Visible = false;
            edit.Visible = true;
            copy.Visible = true;
            neww.Visible = true;
            delete.Visible = true;

            if (wireCode.Visible == true)
                wireCode.Visible = false;

            if (btnConnection.Visible == true)
                btnConnection.Visible = false;
            
            if (next.Visible && back.Visible)
            {
                next.Visible = false;
                back.Visible = false;
            }
        }
        public void ShowEmergency(EmergencySource source)
        {
            this?.Invoke((MethodInvoker)delegate
            {
                if (!(GetActiveView() is Emergency))
                {
                    if (GetActiveView() is FileView)
                    {
                        RemoveActiveView();
                    }
                    else
                    {
                        if (!(GetActiveView() is Emergency))
                            DisposeView();
                    }
                    SetActiveView(new Emergency(source));
                }
            });
        }
      
        private bool ActiveViewIs(Type type)
        {
            foreach (Control control in content.Controls)
            {
                return control.Dock == DockStyle.Fill && control.GetType() == type;
            }
            return false;
        }
        private void SetActiveView(Control control)
        {
            content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            content.Controls.Add(control);

        }
        private async Task ShowData(Debugging debugging, CancellationToken cn)
        {
            try
            {
                while (true)
                {
                    if (cn.IsCancellationRequested) return;
                    string data = GetData();
                    debugging.Invoke((MethodInvoker)delegate ()
                    {
                        debugging.LogData.Text = data;
                    });
                    await Task.Delay(750);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.AutoRestart = true;
                ErrorHandler.HandlerError(ex);
            }
        }
       
        private string GetData() => String.Format("{0}\n", file.ToString());
        private void ClosingHandler(CancellationTokenSource cnSource)
        {
            if (slave != null)
                slave.TriggerModOFF();
            
            ConfirmExit ce = new ConfirmExit();
            ce.Exit += (object s, EventArgs a) => CloseApp(cnSource);
            ce.Cancel += (object s, EventArgs a) =>
            {
                ce.Dispose();
                this.Enabled = true;
                this.BringToFront();
            };
            ce.Show();
            ce.BringToFront();
            this.Enabled = false;
        }
        private void CloseApp(CancellationTokenSource cnSource)
        {
            cnSource.Cancel();
            Environment.Exit(0);
        }
        private Control GetActiveView()
        {
            foreach (Control control in content.Controls)
                if (control.Dock == DockStyle.Fill)
                    return control;
            return null;
        }
        private void RemoveActiveView() => content.Controls.Clear();
        public void DisposeView()
        {
            if (GetActiveView() != null) GetActiveView().Dispose();
        }

        private async void loadF_Click(object sender, EventArgs e)
        {
            copy.Visible = false;
            delete.Visible = false;
            save.Visible = false;   
            neww.Visible = false;
            edit.Visible = false;
            if (ActiveViewIs(typeof(FileView)))
            {
                if (files.SelectionIndex() >= 0)
                {
                    file = await database.GetFile(files.SelectionIndex());
                    Testing testing = new Testing(file, slave, employeNo, employeName,camera, employeeIsAdmin, employeeadminCesat);
                    testing.SaveResult += Testing_SaveResult;
                    SetActiveView(testing);
                    testing.WireCodeNotSet += Testing_WireCodeNotSet;
                    testingBandera = true;
                    test.Visible = true;
                    home.Visible = true;
                }
            }
           
            RowIndex = 0;
            loadF.Visible = false;
            (GetActiveView() as Testing).DataSend += DataSend;

            if (employeeIsAdmin) wireCode.Visible = true;

            if (employeeadminCesat)
            {
                wireCode.IconChar = FontAwesome.Sharp.IconChar.Eye;
                btnConnection.Visible = true;
                wireCode.Visible = true;
            }
        }

        private void DataSend(object sender, EventArgs e) => test.Enabled = true;

        private void test_Click(object sender, EventArgs e)
        {
            home.Enabled = false;
            test.Enabled = false;
            if (employeeIsAdmin) wireCode.Enabled = false;
            if (employeeadminCesat)
            {
                btnConnection.Enabled = false;
                wireCode.Enabled = false;
            }
            if (ActiveViewIs(typeof(Testing)))
            {
                (GetActiveView() as Testing).StartTest();
                (GetActiveView() as Testing).FinishedTest += FinishedTest;
                (GetActiveView() as Testing).StartedAutomaticTest += StaterdAutomaticTest;
                slave.LostTestConnection += Slave_LostTestConnection;
            }
        }

        private void Slave_LostTestConnection(object sender, EventArgs e)
        {
            Console.WriteLine("LOST CONNECTION ================================ Modbus Lost Connection");

            (GetActiveView() as Testing).timer.Stop();
            (GetActiveView() as Testing).stopwatch.Stop();
            FinishedTest(this, EventArgs.Empty);
        }


        private async void FinishedTest(object sender, EventArgs e)
        {
            home.Enabled = true;
            test.Enabled = true;
            if (employeeIsAdmin) wireCode.Enabled = true;
            if (employeeadminCesat)
            {
                btnConnection.Enabled = true;
                wireCode.Enabled = true;
            }
            (GetActiveView() as Testing).FinishedTest -= FinishedTest;
            (GetActiveView() as Testing).StartedAutomaticTest -= StaterdAutomaticTest;
            await slave.HomeWire();
        }

        private async void StaterdAutomaticTest(object sender,EventArgs e)
        {
            await Task.Delay(1000);
            test_Click(this, EventArgs.Empty);
        }
        private void logo_Paint(object sender, PaintEventArgs e)    
        {
            if (hide)
            {
                debugging.Show();
                hide = false;
            }
            else
            {
                debugging.Hide();
                hide = true;
            }
        }
        private async void save_Click(object sender, EventArgs e)
        {
            if (newBandera)
                await database.InsertFile(file);
            else
                await database.UpdateFile(file);

            (GetActiveView() as ViewOptions).Dispose();
            SetActiveView(files);
            await SetDataSource();
            neww.Visible = true;
            edit.Visible = true;
            save.Visible = false;
            slave.TriggerModOFF();

            if (employeeIsAdmin || employeeadminCesat) Admin();

        }
        private void Testing_SaveResult(object sender, EventArgs e) => database.SaveResult(sender, e as SaveResultsEventArgs);
        private void home_Click(object sender, EventArgs e)
        {
            test.Visible = false;
            test.Enabled = false;
            loadF.Visible = true;
            home.Visible = false;
            save.Visible = false;
            if (employeeIsAdmin || employeeadminCesat) Admin();
            if (ActiveViewIs(typeof(ViewOptions)))
            {
                slave.TriggerModOFF();
                (GetActiveView() as ViewOptions).Dispose();
            }
            SetActiveView(files);
        }
        private void ShowMessage(String title, String message)
        {
            Message msg = new Message(title, message);

            msg.Show();
            msg.BringToFront();
            this.Enabled = false;
            msg.Continue += (object sender, EventArgs eventArgs) => {
                this.BringToFront();
                this.Enabled = true;
                msg.Dispose();
            };

        }
      
        private async void neww_Click(object sender, EventArgs e) => await RestoreViewOptions("newFlag");
        private void Screen_Active(object sender, EventArgs e)
        {
            next.Enabled = true;
            back.Enabled = true;
        }

        private async void edit_Click(object sender, EventArgs e)
        {
            copy.Visible = false;
            Control control = GetActiveView();
            if (control.GetType().Equals(typeof(FileView)))
            {
                FileView filesView = (FileView)control;
                int fileID = filesView.SelectionIndex();
                if (fileID == -1)
                    ShowMessage("Edit", "File not found");
                else
                    await RestoreViewOptions("editFlag", fileID);
                
                edit.Visible = false;
            }
        }
        private void Testing_WireCodeNotSet(object sender, EventArgs e)
        {
            home.Enabled = true;
            test.Enabled = true;
            wireCode.Enabled = true;
            ShowMessage("Testing", "Please scan the wire code.");
        }
        
        private void btnConnection_Click(object sender, EventArgs e)
        {
            Control control = GetActiveView();
            if (btnConnection.IconChar == FontAwesome.Sharp.IconChar.SignOutAlt)
            {
                camera.Disconnect();
                btnConnection.IconChar = FontAwesome.Sharp.IconChar.SignIn;
                btnConnection.Text = "Connect";
            }
            else
            {
                camera.Connect();
                btnConnection.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
                btnConnection.Text = "Disconnect";
            }

            if (control.GetType().Equals(typeof(Testing)))
            {
                var activeView = GetActiveView() as Testing;
                if (activeView.disconnect == true)
                    activeView.disconnect = false;
                else
                    activeView.disconnect = true;
            }
            else
            {
                if (slave.DataStore.InputDiscretes[13] == false)
                    slave.TriggerModON();
                else
                    slave.TriggerModOFF();
            }
        }

        private void next_Click(object x, EventArgs y)
        {
            bool value = next.IconColor == Color.White;
            slave.MoveRight(value);
            next.IconColor = value ? Color.Green : Color.White;
        }

        private async void LoadResult_Click(object sender, EventArgs e)
        {
            copy.Visible = false;
            loadF.Visible = false;
            delete.Visible = false;
            save.Visible = false;
            neww.Visible = false;
            edit.Visible = false;
            if (ActiveViewIs(typeof(FileView)))
            {
                if (LoadR.Text == "View Result")
                    await ViewResult();
                if (LoadR.Text == "Load Result")
                    await LoadResult();
            }
        }
        int indexResult = 0;
        internal async Task LoadResult()
        {
            if (files.SelectionIndex() == -1)
            {
                ShowMessage("Load", "Result not found");
            }
            if (files.SelectionIndex() >= 0)
            {
                indexResult = files.SelectionIndex();
                files.SetDataSource(await database.Reader(String.Format(@"USE [BeldenValitacion] SELECT r.ID as No, r.[FileName] as Name, [UserNumber] as ID_Employee,r.[UserName] as Name_Employee,r.[WireLabel] as ID_Wire
                    FROM [dbo].[Files] f LEFT JOIN [dbo].[Results] r ON r.[FileName] = f.[Name] WHERE f.[ID] = {0}", indexResult)));
            }
            LoadR.Text = "View Result";
        }
        internal async Task ViewResult()
        {
            if (files.SelectionIndex() == -1)
            {
                ShowMessage("View", "Result not found");
            }
            if (files.SelectionIndex() >= 0)
            {
                files.SetDataSource(await database.Reader(String.Format(@"USE [BeldenValitacion] SELECT rw.ID as No, rw.[WireLabelID] as ID_Wire,rw.[WireColor] as Color, rw.[Status]
                        FROM [dbo].[Results] r LEFT JOIN [dbo].[ResultWireColor] rw ON r.[WireLabel] = rw.[WireLabelID] WHERE r.[ID] = {0}", files.SelectionIndex())));
            }
            LoadR.Text = "Load Result";
        }
        private void back_Click(object x, EventArgs y)
        {
            bool value = back.IconColor == Color.White;
            slave.MoveLeft(value);
            back.IconColor = value ? Color.Green : Color.White;
        }
        private async void copy_Click(object sender, EventArgs e)
        {
            Control control = GetActiveView();
            if (control.GetType().Equals(typeof(FileView)))
            {
                FileView filesView = (FileView)control;
                int fileID = filesView.SelectionIndex();
                if (fileID == -1)
                {
                    ShowMessage("Copy", "File not found");
                }
                else
                {
                    File file = await database.CopyFile(fileID);
                    files.SetDataSource(await database.Reader("USE BeldenValitacion select ID as No, Name, Date from Files"));
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Control control = GetActiveView();
            if (control.GetType().Equals(typeof(FileView)))
            {
                FileView filesView = control as FileView;
                int fileID = filesView.SelectionIndex();
                if (fileID == -1)
                {
                    ShowMessage("Delete", "File not found");
                }
                else
                {
                    MessageConfirm conf = new MessageConfirm()
                    {
                        Message = @"Confirm delete ID: " + fileID,
                        ConfirmIcon = FontAwesome.Sharp.IconChar.Check,
                        ConfirmIconColor = Color.Green,
                        CancelIcon = FontAwesome.Sharp.IconChar.Cancel,
                        CancelIconColor = Color.Red
                    };
                    conf.OnConfirm += async (object s, EventArgs e) =>
                    {
                        bool deleted = await database.DeleteFile(fileID);
                        if (filesView.SearchText.Equals(String.Empty) || filesView.SearchText.Equals("Enter file name."))
                            files.SetDataSource(await database.Reader("USE BeldenValitacion select ID as No, Name, Date from Files"));
                        else
                            files.SetDataSource(await database.Reader(String.Format("USE BeldenValitacion select ID as No, Name, Date from Files where Name like '%{0}%'", files.SearchText)));
                        Dispose();
                    };
                    conf.OnCancel += (object s, EventArgs e) =>
                    {
                        Dispose();
                    };
                    void Dispose()
                    {
                        conf.Dispose();
                        this.Enabled = true;
                        this.Show();
                        this.BringToFront();
                    }
                    this.Enabled = false;
                    conf.Show();
                    conf.BringToFront();
                }
            }
        }

        private void wireCode_Click(object sender, EventArgs e)
        {
            Control control = GetActiveView();
            if (wireCode.IconChar == (FontAwesome.Sharp.IconChar.Eye))
            {
                (control as Testing).HideWirePanel();
                wireCode.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                (control as Testing).ShowWirePanel();
                wireCode.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }
    }
}
