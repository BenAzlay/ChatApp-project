using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace ClientGUI
{
    public partial class PrivateTextsForm : Form
    {
        private TcpClient comm;
        bool check = false;
        
        public PrivateTextsForm(string h, int p)
        {
            InitializeComponent();

            // connect to server
            comm = new TcpClient(h, p);

            this.getListUsers();
            new Thread(this.fetchPT).Start();


        }

        private void fetchPT() //Fetch le contenu du chat avec le user selectionne
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (check)
                {
                    Net.sendMsg(comm.GetStream(), new Request("fetchPT", Program.currentUser.Username, checkboxUsers.CheckedItems[0].ToString()));
                    chatTextBox.Text = ((Request)Net.rcvMsg(comm.GetStream())).Type; //On place le contenu dans la TextBox dediee
                }

            }
        }

        private void getListUsers() //Pour que chaque user de la liste du server soit dans la checkboxlist
        {
            Net.sendMsg(comm.GetStream(), new Request("listUsers"));
            string[] listUsers = ((Request)Net.rcvMsg(comm.GetStream())).ToString().Split(' ');
            //checkboxUsers.Items.Clear();
            foreach (string user in listUsers)
            {
                checkboxUsers.Items.Add(user);
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (sendTextBox.Text != "")
            {
                Net.sendMsg(comm.GetStream(), new PrivateText(Program.currentUser.Username, checkboxUsers.CheckedItems[0].ToString(), sendTextBox.Text));
                //chatTextBox.Text = ((Topic)Net.rcvMsg(comm.GetStream())).Content;
                sendTextBox.Text = "";

            }
        }
        private void checkboxUsers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkboxUsers.Items.Count; ++ix)
            {
                if (ix != e.Index)
                {
                    checkboxUsers.SetItemChecked(ix, false);
                }
            }
            check = true;
        }
        /*
        private void checkboxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //receiver = checkboxUsers.CheckedItems[0].ToString();
        }*/
    }
}
