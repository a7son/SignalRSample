using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalRSample.Client.NetFramework
{
    public partial class Form1 : Form
    {
        private const string SERVER_URL = "http://127.0.0.1:5151/ChatHub";

        private HubConnection _hubConnection;        

        public Form1()
        {
            InitializeComponent();

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(SERVER_URL)
                .Build();

            _hubConnection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _hubConnection.StartAsync();
            };            

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                messageList.Invoke(new MethodInvoker(() =>
                {
                    var newMessage = $"{user}: {message}";
                    messageList.Items.Add(newMessage);
                }));
            });

            ConnectAsync();
        }

        private async void ConnectAsync()
        {            
            try
            {
                await _hubConnection.StartAsync();
                messageList.Items.Add("Connection started");

                btnKirim.Enabled = true;
            }
            catch (Exception ex)
            {
                messageList.Items.Add(ex.Message);
            }
        }

        private async void btnKirim_Click(object sender, EventArgs e)
        {
            #region snippet_ErrorHandling
            try
            {
                #region snippet_InvokeAsync
                await _hubConnection.InvokeAsync("SendMessage",
                    "Net Framework", txtPesan.Text);
                #endregion
            }
            catch (Exception ex)
            {
                messageList.Items.Add(ex.Message);
            }
            #endregion
        }
    }
}
