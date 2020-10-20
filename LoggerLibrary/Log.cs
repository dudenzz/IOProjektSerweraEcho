using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggerLibrary
{
    public class Log
    {
        List<Message> messages;

        internal List<Message> Messages { get => messages; set => messages = value; }

        public string ReadFirstUnreadMessage()
        {
            foreach(var Message in Messages)
            {
                if (!Message.MessageRead)
                    return Message.ReadMessageAndConfirm();
            }
            return null;
        }
    }
}
