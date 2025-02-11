using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class GroupChatSetup : Form
    {
        public GroupChatSetup(List<string> peers)
        {
            InitializeComponent();
            foreach (var peer in peers)
            {
                listBoxPeers.Items.Add(peer);
            }
        }

        private void textBoxGroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxPeers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GroupChatSetup_Load(object sender, EventArgs e)
        {

        }

        //private void btnCreateGroup_Click(object sender, EventArgs e)
        //{
        //    // Get the selected peers from the ListBox
        //    var selectedPeers = listBoxPeers.SelectedItems.Cast<string>().ToList();

        //    if (selectedPeers.Count == 0)
        //    {
        //        MessageBox.Show("Please select at least one peer to create a group.");
        //        return;
        //    }

        //    // Get the group name from the text box
        //    string groupName = textBoxGroupName.Text.Trim();

        //    if (string.IsNullOrEmpty(groupName))
        //    {
        //        MessageBox.Show("Please enter a group name.");
        //        return;
        //    }

        //    // Now you can create the group with the selected peers and the group name
        //    // You can send the group name and the selected peers to the server or handle group creation logic here
        //    MessageBox.Show($"Group '{groupName}' created with peers: {string.Join(", ", selectedPeers)}");

        //    // Handle further group creation logic, such as connecting to the selected peers
        //}
    }

}
