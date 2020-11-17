using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerEchoLibrary
{
    public class ServerTAP<T> : Server<T> where T : CommunicationProtocol, new()
    {
        public ServerTAP(IPAddress IP, int port) : base(IP, port)
        {
        }

        protected override void AcceptClient()
        {
            while (true)
            {
                TcpClient client = TcpListener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                Task.Run(() => BeginDataTransmission(stream));           
            }
        }
        /// <summary>
        /// Overrided comment.
        /// </summary>
        public override void Start()
        {
            running = true;
            StartListening();
            //transmission starts within the accept function
            AcceptClient();
        }
    }
}
