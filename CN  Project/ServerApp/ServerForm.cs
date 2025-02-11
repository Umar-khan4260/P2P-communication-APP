using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerApp
{
    public partial class ServerForm : Form
    {
        private TcpListener mainServer;
        private TcpListener backupServer;
        private Thread mainListenerThread;
        private Thread backupListenerThread;

        private Dictionary<string, int> clients = new Dictionary<string, int>(); // Store c lient IP and peer-to-peer port
       
        private bool isMainRunning = false;
        private bool isBackupRunning = false;

        public ServerForm()
        {
            InitializeComponent();
            
            
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStartSever_Click(object sender, EventArgs e)
        {
            //mainListenerThread = new Thread(StartServer)
            //{
            //    IsBackground = true
            //};
            //isMainRunning = true; // Mark server as running
            //mainListenerThread.Start();

            //LogMessage("Server: Server started...");
            //btnSta rtSever.Enabled = false; // Disable Start button
            //btnStopServer.Enabled = true;  // Enable Stop button
            StartServer(mainServer, ref mainListenerThread, 5000, "Main Server", ref isMainRunning, btnStartServer, btnStopServer);
        }

        private void StartServer(TcpListener server, ref Thread listenerThread, int port, string serverName, ref bool isRunning, Button btnStart, Button btnStop)
        {
            if (isRunning) return;

            server = new TcpListener(IPAddress.Any, port); // Initialize server properly
            listenerThread = new Thread(() =>
            {
                //TcpListener localServer = new TcpListener(IPAddress.Any, port); // Local variable
                bool running = true; // Local variable
                try
                {
                    server.Start();
                    LogMessage($"{serverName} started on port {port}...");
                    while (running)
                    {
                        if (server.Pending())
                        {
                            TcpClient client = server.AcceptTcpClient();
                            Thread clientThread = new Thread(() => HandleClient(client, serverName))
                            {
                                IsBackground = true
                            };
                            clientThread.Start();
                        }
                    }
                }
                catch (SocketException)
                {
                    LogMessage($"{serverName} stopped.");
                }
                finally
                {
                    server?.Stop();
                }

                // Update the shared state after thread finishes
                //server = null;
                //isRunning = false;
            })
            { IsBackground = true };

            listenerThread.Start();
            isRunning = true; // Update state
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }


        //private void StartServer()
        //{
        //    mainServer = new TcpListener(IPAddress.Any, 5000);
        //    mainServer.Start();
        //    LogMessage("Server: Listening for clients...");

        //    try
        //    {
        //        while (isMainRunning) // Check the flag to stop the server
        //        {
        //            if (mainServer.Pending()) // Accept client if pending
        //            {
        //                TcpClient client = mainServer.AcceptTcpClient();
        //                Thread clientThread = new Thread(() => HandleClient(client))
        //                {
        //                    IsBackground = true
        //                };
        //                clientThread.Start();
        //            }
        //        }
        //    }
        //    catch (SocketException)
        //    {
        //        LogMessage("Server: Server has been stopped.");
        //    }
        //    finally
        //    {
        //        mainServer?.Stop();
        //        LogMessage("Server: Listener stopped.");
        //    }
        //    //server = new TcpListener(IPAddress.Any, 5000); // Server listens on port 5000
        //    //server.Start();

        //    //while (true)
        //    //{
        //    //    TcpClient client = server.AcceptTcpClient();
        //    //    Thread clientThread = new Thread(() => HandleClient(client))
        //    //    {
        //    //        IsBackground = true
        //    //    };
        //    //    clientThread.Start();
        //    //}
        //}

        private void HandleClient(TcpClient client,string serverName)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            try
            {
                // Read client's IP and port
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string clientInfo = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                LogMessage($"{serverName}:Received client info: {clientInfo}");

                if (!clientInfo.Contains(":"))
                {
                    LogMessage($"Invalid client info: {clientInfo}. Skipping registration.");
                    return;
                }

                string[] parts = clientInfo.Split(':');
                string clientIP = parts[0];
                int clientPort = int.Parse(parts[1]);

                string uniqueKey = GenerateUniqueKey(clientIP);

                lock (clients)
                {
                    clients[uniqueKey] = clientPort; // Save the unique key and port
                }

                LogMessage($"Client registered successfully: {uniqueKey}:{clientPort}. Current clients: {clients.Count}");

                // Listen for further messages (e.g., LIST)
                while (true)
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Client disconnected

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    if (message == "LIST")
                    {
                        SendClientList(client, clientIP,clientPort);
                    }
                }
            }
            catch (Exception ex)
            {
                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                lock (clients)
                {
                    clients = clients
                        .Where(entry => !entry.Key.StartsWith(clientIP))
                        .ToDictionary(entry => entry.Key, entry => entry.Value); // Remove disconnected client
                }
                LogMessage($"Client disconnected: {clientIP}. Error: {ex.Message}");
            }
            //NetworkStream stream = client.GetStream();
            //byte[] buffer = new byte[1024];

            //try
            //{
            //    // Read client's IP and port
            //    int bytesRead = stream.Read(buffer, 0, buffer.Length);
            //    string clientInfo = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            //    LogMessage($"Received client info: {clientInfo}");
            //    if (!clientInfo.Contains(":"))
            //    {
            //        LogMessage($"Invalid client info: {clientInfo}. Skipping registration.");
            //        return;
            //    }

            //    string[] parts = clientInfo.Split(':');
            //    string clientIP = parts[0];
            //    int clientPort = int.Parse(parts[1]);

            //    lock (clients)
            //    {
            //        clients[clientIP] = clientPort; // Save the client's IP and peer port
            //    }

            //    LogMessage($"Client registered successfully: {clientIP}:{clientPort}. Current clients: {clients.Count}");

            //    // Listen for further messages (e.g., LIST)
            //    while (true)
            //    {
            //        bytesRead = stream.Read(buffer, 0, buffer.Length);
            //        if (bytesRead == 0) break; // Client disconnected

            //        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
            //        if (message == "LIST")
            //        {
            //            SendClientList(client, clientIP);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            //    lock (clients)
            //    {
            //        clients.Remove(clientIP);
            //    }
            //    LogMessage($"Client disconnected: {clientIP}. Error: {ex.Message}");
            //}
        }

        private string GenerateUniqueKey(string clientIP)
        {
            lock (clients)
            {
                int counter = clients.Count(c => c.Key.EndsWith(clientIP)) + 1; // Find how many entries exist for this IP
                string uniqueKey = $"{counter}{clientIP}"; // Always append the counter

                return uniqueKey;
            }
        }

        private void SendClientList(TcpClient client, string requesterIP,int requesterPort)
        {
            lock (clients)
            {
                LogMessage($"Constructing client list. Current clients: {string.Join(", ", clients.Select(c => $"{c.Key}:{c.Value}"))}");
                var peerList = new List<string>();

                foreach (var entry in clients)
                {
                    // Remove any prepended number when sending the client list
                    string cleanIP = RemovePrependedNumber(entry.Key);
                  //  LogMessage($"cleanip: {cl}");
                    if (requesterPort!=entry.Value) // Exclude the requester
                    {
                        peerList.Add($"{cleanIP}:{entry.Value}");
                    }
                }

                string clientList = string.Join(",", peerList);

                byte[] data = Encoding.UTF8.GetBytes(clientList);

                // Send length prefix
                byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

                try
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                    stream.Write(data, 0, data.Length);
                    stream.Flush(); // Ensure data is sent
                    LogMessage($"Sent client list to {requesterIP}:{requesterPort}= {clientList}");
                }
                catch (Exception ex)
                {
                    LogMessage($"Failed to send client list: {ex.Message}");
                }
            }
            //lock (clients)
            //{
            //    LogMessage($"Constructing client list. Current clients: {string.Join(", ", clients.Select(c => $"{c.Key}:{c.Value}"))}");
            //    var peerList = new List<string>();

            //    foreach (var entry in clients)
            //    {
            //        if (entry.Key != requesterIP) // Exclude the requester
            //        {
            //            peerList.Add($"{entry.Key}:{entry.Value}");
            //        }
            //    }

            //    string clientList = string.Join(",", peerList);

            //    byte[] data = Encoding.UTF8.GetBytes(clientList);

            //    // Send length prefix
            //    byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

            //    try
            //    {
            //        NetworkStream stream = client.GetStream();
            //        stream.Write(lengthPrefix, 0, lengthPrefix.Length);
            //        stream.Write(data, 0, data.Length);
            //        stream.Flush(); // Ensure data is sent
            //        LogMessage($"Sent client list to {requesterIP}: {clientList}");
            //    }
            //    catch (Exception ex)
            //    {
            //        LogMessage($"Failed to send client list: {ex.Message}");
            //    }
            //}
        }

        private string RemovePrependedNumber(string key)
        {
            // Remove only the first digit from the key if it exists
            if (key.Length > 0 && char.IsDigit(key[0]))
            {
                return key.Substring(1);
            }
            return key; // Return unchanged if the first character is not a digit
        }




        private void LogMessage(string message)
        {
            Invoke((MethodInvoker)(() =>
            {
                listBoxLogs.Items.Add(message);
            }));
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            //StopServer();
            //LogMessage("Server: Server stopped.");

            //btnStartSever.Enabled = true; // Enable Start button
            //btnStopServer.Enabled = false; // Disable Stop button
            StopServer(ref mainServer, ref isMainRunning, "Main Server", btnStartServer, btnStopServer);

        }

        private void StopServer(ref TcpListener server, ref bool isRunning, string serverName, Button btnStart, Button btnStop)
        {
            isRunning = false; // Set the flag to stop the server loop.
            server?.Stop(); // Stop the server.

            LogMessage($"{serverName} stopped.");
            btnStart.Enabled = true; // Re-enable Start button.
            btnStop.Enabled = false; // Disable Stop button.

            // Automatically start the backup server when the main server stops.
            if (serverName == "Main Server" && !isBackupRunning)
            {
                backupServer = new TcpListener(IPAddress.Any, 5001);
                LogMessage("Starting Backup Server...");
                StartServer(backupServer, ref backupListenerThread, 5001, "Backup Server", ref isBackupRunning, btnStartBackupServer, btnStopBackupServer);
            }
        }

        //private void StopServer()
        //{
        //    isMainRunning = false; // Set flag to false
        //    mainServer?.Stop();    // Stop listening for clients
        //}

        private void btnStartBackupServer_Click(object sender, EventArgs e)
        {
            StartServer(backupServer, ref backupListenerThread, 5001, "Backup Server", ref isBackupRunning, btnStartBackupServer, btnStopBackupServer);
        }

        private void btnStopBackupServer_Click(object sender, EventArgs e)
        {
             StopServer(ref backupServer, ref isBackupRunning, "Backup Server", btnStartBackupServer, btnStopBackupServer);
        }

        private void btnStartSever_Click_1(object sender, EventArgs e)
        {
            StartServer(mainServer, ref mainListenerThread, 5000, "Main Server", ref isMainRunning, btnStartServer, btnStopServer);
        }

        private void btnStopServer_Click_1(object sender, EventArgs e)
        {
            StopServer(ref mainServer, ref isMainRunning, "Main Server", btnStartServer, btnStopServer);
        }

    }
}
