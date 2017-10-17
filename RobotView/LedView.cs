using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RobotView
{
    public partial class LedView : UserControl
    {
        public LedView()
        {
            InitializeComponent();
            state = false;
        }

        private void ledPictureBox_Click(object sender, EventArgs e)
        {

        }
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                ledPictureBox.Image = value ? Resource.LedOn : Resource.LedOff;
            }
        }
        
        private void updateView()
        {
            this.ledPictureBox.Image = this.state ? Resource.LedOn : Resource.LedOff;
        }
    }
}