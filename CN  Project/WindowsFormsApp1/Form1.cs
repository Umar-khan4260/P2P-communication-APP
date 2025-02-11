using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace WindowsFormsApp1
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        private Thread listenerThread;
        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();


        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStartSever_Click(object sender, EventArgs e)
        {
            listenerThread = new Thread(StartServer);
            listenerThread.IsBackground = true;
            listenerThread.Start();
            LogMessage("Server: Server started...");
            btnStartSever.Text = "Server started";
            btnStartSever.Enabled = false;
        }

        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                string clientEndPoint = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();

                lock (clients)
                {
                    clients[clientEndPoint] = client;
                }

                LogMessage($"Client connected: {clientEndPoint}");

                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.IsBackground = true;
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (message == "LIST")
                    {
                        SendClientList(client);
                    }
                }
            }
            catch
            {
                string clientEndPoint = ((IPEndPoint)client.Client.RemoteEndPoint).ToString();
                lock (clients)
                {
                    clients.Remove(clientEndPoint);
                }
                LogMessage($"Client disconnected: {clientEndPoint}");
            }
        }

        private void SendClientList(TcpClient client)
        {
            List<string> clientList = new List<string>();

            lock (clients)
            {
                foreach (var entry in clients)
                {
                    if (entry.Key != ((IPEndPoint)client.Client.RemoteEndPoint).ToString())
                    {
                        clientList.Add(entry.Key);
                    }
                }
            }

            string listMessage = string.Join(",", clientList);
            byte[] data = Encoding.UTF8.GetBytes(listMessage);
            client.GetStream().Write(data, 0, data.Length);
        }

        private void LogMessage(string message)
        {
            Invoke((MethodInvoker)(() =>
            {
                listBoxLogs.Items.Add(message);
            }));
        }

        private void listBoxLogs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
