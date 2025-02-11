using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class client2 : Form
    {
        private TcpClient serverConnection;
        private TcpListener peerListener;
        private TcpClient peerConnection;
        private Thread peerListenerThread;
        private string selectedPeer;

        private const int PeerPort = 7000; // Fixed port for peer-to-peer communication
        public client2()
        {
            InitializeComponent();
        }

        private void client2_Load(object sender, EventArgs e)
        {
            txtServerIP.Text = "127.0.0.1";
            //string localIP = GetLocalIPAddress();
            //LogMessage($"Local IP Address: {localIP}");
            StartPeerListener();
        }

        private void StartPeerListener()
        {
            try
            {
                peerListener = new TcpListener(IPAddress.Any, PeerPort);
                peerListener.Start();

                peerListenerThread = new Thread(() =>
                {
                    while (true)
                    {
                        TcpClient client = peerListener.AcceptTcpClient();
                        HandlePeerConnection(client);
                    }
                })
                {
                    IsBackground = true
                };
                peerListenerThread.Start();
                LogMessage($"Peer listener started on port {PeerPort}");
            }
            catch (Exception ex)
            {
                LogMessage($"Failed to start peer listener: {ex.Message}");
            }
        }

        private void HandlePeerConnection(TcpClient client)
        {

            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Peer disconnected
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    LogMessage($"Received: {message}");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Peer connection error: {ex.Message}");
            }
        }

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            try
            {
                serverConnection = new TcpClient();
                serverConnection.Connect(txtServerIP.Text, 5000); // Connect to server's fixed port

                // Retrieve correct local IP and port
                 //string localEndPoint = ((IPEndPoint)serverConnection.Client.LocalEndPoint).ToString();

                // Send IP and peer-to-peer port to the server
                // Retrieve the unique local IP and port
                // string localIP = GetLocalIPAddress();
                string localIP = "127.0.0.1";
                string clientInfo = $"{localIP}:{PeerPort}";
                byte[] data = Encoding.UTF8.GetBytes(clientInfo);
                serverConnection.GetStream().Write(data, 0, data.Length);

                LogMessage($"Connected to server. Sent: {clientInfo}");
            }
            catch (Exception ex)
            {
                LogMessage($"Error connecting to server: {ex.Message}");
            }
        }

        private void btnRequestClientList_Click(object sender, EventArgs e)
        {
            try
            {
                if (serverConnection != null && serverConnection.Connected)
                {
                    // Send the LIST command to the server
                    string listCommand = "LIST";
                    byte[] data = Encoding.UTF8.GetBytes(listCommand);
                    serverConnection.GetStream().Write(data, 0, data.Length);

                    // Wait and process the client list response
                    ReceiveClientList();
                }
                else
                {
                    LogMessage("Not connected to the server.");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error requesting client list: {ex.Message}");
            }
        }

        private void ReceiveClientList()
        {
            //try
            //{
            //    NetworkStream stream = serverConnection.GetStream();
            //    byte[] buffer = new byte[1024];
            //    int bytesRead = stream.Read(buffer, 0, buffer.Length);

            //    string clientList = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            //    string[] clients = clientList.Split(',');

            //    LogMessage("Available clients received:");
            //    foreach (var client in clients)
            //    {
            //        LogMessage(client);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogMessage($"Error receiving client list: {ex.Message}");
            //}
            try
            {
                NetworkStream stream = serverConnection.GetStream();

                // Read the length prefix (4 bytes)
                byte[] lengthBuffer = new byte[4];
                int bytesRead = stream.Read(lengthBuffer, 0, 4);
                if (bytesRead != 4)
                {
                    LogMessage("Error: Could not read the full length prefix.");
                    return;
                }

                int messageLength = BitConverter.ToInt32(lengthBuffer, 0);
                LogMessage($"Expected message length: {messageLength}");

                // Read the actual message
                byte[] messageBuffer = new byte[messageLength];
                int totalBytesRead = 0;

                while (totalBytesRead < messageLength)
                {
                    bytesRead = stream.Read(messageBuffer, totalBytesRead, messageLength - totalBytesRead);
                    if (bytesRead == 0) break; // Connection closed
                    totalBytesRead += bytesRead;
                }

                if (totalBytesRead != messageLength)
                {
                    LogMessage("Error: Could not read the full client list.");
                    return;
                }

                string clientList = Encoding.UTF8.GetString(messageBuffer, 0, totalBytesRead);

                // Debug log to verify received data
                LogMessage($"Raw client list received: {clientList}");

                //string[] clients = clientList.Split(',');

                LogMessage("Available peers:");
                foreach (var client in clientList.Split(','))
                {
                    if (!string.IsNullOrWhiteSpace(client))
                    {
                        LogMessage(client);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error receiving client list: {ex.Message}");
            }
        }





        private void btnSelectPeer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPeerIP.Text))
            {
                //selectedPeer = txtPeerIP.Text;
                try
                {
                    selectedPeer = txtPeerIP.Text;
                    string[] peerInfo = selectedPeer.Split(':');
                    peerConnection = new TcpClient(peerInfo[0], int.Parse(peerInfo[1]));
                    LogMessage($"Connected to peer: {selectedPeer}");
                    // Start listening for incoming messages
                    Thread peerListenerThread = new Thread(ListenForPeerMessages);
                    peerListenerThread.IsBackground = true;
                    peerListenerThread.Start();
                }
                catch (Exception ex)
                {
                    LogMessage($"Failed to connect to peer: {ex.Message}");
                }
            }
        }

        private void btnSendMessageToPeer_Click(object sender, EventArgs e)
        {
            try
            {
                string message = txtMessage.Text;
                if (peerConnection != null && peerConnection.Connected)
                {
                    SendMessageToPeer(message);
                    LogMessage($"Sent to {selectedPeer}: {message}");
                    txtMessage.Text = "";
                    txtMessage.Focus();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error sending message to peer: {ex.Message}");
            }
        }

        //sending file to peer
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                SendFileToPeer(filePath);
            }
        }

        private void ListenForPeerMessages()
        {
 

            try
            {
                NetworkStream stream = peerConnection.GetStream();
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    LogMessage($"Received from {selectedPeer}: {message}");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Peer connection error: {ex.Message}");
            }
        }

        private void SendMessageToServer(string message)
        {
            if (serverConnection != null && serverConnection.Connected)
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                serverConnection.GetStream().Write(data, 0, data.Length);
            }
            else
            {
                MessageBox.Show("Not connected");
            }
        }

        private void SendMessageToPeer(string message)
        {
            try
            {
                if (peerConnection != null && peerConnection.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    peerConnection.GetStream().Write(data, 0, data.Length);
                    LogMessage($"Message sent to peer: {message}");
                }
                else
                {
                    LogMessage("Cannot send message. Not connected to a peer.");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error sending message to peer: {ex.Message}");
            }
        }

        private void SendFileToPeer(string filePath)
        {
            try
            {
                if (peerConnection != null && peerConnection.Connected)
                {
                    byte[] fileData = File.ReadAllBytes(filePath);
                    string fileName = Path.GetFileName(filePath);
                    string header = $"FILE:{fileName}:{fileData.Length}";
                    byte[] headerData = Encoding.UTF8.GetBytes(header);

                    NetworkStream stream = peerConnection.GetStream();
                    stream.Write(headerData, 0, headerData.Length);
                    stream.Write(fileData, 0, fileData.Length);

                    LogMessage($"File sent to peer: {fileName}");
                }
                else
                {
                    LogMessage("Cannot send file. Not connected to a peer.");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"File transfer failed: {ex.Message}");
            }
        }

        private void LogMessage(string message)
        {
            Invoke((MethodInvoker)(() =>
            {
                listBoxLogs.Items.Add(message);
            }));
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
