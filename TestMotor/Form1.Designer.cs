namespace TestMotor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.driveCtrlView = new RobotView.DriveCtrlView();
            this.motorCtrlView = new RobotView.MotorCtrlView();
            this.SuspendLayout();
            // 
            // driveCtrlView
            // 
            this.driveCtrlView.DriveCtrl = null;
            this.driveCtrlView.Location = new System.Drawing.Point(21, 12);
            this.driveCtrlView.Name = "driveCtrlView";
            this.driveCtrlView.Size = new System.Drawing.Size(538, 128);
            this.driveCtrlView.TabIndex = 0;
            // 
            // motorCtrlView
            // 
            this.motorCtrlView.Location = new System.Drawing.Point(21, 130);
            this.motorCtrlView.MotorCtrl = null;
            this.motorCtrlView.Name = "motorCtrlView";
            this.motorCtrlView.Size = new System.Drawing.Size(461, 273);
            this.motorCtrlView.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(667, 460);
            this.Controls.Add(this.driveCtrlView);
            this.Controls.Add(this.motorCtrlView);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.DriveCtrlView driveCtrlView;
        private RobotView.MotorCtrlView motorCtrlView;
    }
}

