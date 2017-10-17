using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RobotView
{
    public partial class SwitchView : UserControl
    {
        private bool State { get; set; }
        

        public SwitchView()
        {
            InitializeComponent();
            State = false;
            switchPictureBox.Image = Resource.SwitchOff;
        }
    }
}