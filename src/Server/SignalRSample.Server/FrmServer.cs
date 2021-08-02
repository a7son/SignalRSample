using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRSample.Server
{
    public partial class FrmServer : Form
    {
        //private IHostBuilder signalR { get; set; }
        private const string SERVER_URL = "http://localhost:5151";

        public FrmServer()
        {
            InitializeComponent();
        }

        public static IHostBuilder signalR() =>
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseUrls(SERVER_URL);
            webBuilder.UseStartup<Startup>();
        });

        private void btnStart_Click(object sender, EventArgs e)
        {
            WriteToConsole("Starting server...");

            btnStart.Enabled = false;
            Task.Run(() => StartServer());
        }

        private void StartServer()
        {
            try
            {
                signalR().Build().RunAsync();
            }
            catch (Exception)
            {
                WriteToConsole("Server failed to start. A server is already running on " + SERVER_URL);

                //Re-enable button to let user try to start server again
                this.Invoke((Action)(() => btnStart.Enabled = true));
                return;
            }

            this.Invoke((Action)(() => btnStop.Enabled = true));
            WriteToConsole("Server started at " + SERVER_URL);
        }

        private void WriteToConsole(string message)
        {
            if (lstConsole.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                    WriteToConsole(message)
                ));

                return;
            }

            lstConsole.Items.Add(message);
        }
    }
}
