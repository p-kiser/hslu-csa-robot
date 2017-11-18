using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RobotCtrl;

namespace Testat
{
    public partial class Form1 : Form
    {
        private Robot robot;

        public Form1()
        {
            InitializeComponent();

            robot = new Robot();

            driveView.Drive 
                = runArc.Drive
                = runLine.Drive
                = runTurn.Drive
                = robot.Drive;
            consoleView.robotConsole = robot.RobotConsole;

            robot.Drive.Power = true;

            addStartToSwitch(Switches.Switch1, runLine);
            addStartToSwitch(Switches.Switch2, runArc);
            addStartToSwitch(Switches.Switch3, runTurn);
        }

        private void addStartToSwitch(Switches swi, RobotView.Startable runner)
        {
            robot.RobotConsole[swi]
                .SwitchStateChanged += (object sender, SwitchEventArgs e) =>
                {
                    if (e.SwitchEnabled)
                    {
                        runner.Start();
                    } else
                    {
                        robot.Drive.Halt();
                    }
                };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            robot.Drive.Halt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            robot.Drive.Stop();
        }

        private void runLine_Click(object sender, EventArgs e)
        {

        }
    }
}
