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
        private bool state;

        public SwitchView()
        {
            InitializeComponent();
            state = false;
        }
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                switchPictureBox.Image = value ? Resource.LedOn : Resource.LedOff;
            }
        }
}