using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace Communication
{
    public interface Message //Permet d'echanger n'importe quelle classe qui l'implemente
    {
        string ToString();
    }

    [Serializable]
    public class Request : Message
    {
        private string type, name;
        public Request(string type)
        {
            this.type = type;
        }

        public Request(string type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public string Type
        {
            get { return type; }
        }
        public string Name
        {
            get { return name; }
        }

        public override string ToString()
        {
            return type;
        }
    }

    [Serializable]
    public class User : Message
    {
        private string username, password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string Username
        {
            get { return username; }
        }
        public string Password
        {
            get { return password; }
        }
        public override string ToString()
        {
            return "Username: " + username + "\nPassword: " + password;
        }
    }

    [Serializable]
    public class Text : Message
    {
        private string content, topic;
        private User sender;

        public Text(User sender, string content, string topic)
        {
            this.sender = sender;
            this.content = content;
            this.topic = topic;
        }
        public User Sender
        {
            get { return sender; }
        }
        public string Content
        {
            get { return content; }
        }
        public string Topic
        {
            get { return topic; }
        }
        public override string ToString()
        {
            return sender.Username + ": " + content;
        }
    }

    [Serializable]
    public class Topic : Message
    {
        private string name, content;
        public Topic(string name, string content)
        {
            this.name = name;
            this.content = content;
        }

        public string Name
        {
            get { return name; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
