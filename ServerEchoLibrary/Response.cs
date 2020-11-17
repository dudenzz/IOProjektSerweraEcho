using System;

namespace ServerEchoLibrary
{
    public class Response
    {
        public int Code { get; set; }
        public string Args { get; set; }
        public Action<string> Action;
        public Func<string, string> GenerateResponse;
        public Response(int code, Func<string, string> generateResponse, string args, Action<string> action)
        {
            Code = code;
            GenerateResponse = generateResponse;
            Args = args;
            Action = action;
        }
        public override int GetHashCode()
        {
            return Code;
        }
        public override bool Equals(object obj)
        {
            return Code == ((Request)obj).Code;
        }
        public override string ToString()
        {
            return GenerateResponse(Args);
        }
    }
}