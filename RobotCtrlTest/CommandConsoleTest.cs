using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace RobotCtrlTest
{
    [TestClass]
    public class CommandConsoleTest
    {
        class test
        {
            public void hey(float value)
            {
                Console.WriteLine(value);
            }
        }

        [TestMethod]
        public void TestRefelectionCall()
        {
            test t = new test();
            Type DriveType = t.GetType();
            MethodInfo trackMethod = DriveType.GetMethod("hey");
            trackMethod.Invoke(t, new Object[] { float.Parse("1.5") });
        }
    }
}
