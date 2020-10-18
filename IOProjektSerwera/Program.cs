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
            ServerEcho server = new ServerEcho(IPAddress.Parse("127.0.0.1"), 3000);
            try
            {
                server.Port = -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            server.Start();
        }
    }
}
