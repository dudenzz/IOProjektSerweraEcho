using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerEchoLibrary
{
    /// <summary>
    /// This class implements the most basic TCP Server of the Echo Type.
    /// </summary>
    public class ServerSync : Server
    {
        public ServerSync(IPAddress IP, int port, ICommunicationProtocol protocol) : base(IP, port, protocol)
        {

        }
        protected override void AcceptClient()
        {
            TcpClient tcpClient = TcpListener.AcceptTcpClient();
            byte[] buffer = new byte[Buffer_size];
            NetworkStream Stream = tcpClient.GetStream();
            BeginDataTransmission(Stream);
        }
        protected override void BeginDataTransmission(NetworkStream stream)
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                try
                {
                    int message_size = stream.Read(buffer, 0, Buffer_size);
                    stream.Write(buffer, 0, message_size);
                }
                catch (IOException e)
                {
                    break;
                }
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
