using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerEchoLibrary
{
    public class EchoServerProtocol : CommunicationProtocol
    {
        Dictionary<Request, Response> responses;
        Dictionary<string, int> opcodes;
        public EchoServerProtocol() : base()
        {
            responses = new Dictionary<Request, Response>();
            opcodes = new Dictionary<string, int>();

            opcodes["ANY"] = 0;
            responses[new Request(opcodes["ANY"], "ANY", null)] = new Response(0,
            (args) =>
            {
                return args;
            },
            null,
            (args) =>
            {

            });
        }
        public override string GenerateResponse(string message)
        {

            Request request = new Request(opcodes["ANY"], "ANY", null);
            Response response = responses[request];
            response.Action(message);
            return response.GenerateResponse(message);
        }

        public override string GetName()
        {
            return "EchoProt";
        }

        public override string GetAllMessages()
        {
            return null;
        }

        public override string GetAllResponses()
        {
            return null;
        }
    }
}
