using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotCtrl;
using System.Threading;

namespace RobotCtrlTest
{
    [TestClass]
    public class FileMonitorTest
    {
        [TestMethod]
        public void openDumpAndCloseFile()
        {
            string path = System.IO.Path.GetTempFileName();
            FileMonitor monitor = new FileMonitor(path);

            Assert.AreEqual("", monitor.dump());
        }

        [TestMethod]
        public void startAndStop()
        {
            bool positionreceived = false;
            Mock<Command> cmd = new Mock<Command>();
            cmd.Setup(m => m.getPosition())
                .Callback(() =>
                {
                    positionreceived = true;
                })
                .Returns(new PositionInfo(0, 0, 45));

            string path = System.IO.Path.GetTempFileName();
            FileMonitor monitor = new FileMonitor(path);

            monitor.start(cmd.Object);

            while(!positionreceived)
            {
                Thread.Sleep(100);
            }
            Thread.Sleep(100);

            monitor.stop();

            Assert.AreNotEqual("", monitor.dump());
            Console.WriteLine(monitor.dump());
        }
    }
}
