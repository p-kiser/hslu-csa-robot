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
    public partial class RunTurn : UserControl, Startable
    {
        #region constructor & destructor
        public RunTurn()
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
        private void buttonTurnStart_Click(object sender, EventArgs e)
        {
            if (Drive != null) Drive.RunTurn(
                (float)upDownTurnAngle.Value, Speed, Acceleration);
        }

        private void buttonTurnNeg_Click(object sender, EventArgs e)
        {
            upDownTurnAngle.Value = -upDownTurnAngle.Value;
        }

        public void Start()
        {
            buttonTurnStart_Click(null, EventArgs.Empty);
        }
        #endregion

        private void numPadButton_Click(object sender, EventArgs e)
        {
            RobotView.NumberKeyboard nk = new RobotView.NumberKeyboard();
            if (nk.ShowDialog() == DialogResult.OK)
            {
                upDownTurnAngle.Value = (decimal)nk.Number;
            }
        }
    }
}