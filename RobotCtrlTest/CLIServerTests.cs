using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotCtrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace RobotCtrl.Tests
{
    [TestClass()]
    public class CLIServerTests
    {
        [TestMethod()]
        public void CLIServerTest()
        {
            Mock<Command> cmd = new Mock<Command>();
            Mock<Monitor> mon = new Mock<Monitor>();
            cmd.Setup(c => c.addQueue(It.IsAny<String>()))
                .Callback((string s) => { Console.WriteLine("addQueue: " + s); });
            cmd.Setup(c => c.getHelp())
                .Returns("help1\nhelp2");

            (new Thread(() =>
            {
                CLIServer server = new CLIServer(cmd.Object, mon.Object);
                server.listen(false);
            })).Start();

            Thread.Sleep(1000);

            TcpClient client = new TcpClient("localhost", 8080);
            StreamWriter write = new StreamWriter(client.GetStream());
            StreamReader reader = new StreamReader(client.GetStream());

            Assert.AreEqual("Successfully Connected", reader.ReadLine());

            write.WriteLine("help");
            write.Flush();

            string line;
            string lines = "";
            while ((line = reader.ReadLine()) != "EOS")
            {
                lines += line;
            }
            client.Close();

//            Assert.AreEqual("help1\nhelp2", lines);
        }
    }
}