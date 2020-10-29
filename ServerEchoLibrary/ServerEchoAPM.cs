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
    public class ServerEchoAPM : ServerEcho
    {
        public delegate void TransmissionDataDelegate(NetworkStream stream);
        public delegate int IntegerOperation(int argument);

        public int Factorial(int n)
        {
            int t = 1;
            for (int i = 0; i < n; i++)
            {
                t *= i + 1;
            }
            return t;
        }
        public int Edges(int n)
        {
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                t += i + 1;
            }
            return t;
        }
        public ServerEchoAPM(IPAddress IP, int port) : base(IP, port)
        {
        }
        protected override void AcceptClient()
        {
            while (true)
            {
                TcpClient tcpClient = TcpListener.AcceptTcpClient();
                NetworkStream Stream = tcpClient.GetStream();
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);



                ////////callback style
                transmissionDelegate.BeginInvoke(Stream, TransmissionCallback, tcpClient);

                //async result style
                //IntegerOperation funkcjaSilni = new IntegerOperation(Factorial);
                //var id1 = funkcjaSilni.BeginInvoke(5, null, null);
                //var id2 = funkcjaSilni.BeginInvoke(10, null, null);
                ////wątek główny
                //id1.AsyncWaitHandle.WaitOne();
                //id2.AsyncWaitHandle.WaitOne();


                //IAsyncResult result2 = transmissionDelegate.BeginInvoke(Stream, null, null);
                //IAsyncResult result3 = transmissionDelegate.BeginInvoke(Stream, null, null);

                //operacje w wątku głównym

                //while (!result.IsCompleted) ;   
                //synchronizacja
            }
        }


        private void TransmissionCallback(IAsyncResult ar)
        {


            TcpClient tcpClient = (TcpClient)ar.AsyncState;
            tcpClient.Close();
        }
        protected override void BeginDataTransmission(NetworkStream stream)
        {
            stream.ReadTimeout = 10000;
            byte[] buffer = new byte[Buffer_size];
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
        public override void Start()
        {
            running = true;
            StartListening();
            //transmission starts within the accept function
            AcceptClient();
        }

    }
}
