using ServerEchoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace IOProjektSerwera
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new ServerAPM(IPAddress.Parse("127.0.0.1"), 3000, new LoginServerProtocol());
            server.Start();
        }
    }
}
