using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class LedView : UserControl
    {

        private bool state;
        private Led ledCtrl;

        public LedView()
        {
            InitializeComponent();
            state = false;
        }


        public bool State
        {
            get { return state; }
            set
            {
                updateView(state = value);
            }
        }

        public Led LedCtrl
        {
            set
            {
                ledCtrl = value;
                ledCtrl.LedStateChanged += LedCtrl_LedStateChanged;                
            }
        }

        private void LedCtrl_LedStateChanged(object sender, LedEventArgs e)
        {
            this.State = e.LedEnabled;
        }

        private void updateView(bool state)
        {
            this.Invoke(new Action(() =>
            {
                this.ledPictureBox.Image = state ? Resource.LedOn : Resource.LedOff;
            }));
        }
        private void updateView()
        {
            updateView(this.state);
        }

        private void ledPictureBox_Click(object sender, EventArgs e)
        {
            //ledPictureBox.Image = ledPictureBox.Image == Resource.LedOn ? Resource.LedOff : Resource.LedOn;
        }
    }
}