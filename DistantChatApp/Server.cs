using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Communication;
using System.Collections;

namespace DistantChatApp
{
    public class Server
    {
        private int port;
        private static ArrayList listUsers = new ArrayList();
        private static ArrayList listTopics = new ArrayList();

        public Server(int port)
        {
            this.port = port;
        } 

        public void start()
        {
            TcpListener l = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), port);
            l.Start();

            while (true)
            {
                TcpClient comm = l.AcceptTcpClient();
                Console.WriteLine("Connection established @" + comm);
               
                new Thread(new Receiver(comm).treatMessage).Start();

            }
        }

        class Receiver
        {
            private TcpClient comm;

            public Receiver(TcpClient s)
            {
                comm = s;
            }

            public void treatMessage()
            {
                Console.WriteLine("Receiving messages");
                
                while (true)
                {
                    Message m = Net.rcvMsg(comm.GetStream());
                    Console.WriteLine(m.GetType());

                    if(m.GetType() == typeof(Communication.User)) //Si le message est un User
                    {
                        User newUser = (User)m;
                        bool inList = false;
                        foreach (User user in listUsers)
                        {
                            if (user.Username.Equals(newUser.Username) && user.Password.Equals(newUser.Password)) //Si l'utilisateur existe deja
                            {
                                Net.sendMsg(comm.GetStream(), user); //On connecte au compte
                                inList = true;
                            }
                        }
                        if (!inList) //Si l'utilisateur n'a pas ete trouvé dans la liste
                        {
                            listUsers.Add(newUser);
                            Console.WriteLine("User successfully added");
                            Net.sendMsg(comm.GetStream(), newUser);
                        }
                        //Afficher la liste des utilisateurs
                        foreach (User user in listUsers)
                        {
                            Console.WriteLine("Username: " + user.Username + "\nPassword: " + user.Password);
                        }
                    }

                    else if (m.GetType() == typeof(Communication.Topic)) //Si c'est un topic (nouveau ou non)
                    {
                        Topic newTopic = (Topic)m;
                        bool inList = false;
                        foreach (Topic topic in listTopics)
                        {
                            if (topic.Name.Equals(newTopic.Name))
                            {
                                Net.sendMsg(comm.GetStream(), topic);
                                inList = true;
                            }
                        }
                        if (!inList) //Si l'utilisateur n'a pas ete trouvé dans la liste
                        {
                            listTopics.Add(newTopic);
                            Console.WriteLine("Topic successfully added");
                            Net.sendMsg(comm.GetStream(), newTopic);
                        }
                        //Afficher la liste des Topics
                        foreach (Topic topic in listTopics)
                        {
                            Console.WriteLine("Topic name: " + topic.Name);
                        }
                    }

                    else if (m.GetType() == typeof(Communication.Text)) //Si c'est un message pour le chat
                    {
                        Console.WriteLine("Text received");
                        Text newText = (Text)m;
                        foreach (Topic topic in listTopics)
                        {
                            if (topic.Name.Equals(newText.Topic))
                            {
                                topic.Content += newText.ToString() + "\r\n";
                                Console.WriteLine("Text successfully added to topic " + topic.Name);
                                //Net.sendMsg(comm.GetStream(), topic);
                            }
                            
                        } 
                    }
                    else if (m.GetType() == typeof(Communication.Request)) //Si c'est une demande
                    {    
                        Console.WriteLine("Text received");
                        Request request = (Request)m;
                        if (request.Type == "fetchTopic") //On demande le contenu d'un topic
                        {
                            Console.WriteLine("Fetching the topic " + request.Name);
                            foreach (Topic topic in listTopics)
                            {
                                if (topic.Name.Equals(request.Name))
                                {
                                    Net.sendMsg(comm.GetStream(), topic);
                                }

                            }
                        }
                        
                    }
                }

            }
        }
        
        
    }
}
