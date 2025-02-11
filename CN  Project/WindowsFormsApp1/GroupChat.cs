
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Windows.Forms;
//using System.Net.Sockets;
//using System.Net;
//using System.Xml.Linq;

//namespace WindowsFormsApp1
//{
//    public partial class GroupChat : Form
//    {
//        string name;
//        private System.Windows.Forms.Timer refreshTimer;

//        private List<string> peers; // Store the list of peers (IP:Port)
//        private string groupName;   // Store the group name
//        private List<TcpClient> peerConnections; // List to keep track of peer connections

//        // Constructor accepting peer list and group name
//        public GroupChat(List<string> peers, string groupName)
//        {

//            InitializeComponent();
//            this.peers = peers;           // Initialize peer list
//            this.groupName = groupName;   // Initialize group name
//            this.peerConnections = new List<TcpClient>(); // Initialize peerConnections list

//            // Save the group data to the file
//            SaveGroupData(peers, groupName);

//            // Set the group name label
//            labelGroupName.Text = groupName;

//            // Attempt to connect to each peer and start listening for messages
//            ConnectToPeers();

//            // Print the peer list to verify
//            PrintPeerList();
//            refreshTimer = new System.Windows.Forms.Timer();

//            refreshTimer.Interval = 1000; // 1 second
//            refreshTimer.Tick += RefreshTimer_Tick;

//            // Start the timer
//            refreshTimer.Start();
//        }
//        private void RefreshTimer_Tick(object sender, EventArgs e)
//        {
//            // Sync with the file to capture any missed updates
//            LoadMessageHistory();
//        }


//        // Non-parameterized constructor
//        public GroupChat()
//        {
//            InitializeComponent();

//            // Load the group data from the file
//            LoadGroupData();

//            // If data was loaded successfully, continue initializing
//            if (peers != null && peers.Count > 0 && groupName != null)
//            {
//                labelGroupName.Text = groupName;
//                this.peerConnections = new List<TcpClient>(); // Initialize an empty list

//                // Connect to peers (except for themselves)
//                ConnectToPeers();
//            }
//            else
//            {
//                MessageBox.Show("No saved group data found. Please initialize the group first.");
//            }
//        }

//        // Method to save group data to a text file
//        public void SaveGroupData(List<string> peers, string groupName)
//        {
//            string filePath = "groupData.txt";

//            try
//            {
//                // Write the group name to the first line
//                File.WriteAllText(filePath, groupName + Environment.NewLine);

//                // Write each peer to the file on a new line
//                foreach (var peer in peers)
//                {
//                    File.AppendAllText(filePath, peer + Environment.NewLine);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error saving group data: {ex.Message}");
//            }
//        }


//        public void LoadGroupData()
//        {
//            string filePath = "groupData.txt";
//            string historyFilePath = "msgHistory.txt";

//            try
//            {
//                if (File.Exists(filePath))
//                {
//                    // Read all lines from the group data file
//                    string[] lines = File.ReadAllLines(filePath);

//                    // The first line is the group name
//                    groupName = lines[0];

//                    // The rest of the lines are the peers
//                    peers = lines.Skip(1).ToList();

//                    // Set the group name label
//                    labelGroupName.Text = groupName;
//                }
//                else
//                {
//                    MessageBox.Show("No saved group data found.");
//                }

//                // Load the message history from msgHistory.txt
//                if (File.Exists(historyFilePath))
//                {
//                    string[] messages = File.ReadAllLines(historyFilePath);
//                    foreach (var message in messages)
//                    {
//                        history.Items.Add(message); // Add each saved message to the ListBox
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading group data or message history: {ex.Message}");
//            }
//        }



//        // Method to print the peer list
//        private void PrintPeerList()
//        {
//            string peerList = string.Join(Environment.NewLine, peers); // Join peers into a single string
//            MessageBox.Show($"Peer List:\n{peerList}", "Peers", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        // Method to connect to all peers and listen for messages
//        private void ConnectToPeers()
//        {
//            foreach (var peer in peers)  // Iterate through all peers
//            {
//                try
//                {
//                    // Extract IP and port from the peer string (ip:port)
//                    string[] peerInfo = peer.Split(':');
//                    string ipAddress = peerInfo[0];
//                    int port = int.Parse(peerInfo[1]);

//                    // Establish TCP connection to the peer
//                    TcpClient peerConnection = new TcpClient(ipAddress, port);
//                    peerConnections.Add(peerConnection); // Add the connection to the list

//                    LogMessage($"Connected to peer: {peer}");

//                    // Start listening for incoming messages from this peer in a background thread
//                    Thread peerListenerThread = new Thread(() => ListenForPeerMessages(peerConnection));
//                    peerListenerThread.IsBackground = true;
//                    peerListenerThread.Start();

//                    // Optional: Add a small delay between connections to avoid overload
//                    Thread.Sleep(100); // 100ms delay between connection attempts
//                }
//                catch (Exception ex)
//                {
//                    LogMessage($"Failed to connect to peer {peer}: {ex.Message}");
//                }
//            }
//        }


//        private void ListenForPeerMessages(TcpClient peerConnection)
//        {
//            try
//            {
//                NetworkStream stream = peerConnection.GetStream();
//                byte[] buffer = new byte[1024];

//                while (true)
//                {
//                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
//                    if (bytesRead == 0) break; // Connection closed

//                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

//                    // Update the ListBox directly
//                    Invoke(new Action(() =>
//                    {
//                        history.Items.Add($"Peer: {message}");
//                    }));

//                    // Optionally save the message to msgHistory.txt
//                    SaveMessageHistory($"Peer: {message}");
//                }
//            }
//            catch (Exception ex)
//            {
//                LogMessage($"Error while listening for messages from peer: {ex.Message}");
//            }
//        }



//        // Method to log messages (you can display them in a textbox or a log panel)
//        private void LogMessage(string message)
//        {
//            // For now, just print to the console (you could update a TextBox or ListBox)
//            MessageBox.Show(message);
//        }



//        private void cendmsg_Click(object sender, EventArgs e)
//        {
//            if (peerConnections.Count <= 0)
//            {
//                MessageBox.Show("No peers connected.");
//                return;
//            }

//            string messageToSend = "#"+messageInput.Text.Trim();
//            if (string.IsNullOrEmpty(messageToSend))
//            {
//                MessageBox.Show("Message cannot be empty.");
//                return;
//            }

//            byte[] data = Encoding.UTF8.GetBytes(messageToSend);

//            foreach (var connection in peerConnections)
//            {
//                try
//                {
//                    if (connection.Connected)
//                    {
//                        NetworkStream stream = connection.GetStream();
//                        stream.Write(data, 0, data.Length);
//                        LogMessage($"Message sent to peer: {connection.Client.RemoteEndPoint}");
//                    }
//                    else
//                    {
//                        LogMessage($"Connection is not open to {connection.Client.RemoteEndPoint}");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    LogMessage($"Failed to send message to peer: {ex.Message}");
//                }
//            }

//            // Add the message to the local history
//            history.Items.Add(name + ": " + messageToSend.TrimStart('#'));


//            // Save the message to msgHistory.txt
//            SaveMessageHistory(name + ": " + messageToSend.TrimStart('#'));


//            // Clear the input field
//            messageInput.Clear();
//        }


//        // Method to save message to msgHistory.txt
//        public void SaveMessageHistory(string message)
//        {
//            string historyFilePath = "msgHistory.txt";

//            try
//            {
//                // Append the message to the file
//                File.AppendAllText(historyFilePath, message + Environment.NewLine);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error saving message to history: {ex.Message}");
//            }
//        }

//        private int lastLoadedLine = 0; // Tracks the last line loaded from the file

//        private HashSet<string> displayedMessages = new HashSet<string>();

//        public void LoadMessageHistory()
//        {
//            string historyFilePath = "msgHistory.txt";

//            try
//            {
//                if (File.Exists(historyFilePath))
//                {
//                    string[] messages = File.ReadAllLines(historyFilePath);

//                    foreach (var message in messages)
//                    {
//                        if (!displayedMessages.Contains(message))
//                        {
//                            history.Items.Add(message);
//                            displayedMessages.Add(message);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading message history: {ex.Message}");
//            }
//        }

//        private void userName_TextChanged(object sender, EventArgs e)
//        {
//            name = userName.Text;
//        }
//    }



//}


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class GroupChat : Form
    {
        string name;
        private System.Windows.Forms.Timer refreshTimer;

        private List<string> peers; // Store the list of peers (IP:Port)
        private string groupName;   // Store the group name
        private List<TcpClient> peerConnections; // List to keep track of peer connections

        private int lastLoadedLine = 0; // Tracks the last line loaded from the file
        private HashSet<string> displayedMessages = new HashSet<string>(); // To prevent displaying duplicates

        // Constructor accepting peer list and group name
        public GroupChat(List<string> peers, string groupName)
        {
            InitializeComponent();
            this.peers = peers;           // Initialize peer list
            this.groupName = groupName;   // Initialize group name
            this.peerConnections = new List<TcpClient>(); // Initialize peerConnections list

            // Save the group data to the file
            SaveGroupData(peers, groupName);

            // Set the group name label
            labelGroupName.Text = groupName;

            // Attempt to connect to each peer and start listening for messages
            ConnectToPeers();

            // Print the peer list to verify
            PrintPeerList();

            // Set up the refresh timer for 0.5 seconds
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 1000; // 500 milliseconds
            refreshTimer.Tick += RefreshTimer_Tick;

            // Start the timer
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Sync with the file to capture any missed updates
            LoadMessageHistory();
        }

        // Non-parameterized constructor
        public GroupChat()
        {
            InitializeComponent();

            // Load the group data from the file
            LoadGroupData();

            // If data was loaded successfully, continue initializing
            if (peers != null && peers.Count > 0 && groupName != null)
            {
                labelGroupName.Text = groupName;
                this.peerConnections = new List<TcpClient>(); // Initialize an empty list

                // Connect to peers (except for themselves)
                ConnectToPeers();
            }
            else
            {
                MessageBox.Show("No saved group data found. Please initialize the group first.");
            }
        }

        // Method to save group data to a text file
        public void SaveGroupData(List<string> peers, string groupName)
        {
            string filePath = "groupData.txt";

            try
            {
                // Write the group name to the first line
                File.WriteAllText(filePath, groupName + Environment.NewLine);

                // Write each peer to the file on a new line
                foreach (var peer in peers)
                {
                    File.AppendAllText(filePath, peer + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving group data: {ex.Message}");
            }
        }

        public void LoadGroupData()
        {
            string filePath = "groupData.txt";
            string historyFilePath = "msgHistory.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    // Read all lines from the group data file
                    string[] lines = File.ReadAllLines(filePath);

                    // The first line is the group name
                    groupName = lines[0];

                    // The rest of the lines are the peers
                    peers = lines.Skip(1).ToList();

                    // Set the group name label
                    labelGroupName.Text = groupName;
                }
                else
                {
                    MessageBox.Show("No saved group data found.");
                }

                // Load the message history from msgHistory.txt
                if (File.Exists(historyFilePath))
                {
                    string[] messages = File.ReadAllLines(historyFilePath);
                    foreach (var message in messages)
                    {
                        history.Items.Add(message); // Add each saved message to the ListBox
                        displayedMessages.Add(message); // Track the displayed messages
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading group data or message history: {ex.Message}");
            }
        }

        // Method to print the peer list
        private void PrintPeerList()
        {
            string peerList = string.Join(Environment.NewLine, peers); // Join peers into a single string
            MessageBox.Show($"Peer List:\n{peerList}", "Peers", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Method to connect to all peers and listen for messages
        private void ConnectToPeers()
        {
            foreach (var peer in peers)  // Iterate through all peers
            {
                try
                {
                    // Extract IP and port from the peer string (ip:port)
                    string[] peerInfo = peer.Split(':');
                    string ipAddress = peerInfo[0];
                    int port = int.Parse(peerInfo[1]);

                    // Establish TCP connection to the peer
                    TcpClient peerConnection = new TcpClient(ipAddress, port);
                    peerConnections.Add(peerConnection); // Add the connection to the list

                    LogMessage($"Connected to peer: {peer}");

                    // Start listening for incoming messages from this peer in a background thread
                    Thread peerListenerThread = new Thread(() => ListenForPeerMessages(peerConnection));
                    peerListenerThread.IsBackground = true;
                    peerListenerThread.Start();

                    // Optional: Add a small delay between connections to avoid overload
                    Thread.Sleep(100); // 100ms delay between connection attempts
                }
                catch (Exception ex)
                {
                    LogMessage($"Failed to connect to peer {peer}: {ex.Message}");
                }
            }
        }

        private void ListenForPeerMessages(TcpClient peerConnection)
        {
            try
            {
                NetworkStream stream = peerConnection.GetStream();
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break; // Connection closed

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Update the ListBox directly
                    Invoke(new Action(() =>
                    {
                        if (!displayedMessages.Contains(message))
                        {
                            history.Items.Add($"Peer: {message}");
                            displayedMessages.Add(message);
                        }
                    }));

                    // Optionally save the message to msgHistory.txt
                    SaveMessageHistory($"Peer: {message}");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error while listening for messages from peer: {ex.Message}");
            }
        }

        // Method to log messages (you can display them in a textbox or a log panel)
        private void LogMessage(string message)
        {
            // For now, just print to the console (you could update a TextBox or ListBox)
            MessageBox.Show(message);
        }

        private void cendmsg_Click(object sender, EventArgs e)
        {
            if (peerConnections.Count <= 0)
            {
                MessageBox.Show("No peers connected.");
                return;
            }

            string messageToSend = "#" + messageInput.Text.Trim();
            if (string.IsNullOrEmpty(messageToSend))
            {
                MessageBox.Show("Message cannot be empty.");
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(messageToSend);

            foreach (var connection in peerConnections)
            {
                try
                {
                    if (connection.Connected)
                    {
                        NetworkStream stream = connection.GetStream();
                        stream.Write(data, 0, data.Length);
                        LogMessage($"Message sent to peer: {connection.Client.RemoteEndPoint}");
                        LoadMessageHistory();
                    }
                    else
                    {
                        LogMessage($"Connection is not open to {connection.Client.RemoteEndPoint}");
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Failed to send message to peer: {ex.Message}");
                }
            }

            // Add the message to the local history
            history.Items.Add(name + ": " + messageToSend.TrimStart('#'));

            // Save the message to msgHistory.txt
            SaveMessageHistory(name + ": " + messageToSend.TrimStart('#'));

            // Clear the input field
            messageInput.Clear();
        }

        // Method to save message to msgHistory.txt
        public void SaveMessageHistory(string message)
        {
            string historyFilePath = "msgHistory.txt";

            try
            {
                // Append the message to the file
                File.AppendAllText(historyFilePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving message to history: {ex.Message}");
            }
        }

        public void LoadMessageHistory()
        {
            string historyFilePath = "msgHistory.txt";

            try
            {
                if (File.Exists(historyFilePath))
                {
                    string[] messages = File.ReadAllLines(historyFilePath);

                    foreach (var message in messages)
                    {
                        if (!displayedMessages.Contains(message))
                        {
                            history.Items.Add(message);
                            displayedMessages.Add(message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading message history: {ex.Message}");
            }
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            name = userName.Text;
        }
    }
}

