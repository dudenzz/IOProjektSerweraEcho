using System;
using System.Net;
using ServerEchoLibrary;
namespace IOProjektSerweraEcho
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
