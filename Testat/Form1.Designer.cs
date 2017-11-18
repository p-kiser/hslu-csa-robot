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
            this.stopButton = new System.Windows.Forms.Button();
            this.haltButton = new System.Windows.Forms.Button();
            this.commonRunParameters = new RobotView.CommonRunParameters();
            this.SuspendLayout();
            // 
            // runTurn
            // 
            this.runTurn.Acceleration = 0.5F;
            this.runTurn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.runTurn.Drive = null;
            this.runTurn.Location = new System.Drawing.Point(332, 160);
            this.runTurn.Name = "runTurn";
            this.runTurn.Size = new System.Drawing.Size(467, 52);
            this.runTurn.Speed = 1F;
            this.runTurn.TabIndex = 0;
            // 
            // runArc
            // 
            this.runArc.Acceleration = 0.5F;
            this.runArc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.runArc.Drive = null;
            this.runArc.Location = new System.Drawing.Point(332, 218);
            this.runArc.Name = "runArc";
            this.runArc.Size = new System.Drawing.Size(467, 98);
            this.runArc.Speed = 1F;
            this.runArc.TabIndex = 0;
            // 
            // runLine
            // 
            this.runLine.Acceleration = 0.5F;
            this.runLine.BackColor = System.Drawing.SystemColors.ControlLight;
            this.runLine.Drive = null;
            this.runLine.Length = 1F;
            this.runLine.Location = new System.Drawing.Point(332, 105);
            this.runLine.Name = "runLine";
            this.runLine.Size = new System.Drawing.Size(467, 49);
            this.runLine.Speed = 1F;
            this.runLine.TabIndex = 0;
            this.runLine.Click += new System.EventHandler(this.runLine_Click);
            // 
            // driveView
            // 
            this.driveView.Drive = null;
            this.driveView.Location = new System.Drawing.Point(26, 31);
            this.driveView.Name = "driveView";
            this.driveView.Size = new System.Drawing.Size(309, 324);
            this.driveView.TabIndex = 0;
            // 
            // consoleView
            // 
            this.consoleView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.consoleView.Location = new System.Drawing.Point(3, 332);
            this.consoleView.Name = "consoleView";
            this.consoleView.Size = new System.Drawing.Size(309, 119);
            this.consoleView.TabIndex = 0;
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.stopButton.Location = new System.Drawing.Point(565, 361);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(234, 78);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // haltButton
            // 
            this.haltButton.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.haltButton.Location = new System.Drawing.Point(332, 361);
            this.haltButton.Name = "haltButton";
            this.haltButton.Size = new System.Drawing.Size(227, 78);
            this.haltButton.TabIndex = 3;
            this.haltButton.Text = "Halt";
            this.haltButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // commonRunParameters
            // 
            this.commonRunParameters.Acceleration = 0.3F;
            this.commonRunParameters.BackColor = System.Drawing.SystemColors.ControlLight;
            this.commonRunParameters.Location = new System.Drawing.Point(332, 22);
            this.commonRunParameters.Name = "commonRunParameters";
            this.commonRunParameters.Size = new System.Drawing.Size(467, 77);
            this.commonRunParameters.Speed = 0.5F;
            this.commonRunParameters.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(817, 471);
            this.Controls.Add(this.haltButton);
            this.Controls.Add(this.stopButton);
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
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button haltButton;
    }
}

