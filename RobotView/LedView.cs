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
        private bool state = false;

        public bool State
        {
            get
            {
                return this.State;
            }
            set
            {
                this.State = value;
            }
        }

        public LedView()
        {
            InitializeComponent();
        }
        
        private void updateView()
        {
            this.ledPictureBox.Image = this.state ? Resource.LedOn : Resource.LedOff;
        }
    }
}