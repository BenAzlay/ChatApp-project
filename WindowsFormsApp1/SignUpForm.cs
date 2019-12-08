using System;
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
    public partial class SignUpForm : Form
    {
        private TcpClient comm;

        public SignUpForm(string h, int p)
        {
            InitializeComponent();

            // connect to server
            comm = new TcpClient(h, p);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(usernameTextBox.Text != "" && passwordTextBox.Text != "")
            {
                Net.sendMsg(comm.GetStream(), new User(usernameTextBox.Text, passwordTextBox.Text));
                Program.currentUser = (User)Net.rcvMsg(comm.GetStream());
                Program.connected = true;
                this.Close();
            }

        }
    }
}
