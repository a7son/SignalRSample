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

namespace SignalRSample.Client.NetCore
{
    public partial class FrmClient : Form
    {
        private const string SERVER_URL = "http://localhost:5151/ChatHub";

        private HubConnection hubConnection;        

        public FrmClient()
        {
            InitializeComponent();

            hubConnection = new HubConnectionBuilder()
                .WithUrl(SERVER_URL)
                .Build();
            
            hubConnection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await hubConnection.StartAsync();
            };            
        }

        private async void FrmClient_Load(object sender, EventArgs e)
        {
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                messageList.Invoke(new MethodInvoker(() =>
                {
                    var newMessage = $"{user}: {message}";
                    messageList.Items.Add(newMessage);
                }));
            });

            try
            {
                await hubConnection.StartAsync();
                messageList.Items.Add("Connection started");
                
                btnSend.Enabled = true;
            }
            catch (Exception ex)
            {
                messageList.Items.Add(ex.Message);
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            #region snippet_ErrorHandling
            try
            {
                #region snippet_InvokeAsync
                await hubConnection.InvokeAsync("SendMessage",
                    "Asep", txtPesan.Text);
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
