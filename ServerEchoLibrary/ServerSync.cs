﻿using System;
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
    public class ServerSync<T> : Server<T> where T : CommunicationProtocol, new()
    {
        public ServerSync(IPAddress IP, int port) : base(IP, port)
        {

        }
        protected override void AcceptClient()
        {
            TcpClient tcpClient = TcpListener.AcceptTcpClient();
            byte[] buffer = new byte[Buffer_size];
            NetworkStream Stream = tcpClient.GetStream();
            BeginDataTransmission(Stream);
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
