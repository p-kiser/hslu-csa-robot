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
    public partial class RunArc : UserControl
    {
        #region constructor & destructor
        public RunArc()
        {
            InitializeComponent();
        }
        #endregion


        #region properties
        public float Speed { get; set; }
        public float Acceleration { get; set; }
        public Drive Drive { get; set; }
        #endregion


        #region methods
        private void buttonArcNeg_Click(object sender, EventArgs e)
        {
            upDownArcAngle.Value = -upDownArcAngle.Value;
        }


        private void buttonStartArc_Click(object sender, EventArgs e)
        {
            if (Drive != null)
            {
                if (radioButtonArcRight.Checked)
                {
                    Drive.RunArcRight((float)upDownArcRadius.Value / 1000,
                        (float)upDownArcAngle.Value, Speed, Acceleration);
                }
                else
                {
                    Drive.RunArcLeft((float)upDownArcRadius.Value / 1000,
                        (float)upDownArcAngle.Value, Speed, Acceleration);
                }
            }
        }

        public void Start()
        {
            buttonStartArc_Click(null, EventArgs.Empty);
        }
        #endregion
    }
}