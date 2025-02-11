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
using System.Collections.Specialized;
using System.Security.Cryptography;
namespace WindowsFormsApp1
{




    public partial class client1 : Form
    {
        private TcpClient serverConnection;
        private TcpListener peerListener;
        private TcpClient peerConnection;
        private Thread peerListenerThread;
        private string selectedPeer;

        // private const int PeerPort = 6000; // Fixed port for peer-to-peer communication
        private const int MinPeerPort = 1000; // Minimum 4-digit port
        private const int MaxPeerPort = 9999; // Maximum 4-digit port
        private int PeerPort;

        private List<string> peerList = new List<string>();
        private TcpListener listener;

        public void StartListeningForGroupInvites()
        {
            int listenPort = 5000; // The port for receiving invites (ensure all peers use the same port)
            listener = new TcpListener(System.Net.IPAddress.Any, listenPort);
            listener.Start();

            // Run the listener in a separate task to avoid blocking the UI
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        // Accept incoming connections
                        var client = listener.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();

                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);

                        if (bytesRead > 0)
                        {
                            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            HandleGroupInvite(message);
                        }

                        client.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors
                        MessageBox.Show($"Error receiving group invite: {ex.Message}");
                    }
                }
            });
        }

        private void HandleGroupInvite(string message)
        {
            // Parse the invite message
            string[] messageParts = message.Split('|');
            if (messageParts.Length == 3 && messageParts[0] == "GROUP_INVITE")
            {
                string groupName = messageParts[1]; // The group name
                string senderName = messageParts[2]; // The sender's name or machine name

                // Display the group invite to the user
                ShowGroupInvite(groupName, senderName);
            }
            else
            {
                // Invalid message format
                MessageBox.Show("Received an invalid group invite.");
            }
        }

        private void ShowGroupInvite(string groupName, string senderName)
        {
            // Display a message box or show the invite in a UI element (e.g., ListBox, Label, etc.)
            DialogResult result = MessageBox.Show($"You have been invited to join group '{groupName}' by {senderName}. Do you want to join?", "Group Invite", MessageBoxButtons.YesNo);

            // If the user accepts the invite
            if (result == DialogResult.Yes)
            {
                JoinGroupChat(groupName, senderName);
            }
        }

        // Method to join the group chat
        private void JoinGroupChat(string groupName, string senderName)
        {
            // You can initialize a group chat window here
            MessageBox.Show($"You have joined the group '{groupName}' from {senderName}.");

            // Here you can add logic to start the group chat, e.g., opening a new window for the group chat
            // GroupChatWindow groupChat = new GroupChatWindow(groupName);
            // groupChat.Show();
        }


        public client1()
        {
            InitializeComponent();
            PeerPort = GenerateRandomPeerPort();
            //LogMessage($"Generated random PeerPort: {PeerPort}");

        }

        private int GenerateRandomPeerPort()
        {
            Random random = new Random();
            return random.Next(MinPeerPort, MaxPeerPort + 1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void client1_Load(object sender, EventArgs e)
        {
            txtServerIP.Text = "127.0.0.1";
           // string localIP = GetLocalIPAddress();
            //LogMessage($"Local IP Address: {localIP}");
            StartPeerListener();

            // Set up the ListView
            listView1.View = View.Details;
            listView1.Columns.Add("File Name", 150);
            listView1.Columns.Add("Size (Bytes)", 100);
            listView1.Columns.Add("Save Location", 150);
            listView1.FullRowSelect = true;
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

        //private void HandlePeerConnection(TcpClient client)
        //{

        //    try
        //    {
        //        NetworkStream stream = client.GetStream();
        //        byte[] buffer = new byte[1024];

        //        while (true)
        //        {
        //            int bytesRead = stream.Read(buffer, 0, buffer.Length);
        //            if (bytesRead == 0) break; // Peer disconnected
        //            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        //            LogMessage($"Received: {message}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogMessage($"Peer connection error: {ex.Message}");
        //    }
        //}

        ////private void HandlePeerConnection(TcpClient client)
        ////{
        ////    try
        ////    {
        ////        NetworkStream stream = client.GetStream();
        ////        byte[] buffer = new byte[1024];

        ////        while (true)
        ////        {
        ////            int bytesRead = stream.Read(buffer, 0, buffer.Length);
        ////            if (bytesRead == 0) break; // Peer disconnected

        ////            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        ////            if (message.StartsWith("FILE:")) // File transfer header
        ////            {
        ////                string[] headerParts = message.Split(':');
        ////                string fileName = headerParts[1];
        ////                int fileSize = int.Parse(headerParts[2]);

        ////                LogMessage($"Receiving file: {fileName} ({fileSize} bytes)");

        ////                // Receive the file data
        ////                byte[] fileData = new byte[fileSize];
        ////                int totalBytesReceived = 0;
        ////                while (totalBytesReceived < fileSize)
        ////                {
        ////                    bytesRead = stream.Read(fileData, totalBytesReceived, fileSize - totalBytesReceived);
        ////                    if (bytesRead == 0) break;
        ////                    totalBytesReceived += bytesRead;
        ////                }

        ////                // Save the received file
        ////                string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
        ////                File.WriteAllBytes(savePath, fileData);

        ////                LogMessage($"File saved to: {savePath}");

        ////                // Add the file details to listView1 (on the UI thread)
        ////                Invoke((MethodInvoker)(() =>
        ////                {
        ////                    ListViewItem item = new ListViewItem(fileName);
        ////                    item.SubItems.Add(fileSize.ToString());
        ////                    item.SubItems.Add(savePath);
        ////                    listView1.Items.Add(item);
        ////                }));
        ////            }
        ////            else
        ////            {
        ////                LogMessage($"Received from peer: {message}");
        ////            }
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        LogMessage($"Peer connection error: {ex.Message}");
        ////    }
        ////}

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

                    if (message.StartsWith("FILE:")) // File transfer header
                    {
                        string[] headerParts = message.Split(':');
                        string fileName = headerParts[1];
                        int fileSize = int.Parse(headerParts[2]);

                        LogMessage($"Receiving file: {fileName} ({fileSize} bytes)");

                        // Receive the file data
                        byte[] fileData = new byte[fileSize];
                        int totalBytesReceived = 0;
                        while (totalBytesReceived < fileSize)
                        {
                            bytesRead = stream.Read(fileData, totalBytesReceived, fileSize - totalBytesReceived);
                            if (bytesRead == 0) break;
                            totalBytesReceived += bytesRead;
                        }

                        // Temporary save path
                        string tempSavePath = Path.Combine(Path.GetTempPath(), fileName);

                        // Save the file temporarily
                        File.WriteAllBytes(tempSavePath, fileData);

                        // Show options to user
                        ShowFileOptionsDialog(fileName, tempSavePath);
                    }
                    else
                    {
                        LogMessage($"Received from peer: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Peer connection error: {ex.Message}");
            }
        }



        private void ShowFileOptionsDialog(string fileName, string tempFilePath)
        {
            using (var form = new Form())
            {
                // Set the title and size of the form
                form.Text = "File Received";
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.Size = new Size(400, 200); // Adjusted size
                form.StartPosition = FormStartPosition.CenterParent;

                // Prevent the form from being resized or minimized
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.ControlBox = false;

                // Create and configure the label to show the received file message
                Label label = new Label
                {
                    Text = $"Filename received: {fileName}\nDo you want to preview, save, or reject the file?",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Padding = new Padding(10),
                    Dock = DockStyle.Top,
                    Height = 80 // Adjusted to give enough space for the message
                };

                // Create a FlowLayoutPanel to arrange the buttons horizontally
                var flowLayoutPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Bottom,
                    FlowDirection = FlowDirection.LeftToRight,
                    Padding = new Padding(10),
                    Height = 60 // Adjusted button area height
                };

                // Create the "Download" button
                Button btnDownload = new Button
                {
                    Text = "Download",
                    DialogResult = DialogResult.Yes,
                    Height = 40,
                    Width = 100
                };

                // Create the "Reject" button
                Button btnReject = new Button
                {
                    Text = "Reject",
                    DialogResult = DialogResult.No,
                    Height = 40,
                    Width = 100
                };

                // Create the "Preview" button
                Button btnPreview = new Button
                {
                    Text = "Preview",
                    DialogResult = DialogResult.Cancel,
                    Height = 40,
                    Width = 100
                };

                // Add buttons to the FlowLayoutPanel
                flowLayoutPanel.Controls.Add(btnDownload);
                flowLayoutPanel.Controls.Add(btnReject);
                flowLayoutPanel.Controls.Add(btnPreview);

                // Add label and FlowLayoutPanel to the form
                form.Controls.Add(label);
                form.Controls.Add(flowLayoutPanel);

                // Show the form as a dialog and handle the result
                var dialogResult = form.ShowDialog();

                // Process the result based on the button clicked
                switch (dialogResult)
                {
                    case DialogResult.Yes: // Save
                        SaveFile(tempFilePath, fileName, listView1); // Pass listView1
                        break;

                    case DialogResult.No: // Reject
                        RejectFile(tempFilePath);
                        break;

                    case DialogResult.Cancel: // Preview
                        PreviewFile(tempFilePath);
                        break;
                }
            }
        }





        private void SaveFile(string tempFilePath, string fileName, ListView listView1)
        {
            try
            {
                // Get the desktop path
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Construct the final save path
                string finalSavePath = Path.Combine(desktopPath, fileName);

                // Ensure a unique name for the file if a file with the same name exists
                finalSavePath = GenerateUniqueFileName(finalSavePath);

                // Move the file from the temporary path to the final destination
                if (File.Exists(tempFilePath))
                {
                    // Get the file size
                    long fileSize = new FileInfo(tempFilePath).Length;

                    File.Move(tempFilePath, finalSavePath);

                    LogMessage($"File saved to: {finalSavePath}");

                    // Update ListView with file information
                    if (listView1 != null)
                    {
                        listView1.Invoke(new Action(() =>
                        {
                            // Create a ListViewItem with the file details
                            ListViewItem item = new ListViewItem(fileName);          // File Name
                            item.SubItems.Add(fileSize.ToString());                // Size (Bytes)
                            item.SubItems.Add(finalSavePath);                      // Save Location
                            listView1.Items.Add(item);
                        }));
                    }
                    else
                    {
                        LogMessage("ListView is null; skipping UI update.");
                    }
                }
                else
                {
                    LogMessage($"Temporary file not found: {tempFilePath}");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error saving file: {ex.Message}");
            }
        }



        private void PreviewFile(string tempFilePath)
        {
            try
            {
                // Open the file with the default system viewer
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = tempFilePath;
                process.StartInfo.UseShellExecute = true;
                process.Start();

                // Wait for the file viewer to close
                process.WaitForExit();

                // After preview, show save/reject dialog again
                ShowFileOptionsDialog(Path.GetFileName(tempFilePath), tempFilePath);
            }
            catch (Exception ex)
            {
                LogMessage($"Error previewing file: {ex.Message}");
            }
        }

        private void RejectFile(string tempFilePath)
        {
            try
            {
                File.Delete(tempFilePath);
                LogMessage("File rejected and deleted.");
            }
            catch (Exception ex)
            {
                LogMessage($"Error rejecting file: {ex.Message}");
            }
        }




        private string GenerateUniqueFileName(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);

            int counter = 1;
            string newFilePath = filePath;

            while (File.Exists(newFilePath))
            {
                newFilePath = Path.Combine(directory, $"{fileNameWithoutExtension}({counter}){extension}");
                counter++;
            }

            return newFilePath;
        }


        //private void btnConnectToServer_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        serverConnection = new TcpClient();
        //        serverConnection.Connect(txtServerIP.Text, 5000); // Connect to server's fixed port

        //        // Retrieve correct local IP and port
        //        // string localEndPoint = ((IPEndPoint)serverConnection.Client.LocalEndPoint).ToString();

        //        // Send IP and peer-to-peer port to the server
        //        // Retrieve the unique local IP and port
        //        // string localIP = GetLocalIPAddress();
        //        string localIP = "127.0.0.1";
        //        string clientInfo = $"{localIP}:{PeerPort}";
        //        byte[] data = Encoding.UTF8.GetBytes(clientInfo);
        //        serverConnection.GetStream().Write(data, 0, data.Length);

        //        LogMessage($"Connected to server. Sent: {clientInfo}");
        //    }
        //    catch (Exception ex)
        //    {
        //        LogMessage($"Error connecting to server: {ex.Message}");
        //    }
        //}

        private void btnConnectToServer_Click(object sender, EventArgs e)
        {
            ConnectToServer("127.0.0.1", 5000); // Attempt to connect to Main Server
        }

        private void ConnectToServer(string serverIP, int port)
        {
            try
            {
                serverConnection = new TcpClient();
                serverConnection.Connect(serverIP, port);

                string clientInfo = $"127.0.0.1:{PeerPort}";
                byte[] data = Encoding.UTF8.GetBytes(clientInfo);
                serverConnection.GetStream().Write(data, 0, data.Length);

                LogMessage($"Connected to server on port {port}. Sent: {clientInfo}");
            }
            catch
            {
                if (port == 5000) // Retry backup server
                {
                    LogMessage("Main server not available. Trying backup server...");
                    ConnectToServer(serverIP, 5001);
                }
                else
                {
                    LogMessage("Failed to connect to both main and backup servers.");
                }
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

        //private void ReceiveClientList()
        //{
        //    //try
        //    //{
        //    //    NetworkStream stream = serverConnection.GetStream();
        //    //    byte[] buffer = new byte[1024];
        //    //    int bytesRead = stream.Read(buffer, 0, buffer.Length);

        //    //    string clientList = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        //    //    string[] clients = clientList.Split(',');

        //    //    LogMessage("Available clients received:");
        //    //    foreach (var client in clients)
        //    //    {
        //    //        LogMessage(client);
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    LogMessage($"Error receiving client list: {ex.Message}");
        //    //}
        //    try
        //    {
        //        NetworkStream stream = serverConnection.GetStream();

        //        // Read the length prefix (4 bytes)
        //        byte[] lengthBuffer = new byte[4];
        //        int bytesRead = stream.Read(lengthBuffer, 0, 4);
        //        if (bytesRead != 4)
        //        {
        //            LogMessage("Error: Could not read the full length prefix.");
        //            return;
        //        }

        //        int messageLength = BitConverter.ToInt32(lengthBuffer, 0);
        //        LogMessage($"Expected message length: {messageLength}");

        //        // Read the actual message
        //        byte[] messageBuffer = new byte[messageLength];
        //        int totalBytesRead = 0;

        //        while (totalBytesRead < messageLength)
        //        {
        //            bytesRead = stream.Read(messageBuffer, totalBytesRead, messageLength - totalBytesRead);
        //            if (bytesRead == 0) break; // Connection closed
        //            totalBytesRead += bytesRead;
        //        }

        //        if (totalBytesRead != messageLength)
        //        {
        //            LogMessage("Error: Could not read the full client list.");
        //            return;
        //        }

        //        string clientList = Encoding.UTF8.GetString(messageBuffer, 0, totalBytesRead);

        //        LogMessage($"Received peer list: {clientList}");

        //        //string[] clients = clientList.Split(',');
        //        LogMessage("Available peers:");
        //        foreach (var client in clientList.Split(','))
        //        {
        //            if (!string.IsNullOrWhiteSpace(client))
        //            {
        //                LogMessage(client);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogMessage($"Error receiving client list: {ex.Message}");
        //    }
        //}

        private void ReceiveClientList()
        {
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

                LogMessage($"Received peer list: {clientList}");

                // Store the peers in the peerList variable (retain your existing logic)
                peerList = clientList.Split(',').Where(client => !string.IsNullOrWhiteSpace(client)).ToList();

                // Optionally display the available peers in the list box
                LogMessage("Available peers:");
                foreach (var client in peerList)
                {
                    LogMessage(client);
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
            catch(Exception ex)
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

        private void MakeGroup_Click(object sender, EventArgs e)
        {
            if (peerList.Count > 0)
            {
                // Pass the peerList to GroupChatSetup form
                GroupChatSetup groupChatSetupForm = new GroupChatSetup(peerList);
                groupChatSetupForm.Show();
            }
            else
            {
                MessageBox.Show("No peers available. Please retrieve the peer list first.");
            }
        }

        private void grpOpen_Click(object sender, EventArgs e)
        {
            
            
            // Check if any selected item contains the '#' character
            if (listBoxLogs.SelectedItems.Cast<string>().Any(item => item.Contains("#")))
            {
                // If condition is met, execute your logic here
                MessageBox.Show("A selected item contains the '#' character.");
                GroupChat newGroupChat = new GroupChat();
                newGroupChat.Show();
            }
            else
            {
                // Logic for when no selected item contains '#'
                MessageBox.Show("No selected item contains the '#' character.");
            }
        }


        private void listBoxLogs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
