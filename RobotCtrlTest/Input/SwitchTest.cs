using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RobotCtrl;
using Moq;

namespace RobotCtrlTest.Input
{
    [TestClass]
    public class SwitchTest
    {
        private int eventSwi1Dispatched = 0,
                    eventSwi2Dispatched = 0;
        private Mock<DigitalIn> diMock;
        Switch swi1, swi2;

        [TestInitialize]
        public void Setup()
        {
            eventSwi1Dispatched = 0;
            eventSwi2Dispatched = 0;

            diMock = new Mock<DigitalIn>(Constants.IOConsoleSWITCH);

            swi1 = new Switch(diMock.Object, Switches.Switch1);
            swi1.SwitchStateChanged += (o, e) => eventSwi1Dispatched++;
            swi2 = new Switch(diMock.Object, Switches.Switch2);
            swi2.SwitchStateChanged += (o, e) => eventSwi2Dispatched++;
        }

        [TestCleanup]
        public void cleanup()
        {
            diMock.Object.Dispose();
        }

        [TestMethod]
        public void TestsSimpleEventCall()
        {
            Assert.AreEqual(0, eventSwi1Dispatched);
            swi1.OnSwitchStateChanged(new SwitchEventArgs(Switches.Switch1, true));
            Assert.AreEqual(1, eventSwi1Dispatched);
            swi1.OnSwitchStateChanged(new SwitchEventArgs(Switches.Switch3, true));
            Assert.AreEqual(2, eventSwi1Dispatched);
        }

        [TestMethod]
        public void TestDigitalInEventButNoChange()
        {
            diMock.Setup(m => m[(int)Switches.Switch1]).Returns(false);
            diMock.Setup(m => m[(int)Switches.Switch2]).Returns(false);
            
            // check state before
            Assert.AreEqual(0, eventSwi1Dispatched);
            Assert.AreEqual(0, eventSwi2Dispatched);
            
            // raise event but no real value changed
            diMock.Raise(m => m.DigitalInChanged+= null, new EventArgs());

            // check state after call
            Assert.AreEqual(0, eventSwi1Dispatched);
            Assert.AreEqual(0, eventSwi2Dispatched);
        }

        public void testChangeOnceBothAndOneTwiceSwitch()
        {
            // raise event and value for switch one have changed
            diMock.Setup(m => m[(int)Switches.Switch1]).Returns(true);
            diMock.Setup(m => m[(int)Switches.Switch2]).Returns(true);
            diMock.Raise(m => m.DigitalInChanged += null, new EventArgs());

            Assert.AreEqual(1, eventSwi1Dispatched);
            Assert.AreEqual(1, eventSwi2Dispatched);

            // raise change only one switch
            diMock.Setup(m => m[(int)Switches.Switch1]).Returns(false);
            diMock.Raise(m => m.DigitalInChanged += null, new EventArgs());

            Assert.AreEqual(2, eventSwi1Dispatched);
            Assert.AreEqual(1, eventSwi2Dispatched);
        }
    }
}
