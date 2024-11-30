using BeldenCableInspection.Controllers;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net;
using System.Windows.Forms;

namespace BeldenCableInspection.Views
{
    public partial class Launcher : UserControl
    {

        public event EventHandler ClickStart;
        public string local { get => ipAddress.Text; set => ipAddress.Text = value; }
        public string camera { get => cam.Text; set => cam.Text = value; }
        public String DBHostNameIP { get => hostname.Text; set => hostname.Text = value; }
        public String DBUser { get => user.Text; set => user.Text = value; }
        public String UserPassword { get => password.Text; set => password.Text = value; }
        public IPAddress IPAddress { get => IPAddress.Parse(ipAddress.Text);}
        public IPAddress IPAddressCam { get => IPAddress.Parse(cam.Text); }
        public String ConnectionString { get => String.Format($"Data Source={hostname.Text};Initial Catalog=BeldenValitacion;User ID={user.Text};Password={password.Text};MultipleActiveResultSets = True"); }
        public Launcher() => InitializeComponent();
        private void start_Click(object sender, EventArgs e) => ClickStart?.Invoke(this, EventArgs.Empty);

        public bool HacerPing(IPAddress ip)
        {
            bool connectionEstablished = false;

            try
            {
                using (var ping = new System.Net.NetworkInformation.Ping())
                {
                    var respuesta = ping.Send(ip, 1000); // Tiempo de espera de 1 segundo

                    if (respuesta.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        connectionEstablished = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al hacer ping a {ip}: {ex.Message}");
            }

            return connectionEstablished;
        }
        /**/
    }
}
