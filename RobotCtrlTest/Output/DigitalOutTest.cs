using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RobotCtrl;
using Moq;

namespace RobotCtrlTest.Output
{
    /// <summary>
    /// Summary description for DigitalOutTest
    /// </summary>
    [TestClass]
    public class DigitalOutTest
    {
        DigitalOut digitalOut;
        Mock<IOPort> ioMock;
        int port;

        [TestInitialize]
        public void setup()
        {
            ioMock = new Mock<IOPort>();
            IOPort.set(ioMock.Object);
            port = 0xf0;
            digitalOut = new DigitalOut(port);

            // mocking Led backend
            int portvalue = 0x00;
            ioMock.Setup(m => m._read(port))
                .Returns(portvalue);
            ioMock.Setup(m => m._write(port, It.IsAny<int>()))
                .Callback((int p, int v) => portvalue = v);
        }

        [TestMethod]
        public void TestReadAndWriteValue()
        {
            Assert.IsFalse(digitalOut[(int)Leds.Led1]);
            Assert.IsFalse(digitalOut[(int)Leds.Led2]);
            Assert.IsFalse(digitalOut[(int)Leds.Led3]);
            Assert.IsFalse(digitalOut[(int)Leds.Led4]);

            digitalOut[(int)Leds.Led2] = true;
            digitalOut[(int)Leds.Led1] = true;
            digitalOut[(int)Leds.Led4] = true;

            Assert.IsTrue(digitalOut[(int)Leds.Led1]);
            Assert.IsTrue(digitalOut[(int)Leds.Led2]);
            Assert.IsFalse(digitalOut[(int)Leds.Led3]);
            Assert.IsTrue(digitalOut[(int)Leds.Led4]);

            ioMock.Verify(m => m._write(port, 0x03));
        }

        [TestMethod]
        public void TestEventHandleCalledOnChange()
        {
            int eventDispatched = 0;
            digitalOut.Data = 0x00;
            digitalOut.DigitalOutputChanged += (o, a) => eventDispatched++;

            digitalOut[(int)Leds.Led2] = true;
            digitalOut[(int)Leds.Led2] = false;

            Assert.AreEqual(2, eventDispatched);

            digitalOut[(int)Leds.Led2] = false;
            digitalOut[(int)Leds.Led2] = false;

            Assert.AreEqual(2, eventDispatched);
        }
    }
}
