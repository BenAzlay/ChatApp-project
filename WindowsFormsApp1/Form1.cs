using System;
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
    public partial class Form1 : Form
    {
        
        private TcpClient comm;
        public Form1(string h, int p)
        {
            InitializeComponent();

            // connect to server
            comm = new TcpClient(h, p);

            new Thread(this.listTopics).Start();
            new Thread(this.fetchTopic).Start();
        }

        private void fetchTopic()//Fetch le contenu du topic selectionne
        {
            while (true)
            {
                Thread.Sleep(1000);
                
                if (Program.gotTopic) //Sinon on ne peut pas demander de topic
                {
                     Net.sendMsg(comm.GetStream(), new Request("fetchTopic", Program.currentTopic.Name)); //On demande le contenu du topic
                     chatTextBox.Text = ((Topic)Net.rcvMsg(comm.GetStream())).Content; //On place le contenu dans la TextBox dediee
                }
                
            }
        }

        private void listTopics() //Fetch la liste des topics
        {
            while (true)
            {
                Thread.Sleep(1000);
               
                Net.sendMsg(comm.GetStream(), new Request("listTopics"));
                listTopicsTextBox.Text = "List of topics" + ((Request)Net.rcvMsg(comm.GetStream())).ToString();
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            if (Program.connected && Program.gotTopic && newMessageTextBox.Text != "")
            {
                Net.sendMsg(comm.GetStream(), new Text(Program.currentUser, newMessageTextBox.Text, Program.currentTopic.Name));
                //chatTextBox.Text = ((Topic)Net.rcvMsg(comm.GetStream())).Content;
                newMessageTextBox.Text = "";

            }
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm("127.0.0.1", 8976);
            signUpForm.ShowDialog();
            
            connectionLabel.Text = Program.currentUser.ToString();
        }
        private void signIn_Click(object sender, EventArgs e)
        {
            SignInForm signInForm = new SignInForm("127.0.0.1", 8976);
            signInForm.ShowDialog();

            connectionLabel.Text = Program.currentUser.ToString();
        }
        private void privateTextsButton_Click(object sender, EventArgs e)
        {
            if (Program.connected)
            {
                PrivateTextsForm privateTextsForm = new PrivateTextsForm("127.0.0.1", 8976);
                privateTextsForm.ShowDialog();
            }
            
        }
        private void newTopic_Click(object sender, EventArgs e)
        {
            TopicForm topicForm = new TopicForm("127.0.0.1", 8976);
            topicForm.ShowDialog();

            topicLabel.Text = Program.currentTopic.ToString();
        }
    }
}
