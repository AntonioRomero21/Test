using Keyence.IV3.Sdk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeldenCableInspection.Controllers
{
    public class CameraIV3
    {
        private IVisionSensor camara;
        public PictureBox  _pictureBox;
        public PictureBox[] pictureBoxes, pictureBoxesA, pictureBoxesB;
        private new Timer timer1;
        public Side side; 
        public WireColor color;
        public int currentIndexA = 0, currentIndexB = 0, currentIndex = 0, numberpackage = 0, numberside = 0,numprog;
        public string photoResult = string.Empty, name, RawPortNo;
        public bool result = false, view = false;

        Size image_size = new Size(1280, 960); 
        VisionSensorStore store = new VisionSensorStore();
        private readonly Dictionary<byte, IToolResultControl> toolResults = new Dictionary<byte, IToolResultControl>();
        ToolSettingBase toolSetting;
        public List<String> nameprogram = new List<string>();
        public byte[] IpAddressLocal;
        public IPAddress RawIpAddressCamera;
        
        public event EventHandler Clear;
        public event EventHandler StartTimer;
        public event EventHandler TriggerTimeout;
        public CameraIV3(IPAddress camera, byte[] Local, string port)
        {
            IpAddressLocal = Local;
            RawIpAddressCamera = camera;
            RawPortNo = port;
            IniciarCamara();
        }

        private void Conexion()
        {
            try
            {
                IPAddress iplocal = new IPAddress(IpAddressLocal);
                VisionSensorStore.StartPoint = iplocal;
                camara = store.Create(RawIpAddressCamera, ushort.Parse(RawPortNo));
            }
            catch { }
        }
        public void initTesting() => camara.ImageAcquired += PaintAllPictureBoxImage;
        public void CleanUp() => camara.ImageAcquired -= PaintAllPictureBoxImage;
        public void programSwitch(int Prog) => camara.SwitchProgramTo(camara.Programs[Prog]);

        public void IniciarCamara()
        {
            timer1 = new Timer();
            Conexion();
            timer1.Tick += timer1_Tick;
            camara.EventEnable = true;
            camara.ResultUpdated += EventResultCamara;
            camara.ImageAcquired += EventImagenCamara;
            camara.ProgramSettingsUpdated += CamaraProgramSettingsUpdated;
            // Display Initial Tool Settiings.
            CamaraProgramSettingsUpdated(this, EventArgs.Empty);
            timer1.Start();
        }


        private int ActualizarPictureBox(PictureBox[] pictureBoxes, int currentIndex, System.Drawing.Image image)
        {
            if (pictureBoxes[currentIndex].Image != null)
                pictureBoxes[currentIndex].Image.Dispose();

            pictureBoxes[currentIndex].Enabled = true;
            pictureBoxes[currentIndex].Image = image;
            pictureBoxes[currentIndex].Refresh();
            return currentIndex + 1;
        }
       
        private void EventImagenCamara(object sender, ImageAcquiredEventArgs e)
        {
            // Crea un nuevo Bitmap con las dimensiones y formato necesarios
            var image = new Bitmap(image_size.Width, image_size.Height, PixelFormat.Format24bppRgb);

            // Bloquea el Bitmap para acceder a sus datos de píxeles
            BitmapData lockData = image.LockBits(new Rectangle(Point.Empty, image_size), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            // Copia los datos de imagen del argumento a los datos del Bitmap
            Marshal.Copy(e.LiveImage.ByteData, 0, lockData.Scan0, e.LiveImage.ByteData.Length);

            // Desbloquea el Bitmap
            image.UnlockBits(lockData);

            // Libera la memoria de imágenes anteriores si es necesario
            if (_pictureBox.Image != null) _pictureBox.Image.Dispose();

            using (Graphics marcador = Graphics.FromImage(image))
            {
                // Establece el modo de suavizado para mejorar la calidad de la imagen
                marcador.SmoothingMode = SmoothingMode.AntiAlias;

                // Dibuja elementos en el Bitmap (ejemplo, líneas verdes y rojas)
                foreach (byte sensorIndex in toolResults.Keys)
                {
                    if (toolResults[sensorIndex].ToolName == Convert.ToString(color))
                        camara.DrawWindow(marcador, Color.Green, Color.Red, sensorIndex);
                }
            }
            _pictureBox.Image = image;
        }
        public void PaintAllPictureBoxImage(object sender, ImageAcquiredEventArgs e)
        {
            var image = new Bitmap(image_size.Width, image_size.Height, PixelFormat.Format24bppRgb);
            // Bloquea el Bitmap para acceder a sus datos de píxeles
            BitmapData lockData = image.LockBits(new Rectangle(Point.Empty, image_size), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            // Copia los datos de imagen del argumento a los datos del Bitmap
            Marshal.Copy(e.LiveImage.ByteData, 0, lockData.Scan0, e.LiveImage.ByteData.Length);
            // Desbloquea el Bitmap
            image.UnlockBits(lockData);
            using (Graphics marcador = Graphics.FromImage(image))
            {
                // Establece el modo de suavizado para mejorar la calidad de la imagen
                marcador.SmoothingMode = SmoothingMode.AntiAlias;

                // Dibuja elementos en el Bitmap (ejemplo, líneas verdes y rojas)
                foreach (byte sensorIndex in toolResults.Keys)
                {
                    if (toolResults[sensorIndex].ToolName == Convert.ToString(color))
                        camara.DrawWindow(marcador, Color.Green, Color.Red, sensorIndex);
                }
            }
            if (numberside == 2)
            {
                if (currentIndex >= (numberpackage / 2))
                    currentIndexB = ActualizarPictureBox(pictureBoxesB, currentIndexB, image);
                else
                    currentIndexA = ActualizarPictureBox(pictureBoxesA, currentIndexA, image);
            }
            else
            {
                switch (side)
                {
                    case Side.A:
                        {
                            currentIndexA = ActualizarPictureBox(pictureBoxesA, currentIndexA, image);
                            break;

                        }
                    case Side.B:
                        {
                            currentIndexB = ActualizarPictureBox(pictureBoxesB, currentIndexB, image);
                            break;
                        }
                }
            }
            currentIndex++;
        }

        public event EventHandler<ToolSelectedEventArgs> ActiveToolChanged = delegate { };
        public void ClearPictures()
        {
            foreach (var pictures in pictureBoxes)
            {
                if (pictures != null && pictures.Image != null)
                {
                    pictures.Image.Dispose();
                    pictures.Image = null;
                }
            }
            if (_pictureBox != null && _pictureBox.Image != null) 
            {
                _pictureBox.Image.Dispose();
                _pictureBox.Image = null;
            }
                
        }
        public void PictureBox_Click(object sender,EventArgs e) 
        {
            currentIndex = 0;
            PictureBox pictureBoxSelected = (PictureBox)sender;
            var image = pictureBoxSelected.Image;
            pictureBoxSelected.Refresh();
            _pictureBox.Image = pictureBoxSelected.Image;
        }
       
        private void CamaraProgramSettingsUpdated(object sender, EventArgs e)
        {
            nameprogram.Clear();
            foreach (ProgramHeader program in camara.Programs)
            {
                nameprogram.Add(program.ToString());
            }
            toolResults.Clear();
            for (byte i = 1; i <= 64; i++)
            {
                toolSetting = camara.ActiveProgram[i];
                if (toolSetting.ToolType == "") continue;
                var control = ToolResultControlFactory.Create(i, toolSetting);
                control.Selected += ActiveToolChanged;
                toolResults.Add(i, control);
            }
        }
        private void EventResultCamara(object sender, ToolResultUpdatedEventArgs e)
        {
            if (e.TriggerCount > 0)
            {
                foreach (byte sensorIndex in toolResults.Keys)
                    toolResults[sensorIndex].UpdateResult(e[sensorIndex]);
                result = true;
            }
            else
            {
                Console.WriteLine("Not Switch Program and I don't throw the Trigger");
            }
        }
        public async Task<string> FindColor(Enum element)
        {
            result = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Waiting camera");
            do
            {
                if (stopwatch.ElapsedMilliseconds >= 5000)
                {
                    Console.WriteLine("Camera trigger timeout");
                    TriggerTimeout?.Invoke(this, EventArgs.Empty);
                    return null;
                }
                await Task.Delay(1);
            } while (!result);
            stopwatch.Stop();
            Console.WriteLine("Waiting Camera Trigger time?: " + stopwatch.Elapsed);
            if (stopwatch.ElapsedMilliseconds < 3000)
            {
                foreach (byte sensorIndex in toolResults.Keys)
                {
                    if (toolResults[sensorIndex].ToolName == Convert.ToString(element))
                        return photoResult = $"{toolResults[sensorIndex].Total}";
                }
                return null;
            }
            else
                return null;
        }
        
        public string CheckColor()
        {
            foreach (byte sensorIndex in toolResults.Keys)
            {
                if (toolResults[sensorIndex].ToolName == $"{color}_Prohibit")
                {
                    if (toolResults[sensorIndex].Total == "NG")
                        return photoResult = "OK";
                    else
                        return photoResult = "NG";
                }
            }
            return null;
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            camara.TickTack();
            numprog = camara.ActiveProgram.ProgramNo;
            name = camara.ActiveProgram.ProgramName;
        }
        internal void Connect()
        {
            IniciarCamara();
            _pictureBox.Image = null;
            StartTimer?.Invoke(this, EventArgs.Empty);
        }
       
        internal void Disconnect()
        { 
            store.Dispose();
            _pictureBox.Image = Properties.Resources.CESAT_Logo;
            Clear?.Invoke(this, EventArgs.Empty);
        }
    }
    public class ToolSelectedEventArgs : EventArgs
    {
        private readonly byte toolNo;
        public ToolSelectedEventArgs(byte toolNo) => this.toolNo = toolNo;
       
        public byte ToolNo
        {
            get { return toolNo; }
        }
    }
    public sealed partial class ColorAverageToolResultControl : UserControl, IToolResultControl
    {
        private readonly byte toolNo;
        private readonly ToolSettingBase toolSetting;
        private ColorAverageToolResult toolResult;
        public string result;
        public string name;
        public string TotalResult;
        public string Total
        {
            get { return TotalResult; }
            set { TotalResult = value; }
        }
        public string ToolName
        {
            get { return name; }
            set { name = value; }
        }
        public ColorAverageToolResultControl(byte toolNo, ToolSettingBase setting)
        {
            this.toolNo = toolNo;
            toolSetting = setting;

        }
        public event EventHandler<ToolSelectedEventArgs> Selected = delegate { };
        public void UpdateResult(ToolResultBase Result)
        {
            toolResult = Result as ColorAverageToolResult;
            if (toolResult == null) return;
            result = Result.Value.ToString(CultureInfo.InvariantCulture);
        }
        private void ToolResultControlClick(object sender, EventArgs e)
        {
            Selected(sender, new ToolSelectedEventArgs(toolNo));
        }
    }
    internal static class ToolResultControlFactory
    {
        public static IToolResultControl Create(byte toolNo, ToolSettingBase setting)
        {
            if (setting.ToolType.Equals("ColorAverage"))
            {
                return new ColorAverageToolResultControl(toolNo, setting);
            }
            return new ToolResultControl(toolNo, setting);
        }
    }
    public partial class ToolResultControl : UserControl, IToolResultControl
    {
        private readonly byte toolNo;
        private readonly ToolSettingBase toolSetting;
        private ToolResultBase toolResult;
        private string result;
        private string name;
        public string TotalResult;
        public string Total
        {
            get { return TotalResult; }
            set { TotalResult = value; }
        }
        public string ToolName
        {
            get { return name; }
            set { name = value; }
        }
        public ToolResultControl(byte toolNo, ToolSettingBase setting)
        {
            this.toolNo = toolNo;
            toolSetting = setting;
            name = setting.ToolName;
        }
        public event EventHandler<ToolSelectedEventArgs> Selected = delegate { };
        public void UpdateResult(ToolResultBase Result)
        {
            toolResult = Result;
            result = Result.Value.ToString(CultureInfo.InvariantCulture);
            if (toolResult.Value >= toolSetting.OkMinValue)
                TotalResult = "OK";
            else
                TotalResult = "NG";
        }
        private void ToolResultDisplayControlClick(object sender, EventArgs e)
        {
            Selected(sender, new ToolSelectedEventArgs(toolNo));
        }
    }
    internal interface IToolResultControl
    {
        event EventHandler<ToolSelectedEventArgs> Selected;
        void UpdateResult(ToolResultBase result);
        string Total { get; set; }
        string ToolName { get; set; }
    }
}
