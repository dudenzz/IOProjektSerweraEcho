using ServerEchoLibrary;
using System;
using System.Net;

namespace IOProjektSerweraEcho
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerEcho server = new ServerEcho(IPAddress.Parse("127.0.0.1"), 3000);
            server.Start();
        }
    }
}
