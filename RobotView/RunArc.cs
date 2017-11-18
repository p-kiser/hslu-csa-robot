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
    public partial class RunArc : UserControl, Startable
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


        public void buttonStartArc_Click(object sender, EventArgs e)
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

        private void numPadButton1_Click(object sender, EventArgs e)
        {
            NumberKeyboard.startNumberKeyboard((float number) => {
                try
                {
                    upDownArcRadius.Value = (decimal)number;
                }
                catch (ArgumentOutOfRangeException ex) {
                    //TODO
                }
            });
        }

        private void numPadButton2_Click(object sender, EventArgs e)
        {
            RobotView.NumberKeyboard nk = new RobotView.NumberKeyboard();
            if (nk.ShowDialog() == DialogResult.OK)
            {
                upDownArcAngle.Value = (decimal)nk.Number;
            }
        }
    }
}