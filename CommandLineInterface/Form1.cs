using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RobotCtrl;

namespace CommandLineInterface
{
    public partial class Form1 : Form
    {
        public static string file = System.IO.Path.GetTempFileName();
        private Monitor monitor;
        CommandConsole cli;

        public Form1()
        {
            InitializeComponent();

            cli = new CommandConsole();
            monitor = new FileMonitor(file);

            cli.print();

            cli.addQueue("RunLine 1");
            cli.addQueue("RunTurn 90");
            cli.addQueue("RunArcLeft 0.5 45");
            cli.addQueue("RunArcRight 0.5 45");

            monitor.start(cli);
            cli.executeQueue();
            monitor.stop();

            Console.WriteLine(monitor.dump());
        }
    }
}
