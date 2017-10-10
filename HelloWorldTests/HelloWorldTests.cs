using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Tests
{
    [TestClass()]
    public class HelloWorldTests
    {
        

        [TestMethod()]
        public void runTest()
        {
            HelloWorld helloWorld = new HelloWorld();

            Assert.AreEqual("Hello World", helloWorld.run());
        }
    }
}