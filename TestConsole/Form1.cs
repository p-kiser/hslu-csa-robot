using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RobotCtrl;

namespace TestConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            consoleView.robotConsole = new RobotConsole();
        }

        private void consoleView_Click(object sender, EventArgs e)
        {

        }

        private void consoleView_Click_1(object sender, EventArgs e)
        {

        }
    }
}
