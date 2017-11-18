using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Testat
{
    public partial class Form1 : Form
    {
        private RobotCtrl.Robot robot;

        public Form1()
        {
            InitializeComponent();

            robot = new RobotCtrl.Robot();

            driveView.Drive 
                = runArc.Drive
                = runLine.Drive
                = runTurn.Drive
                = robot.Drive;
            consoleView.robotConsole = robot.RobotConsole;

            robot.Drive.Power = true;
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
