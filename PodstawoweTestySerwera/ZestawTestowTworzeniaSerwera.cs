using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerEchoLibrary;

namespace PodstawoweTestySerwera
{
    [TestClass]
    public class ZestawTestowTworzeniaSerwera
    {
        [TestMethod]
        public void TestowanieBlednegoNumeruPortu()
        {
            try
            {
                Server<LoginServerProtocol> server = new ServerTAP<LoginServerProtocol>(IPAddress.Parse("127.0.0.1"), 80);
                server.Start();
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }
        [TestMethod]
        public void TestowanieBlednegoAdresuIP()
        {
            try
            {
                Server<LoginServerProtocol> server = new ServerTAP<LoginServerProtocol>(IPAddress.Parse("127.0.0"), 3000);
                server.Start();
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }
    }
}
