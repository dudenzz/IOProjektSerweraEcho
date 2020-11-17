using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerEchoLibrary
{
    public abstract class CommunicationProtocol
    {
        public CommunicationProtocol()
        {

        }
        public abstract string GenerateResponse(string message);
        public abstract string GetName();
        public abstract string GetAllMessages();
        public abstract string GetAllResponses();
    }
}
