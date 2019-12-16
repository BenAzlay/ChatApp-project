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

                    if (m.GetType() == typeof(Communication.Request)) //Si c'est une demande
                    {
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
                        if (request.Type == "listTopics") //On demande le contenu d'un topic
                        {
                            string allTopics = "";
                            Console.WriteLine("Fetching all topics");
                            foreach(Topic topic in listTopics)
                            {
                                allTopics += "\r\n" + topic.Name;
                            }
                            Net.sendMsg(comm.GetStream(), new Request(allTopics));
                        }
                        if (request.Type == "launchTopic") //Creation ou adherance a un topic
                        {
                            bool inList = false;
                            foreach (Topic topic in listTopics)
                            {
                                if (topic.Name.Equals(request.Name))
                                {
                                    Net.sendMsg(comm.GetStream(), topic);
                                    inList = true;
                                }
                            }
                            if (!inList) //Si le topic n'existe pas encore
                            {
                                Topic newTopic = new Topic(request.Name);
                                listTopics.Add(newTopic);
                                Console.WriteLine("Topic successfully added");
                                Net.sendMsg(comm.GetStream(), newTopic);
                            }
                        }
                        if (request.Type == "signIn")
                        {
                            bool connected = false;
                            foreach (User user in listUsers)
                            {
                                if (user.Username.Equals(request.Name) && user.Password.Equals(request.Pwd))
                                {
                                    connected = true;
                                    Console.WriteLine("Connecting to account " + request.Name);
                                    Net.sendMsg(comm.GetStream(), user);
                                }

                            }
                            if (!connected)
                            {
                                Net.sendMsg(comm.GetStream(), new Error("Wrong username or password"));
                            }
                        }

                        if (request.Type == "signUp")
                        {
                            bool connected = false;
                            foreach (User user in listUsers)
                            {
                                if (user.Username.Equals(request.Name) && user.Password.Equals(request.Pwd)) //Si l'utilisateur existe deja
                                {
                                    connected = true;
                                    Console.WriteLine("Connecting to account " + request.Name);
                                    Net.sendMsg(comm.GetStream(), new Error("This username is already taken")); //On connecte au compte
                                }
                            }
                            if (!connected) //Si l'utilisateur n'a pas ete trouvé dans la liste
                            {
                                User newUser = new User(request.Name, request.Pwd);
                                listUsers.Add(newUser);
                                Console.WriteLine("User " + request.Name + " successfully added");
                                Net.sendMsg(comm.GetStream(), newUser);
                            }
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
                }

            }
        }
        
        
    }
}
