using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerEchoLibrary
{
    public class LoginServerProtocol : CommunicationProtocol
    {
        LoginProtocolState protocolState = LoginProtocolState.LISTEN;
        Dictionary<Request, Response> responses;
        Dictionary<string, int> opcodes;
        LoginStatus login;
        public LoginServerProtocol() : base()
        {
            responses = new Dictionary<Request, Response>();
            opcodes = new Dictionary<string, int>();

            opcodes["LOGIN"] = 0;
            opcodes["PWD"] = 1;
            responses[new Request(opcodes["LOGIN"], "LOGIN", null)] = new Response(0, 
            (args) =>
            {
                return "PWD\n";
            }, 
            null,
            (args) => 
            {
                if (protocolState == LoginProtocolState.LISTEN)
                {
                    login = new LoginStatus();
                    login.GivenLogin = args.Trim(new char[] { '\r', '\n', '\0' });
                    protocolState = LoginProtocolState.LOGIN_RECIEVED;
                }
            });

            responses[new Request(opcodes["PWD"], "PWD", null)] = new Response(0,
            (args) =>
            {
                if (login.Status == LoginStatus.StatusCode.invalid_pwd)
                    return "INV_PWD";
                if (login.Status == LoginStatus.StatusCode.invalid_un)
                    return "INV_UN";
                if (login.Status == LoginStatus.StatusCode.logged)
                    return "LOGGED";
                return "UNK";

            },
            null,
            (args) =>
            {
                if (protocolState == LoginProtocolState.LOGIN_RECIEVED)
                {
                    login.GivenPassword = args.Trim(new char[] { '\r', '\n', '\0' });
                    login.Login();
                    if (login.Status == LoginStatus.StatusCode.logged)
                    {
                        protocolState = LoginProtocolState.AUTHENTICATED;
                    }
                    else
                    {
                        protocolState = LoginProtocolState.LISTEN;
                    }
                }
            });

        }
        public override string GenerateResponse(string message)
        {
            string mt = message.Trim(new char[] { '\r','\n','\0'});
            if (mt == "")
                return "";
            string[] tokens = message.Split(new char[] { ' ' });
            string opcode = tokens[0].Trim(new char[] { '\r', '\n', '\0' });
            string args;
            if (tokens.Length > 1) args = tokens[1]; else args = null;
            Request request = new Request(opcodes[opcode], opcode, args);
            Response response = responses[request];
            response.Action(args);
            return response.GenerateResponse(args);
        }

        public override string GetName()
        {
            return "LoginProt";
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
