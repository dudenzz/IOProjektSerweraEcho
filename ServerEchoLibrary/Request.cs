namespace ServerEchoLibrary
{
    public class Request
    {
        public int Code { get; set; }
        public string Opcode { get; set; }
        public string Args { get; set; }

        public Request(int code, string opcode, string args)
        {
            Code = code;
            Opcode = opcode;
            Args = args;
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
            return Opcode;
        }
    }
}