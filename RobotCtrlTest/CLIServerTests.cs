using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotCtrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCtrl.Tests
{
    [TestClass()]
    public class CLIServerTests
    {
        [TestMethod()]
        public void CLIServerTest()
        {
            Mock<Command> cmd = new Mock<Command>();
            cmd.Setup(c => c.addQueue(It.IsAny<String>()))
                .Callback((string s) => { Console.WriteLine("addQueue: " + s); });

            CLIServer server = new CLIServer(cmd.Object);
            server.listen(true);

        }
    }
}