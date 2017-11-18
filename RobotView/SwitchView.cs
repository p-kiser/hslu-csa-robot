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
    public partial class SwitchView : UserControl
    {

        private bool state;
        private Switch switchCtrl;


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
                switchPictureBox.Image = value ? Resource.SwitchOn : Resource.SwitchOff;
            }
        }

        public Switch SwitchCtrl
        {
            set
            {
                switchCtrl = value;
                if(switchCtrl != null)
                    switchCtrl.SwitchStateChanged += SwitchCtrl_SwitchStateChanged;
            }

            get
            {
                return switchCtrl;
            }
        }

        /// <summary>
        /// Update switch state if sender is own set
        /// switch.
        /// </summary>
        /// <param name="sender">The switch from where the change is from</param>
        /// <param name="e">Event</param>
        private void SwitchCtrl_SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if(sender == switchCtrl)
            {
                this.state = e.SwitchEnabled;
                updateView();
            }
        }

        private void updateView()
        {
            this.Invoke(new Action(() => {
                this.switchPictureBox.Image = this.state ? Resource.SwitchOn : Resource.SwitchOff;
            }));
        }

        private void switchPictureBox_Click(object sender, EventArgs e)
        {
            //switchPictureBox.Image = switchPictureBox.Image == Resource.SwitchOn ? Resource.SwitchOff : Resource.SwitchOn;
        }
    }
}