using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerLibrary
{
    class Message
    {
        string messageText;
        bool messageRead;
        DateTime time;
        public string MessageText { get => messageText; set => messageText = value; }
        public bool MessageRead { get => messageRead; set => messageRead = value; }
        public DateTime Time { get => time; set => time = value; }

        public Message(string message)
        {
            time = DateTime.Now;
            MessageText = message;
        }
        public string ReadMessageAndConfirm()
        {
            MessageRead = true;
            StringBuilder sb = new StringBuilder(time.ToString());
            sb.Append(' ');
            sb.Append(MessageText);
            return sb.ToString();
        }
    }
}