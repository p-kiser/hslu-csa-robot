using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using System.IO;
using System.Net.Sockets;

namespace RobotCtrlTest
{
    [TestClass]
    public class SocketCLITest
    {
        Mock<RobotCtrl.Command> command;

        [TestInitialize]
        void setup()
        {
            command = new Mock<RobotCtrl.Command>();
        }

        [TestMethod]
        public void StartServerAndConnect()
        {
            // test start connection
//            TcpClient client = new TcpClient("localhost", 8080);
        }

        [TestMethod]
        public void sendPingCommand()
        {

        }
    }
}
