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
        private static List<User> listUsers = new List<User>();
        private static List<PrivateText> listPT = new List<PrivateText>();
        private static ArrayList listTopics = new ArrayList();

        public Server(int port)
        {
            this.port = port;
        } 

        public void start()
        {
            TcpListener l = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), port);
            l.Start();

            while (true) //Boucle pour accepter chaque client qui se connecte
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
                Console.WriteLine("Receiving messages from Client");
                
                while (true) //Boucle pour traiter chaque message du client
                {
                    Message m = Net.rcvMsg(comm.GetStream());

                    if (m.GetType() == typeof(Communication.Request)) //Si c'est une demande
                    {
                        Request request = (Request)m;
                        if (request.Type == "fetchTopic") //On demande le contenu d'un topic
                        {
                            Console.WriteLine("Fetching the topic " + request.P1);
                            foreach (Topic topic in listTopics)
                            {
                                if (topic.Name.Equals(request.P1))
                                {
                                    Net.sendMsg(comm.GetStream(), topic);
                                }

                            }
                        }
                        if (request.Type == "fetchPT") //On demande les privates messages
                        {
                            Console.WriteLine("Fetching private messages btw " + request.P1 + " and " + request.P2);
                            string chat = "";//var contenant la conversation
                            foreach (PrivateText pt in listPT)
                            {
                                if (pt.Sender.Equals(request.P1) && pt.Receiver.Equals(request.P2)
                                    || pt.Sender.Equals(request.P2) && pt.Receiver.Equals(request.P1)) //Si c'est envoye par le client ou reçu par le client
                                {
                                    chat +=  pt.ToString() + "\r\n";
                                }
                            }
                            Net.sendMsg(comm.GetStream(), new Request(chat));
                        }
                        if (request.Type == "listTopics") //On demande la liste des topics
                        {
                            string allTopics = "";
                            Console.WriteLine("Fetching all topics");
                            foreach(Topic topic in listTopics)
                            {
                                allTopics += "\r\n" + topic.Name;
                            }
                            Net.sendMsg(comm.GetStream(), new Request(allTopics));
                        }
                        if (request.Type == "listUsers") //On demande la liste des users
                        {
                            string allUsers = "";
                            Console.WriteLine("Fetching all users");
                            allUsers += listUsers[0].Username;
                            for(int i = 1; i < listUsers.Count; i++)
                            {
                                allUsers += " " + listUsers[i].Username;
                            }
                            Net.sendMsg(comm.GetStream(), new Request(allUsers));
                        }
                        if (request.Type == "launchTopic") //Creation ou adherance a un topic
                        {
                            bool inList = false;
                            foreach (Topic topic in listTopics)
                            {
                                if (topic.Name.Equals(request.P1))
                                {
                                    Net.sendMsg(comm.GetStream(), topic);
                                    inList = true;
                                }
                            }
                            if (!inList) //Si le topic n'existe pas encore
                            {
                                Topic newTopic = new Topic(request.P1);
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
                                if (user.Username.Equals(request.P1) && user.Password.Equals(request.P1))
                                {
                                    connected = true;
                                    Console.WriteLine("Connecting to account " + request.P1);
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
                            bool exist = false;
                            foreach (User user in listUsers) //On verifie que le username n'est pas deja pris
                            {
                                if (user.Username.Equals(request.P1)) //Si l'utilisateur existe deja
                                {
                                    exist = true;
                                    Net.sendMsg(comm.GetStream(), new Error("This username is already taken"));
                                }
                            }
                            if (!exist) //Si le username est libre
                            {
                                User newUser = new User(request.P1, request.P2);
                                listUsers.Add(newUser);
                                Console.WriteLine("User " + request.P1 + " successfully added");
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
                    else if (m.GetType() == typeof(Communication.PrivateText)) //Si c'est un private message
                    {
                        Console.WriteLine("Text received");
                        PrivateText newPT = (PrivateText)m;
                        listPT.Add(newPT);
                    }
                }

            }
        }
        
        
    }
}
