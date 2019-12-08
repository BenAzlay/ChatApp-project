using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;

namespace ClientGUI
{
    public partial class TopicForm : Form
    {
        private TcpClient comm;
        public TopicForm(string h, int p)
        {
            InitializeComponent();

            // connect to server
            comm = new TcpClient(h, p);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            if(label1.Text != "")
            {
                Net.sendMsg(comm.GetStream(), new Topic(nameTextBox.Text, ""));
                Program.currentTopic = (Topic)Net.rcvMsg(comm.GetStream());
                Program.gotTopic = true;
                this.Close();
            }
        }
    }
}
