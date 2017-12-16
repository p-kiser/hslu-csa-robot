using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CommandConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotCtrl.CommandConsole cli = new RobotCtrl.CommandConsole();
            Console.WriteLine("Starting Console");

            while(true) { }
            cli.execute(new List<string>()
            {
                "runArc",
                ""
            });
        }
    }
}
