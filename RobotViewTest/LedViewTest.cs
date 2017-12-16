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
    }
}
