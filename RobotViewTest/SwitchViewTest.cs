using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RobotCtrl;

namespace RobotView
{
    [TestClass]
    public class SwitchViewTest
    {
        [TestMethod]
        public void TestSwitchEventHandle()
        {
            
            var switchCtrlMock = new Mock<Switch>();
            SwitchView switchView = new SwitchView();

            switchView.SwitchCtrl = switchCtrlMock.Object;

            // start test change event call
            switchCtrlMock.Object.OnSwitchStateChanged(new SwitchEventArgs(Switches.Switch1, false));

            Assert.IsFalse(switchView.State);

            // invoke Switchchange again
            switchCtrlMock.Object.OnSwitchStateChanged(new SwitchEventArgs(Switches.Switch1, true));

            Assert.IsTrue(switchView.State);
        }
    }
}
