using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ServerEchoLibrary
{
    class LoginServer : Server
    {
        public LoginServer(IPAddress IP, int port) : base(IP, port)
        {

        }
    }
}
