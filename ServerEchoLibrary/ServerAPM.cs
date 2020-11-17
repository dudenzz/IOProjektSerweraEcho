using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerEchoLibrary
{
    public class ServerAPM : Server
    {
        public delegate void TransmissionDataDelegate(NetworkStream stream);
        public ServerAPM(IPAddress IP, int port, ICommunicationProtocol protocol) : base(IP, port, protocol)
        {
        }
        protected override void AcceptClient()
        {
            while (true)
            {
                TcpClient tcpClient = TcpListener.AcceptTcpClient();
                NetworkStream stream = tcpClient.GetStream();
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);
                transmissionDelegate.BeginInvoke(stream, TransmissionCallback, tcpClient);

            }
        }

        private void TransmissionCallback(IAsyncResult ar)
        {
            TcpClient tcpClient = (TcpClient)ar.AsyncState;
            tcpClient.Close();
        }
        protected override void BeginDataTransmission(NetworkStream stream)
        {
            byte[] buffer = new byte[Buffer_size];
            while (true)
            {
                try
                {
                    buffer = new byte[Buffer_size];
                    int message_size = stream.Read(buffer, 0, Buffer_size);
                    string message = ASCIIEncoding.UTF8.GetString(buffer);
                    string response = Protocol.GenerateResponse(message);
                    buffer = ASCIIEncoding.UTF8.GetBytes(response);
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch (IOException e)
                {
                    break;
                }
            }
        }
        public override void Start()
        {
            running = true;
            StartListening();
            //transmission starts within the accept function
            AcceptClient();
        }

    }
}
