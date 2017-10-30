using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RobotCtrl;
using Moq;
using System.Threading;

namespace RobotCtrlTest.Input
{
    /// <summary>
    /// Summary description for DigitalInTest
    /// </summary>
    [TestClass]
    public class DigitalInTest
    {
        DigitalIn digitalIn;
        Mock<IOPort> ioMock;
        int port;

        [TestInitialize]
        public void setup()
        {
            ioMock = new Mock<IOPort>();
            port = 0xf0;

            IOPort.set(ioMock.Object);
            digitalIn = new DigitalIn(port);
        }

        [TestCleanup]
        public void clear()
        {
            digitalIn.Dispose();
        }

        [TestMethod]
        public void TestReadFromInput()
        {
            ioMock.Setup(m => m._read(0xf0))
                .Returns(0x06);

            Assert.IsFalse(digitalIn[(int)Switches.Switch1]);
            Assert.IsTrue(digitalIn[(int)Switches.Switch2]);
            Assert.IsTrue(digitalIn[(int)Switches.Switch3]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch4]);
        }

        [TestMethod]
        public void TestReadMultibleTimesFromInput()
        {
            ioMock.Setup(m => m._read(0xf0))
                .Returns(0x06);

            Assert.IsFalse(digitalIn[(int)Switches.Switch1]);
            Assert.IsTrue(digitalIn[(int)Switches.Switch2]);
            Assert.IsTrue(digitalIn[(int)Switches.Switch3]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch4]);

            ioMock.Setup(m => m._read(0xf0))
                .Returns(0x08);

            Assert.IsFalse(digitalIn[(int)Switches.Switch1]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch2]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch3]);
            Assert.IsTrue(digitalIn[(int)Switches.Switch4]);
        }

        [TestMethod]
        public void TestChangeListener()
        {
            bool eventDispatched = false;
            ioMock.Setup(m => m._read(0xf0))
                .Returns(0x06);

            digitalIn.DigitalInChanged += (o, e) => eventDispatched = true;

            ioMock.Setup(m => m._read(0xf0))
                .Returns(0x08);
            
            Thread.Sleep(60);

            Assert.IsTrue(eventDispatched);

            Assert.IsFalse(digitalIn[(int)Switches.Switch1]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch2]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch3]);
            Assert.IsTrue(digitalIn[(int)Switches.Switch4]);

            eventDispatched = false;
            ioMock.Setup(m => m._read(0xf0))
                .Returns(0x03);

            Thread.Sleep(60);
            Assert.IsTrue(eventDispatched);

            Assert.IsTrue(digitalIn[(int)Switches.Switch1]);
            Assert.IsTrue(digitalIn[(int)Switches.Switch2]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch3]);
            Assert.IsFalse(digitalIn[(int)Switches.Switch4]);
        }
    }
}
