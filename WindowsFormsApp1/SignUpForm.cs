﻿using System;
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
                Net.sendMsg(comm.GetStream(), new Request("signUp", usernameTextBox.Text, passwordTextBox.Text));
                Communication.Message m = Net.rcvMsg(comm.GetStream());
                if (m.GetType() == typeof(Communication.User))
                {
                    Program.currentUser = (User)m;
                    Program.connected = true;
                    this.Close();
                }
                else if (m.GetType() == typeof(Communication.Error))
                {
                    Error error = (Error)m;
                    errorLabel.Text = error.ToString();
                }
            }
            else
            {
                errorLabel.Text = "Please enter credentials";
            }

        }
    }
}
