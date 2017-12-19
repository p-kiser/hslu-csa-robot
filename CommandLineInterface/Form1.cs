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
        CLIServer server;
        IterativerServer iServer;

        public Form1()
        {
            InitializeComponent();

            cli = new CommandConsole();
            monitor = new FileMonitor(file);
            server = new CLIServer(cli, monitor);
            iServer = new IterativerServer();

            server.listen();

            Console.WriteLine(monitor.dump());
        }
    }
}
