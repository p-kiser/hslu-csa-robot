using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Windows.Forms;
using RobotView;
using RobotCtrl;
using Moq;

namespace RobotViewTest
{
    [TestClass]
    public class LedViewTest
    {
        LedView ledView;
        Mock<Led> ledMock; 

        [TestInitialize]
        public void setup()
        {
            ledView = new LedView();
            ledMock = new Mock<Led>();
        }

        [TestMethod]
        public void TestLedStateChange()
        {
            ledView.LedCtrl = ledMock.Object;
            ledMock.Object.OnLedStateChanged(new LedEventArgs(Leds.Led1, true));

            Assert.IsTrue(ledView.State);

            ledMock.Object.OnLedStateChanged(new LedEventArgs(Leds.Led1, false));

            Assert.IsFalse(ledView.State);
        }
    }
}
