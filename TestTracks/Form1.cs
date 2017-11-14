using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestTracks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            runTurn.Drive = new RobotCtrl.Drive();
            runTurn.Drive.Power = true;
        }
    }
}
