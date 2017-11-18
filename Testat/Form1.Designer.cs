using RobotView;

namespace Testat
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
            this.runTurn = new RobotView.RunTurn();
            this.runArc = new RobotView.RunArc();
            this.runLine = new RobotView.RunLine();
            this.driveView = new RobotView.DriveView();
            this.consoleView = new RobotView.ConsoleView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.commonRunParameters = new RobotView.CommonRunParameters();
            this.SuspendLayout();
            // 
            // runTurn
            // 
            this.runTurn.Acceleration = 0.5F;
            this.runTurn.Drive = null;
            this.runTurn.Location = new System.Drawing.Point(548, 347);
            this.runTurn.Name = "runTurn";
            this.runTurn.Size = new System.Drawing.Size(454, 98);
            this.runTurn.Speed = 1F;
            this.runTurn.TabIndex = 0;
            // 
            // runArc
            // 
            this.runArc.Acceleration = 0.5F;
            this.runArc.Drive = null;
            this.runArc.Location = new System.Drawing.Point(548, 215);
            this.runArc.Name = "runArc";
            this.runArc.Size = new System.Drawing.Size(454, 115);
            this.runArc.Speed = 1F;
            this.runArc.TabIndex = 0;
            // 
            // runLine
            // 
            this.runLine.Acceleration = 0.5F;
            this.runLine.Drive = null;
            this.runLine.Length = 1F;
            this.runLine.Location = new System.Drawing.Point(548, 108);
            this.runLine.Name = "runLine";
            this.runLine.Size = new System.Drawing.Size(454, 115);
            this.runLine.Speed = 1F;
            this.runLine.TabIndex = 0;
            // 
            // driveView
            // 
            this.driveView.Drive = null;
            this.driveView.Location = new System.Drawing.Point(26, 22);
            this.driveView.Name = "driveView";
            this.driveView.Size = new System.Drawing.Size(373, 365);
            this.driveView.TabIndex = 0;
            // 
            // consoleView
            // 
            this.consoleView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.consoleView.Location = new System.Drawing.Point(43, 450);
            this.consoleView.Name = "consoleView";
            this.consoleView.Size = new System.Drawing.Size(309, 122);
            this.consoleView.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(779, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 56);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 486);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 77);
            this.button1.TabIndex = 3;
            this.button1.Text = "Halt";
            // 
            // commonRunParameters
            // 
            this.commonRunParameters.Acceleration = 0.3F;
            this.commonRunParameters.Location = new System.Drawing.Point(526, 22);
            this.commonRunParameters.Name = "commonRunParameters";
            this.commonRunParameters.Size = new System.Drawing.Size(601, 77);
            this.commonRunParameters.Speed = 0.5F;
            this.commonRunParameters.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1219, 628);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.runLine);
            this.Controls.Add(this.runArc);
            this.Controls.Add(this.commonRunParameters);
            this.Controls.Add(this.runTurn);
            this.Controls.Add(this.driveView);
            this.Controls.Add(this.consoleView);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DriveView driveView;
        private ConsoleView consoleView;

        private RunTurn runTurn;
        private RunArc runArc;
        private RunLine runLine;

        private CommonRunParameters commonRunParameters;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

