namespace TestTracks
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
            this.SuspendLayout();
            // 
            // runTurn
            // 
            this.runTurn.Acceleration = 0.5F;
            this.runTurn.Drive = null;
            this.runTurn.Location = new System.Drawing.Point(48, 313);
            this.runTurn.Name = "runTurn";
            this.runTurn.Size = new System.Drawing.Size(454, 98);
            this.runTurn.Speed = 1F;
            this.runTurn.TabIndex = 0;
            // 
            // runArc
            // 
            this.runArc.Acceleration = 0.5F;
            this.runArc.Drive = null;
            this.runArc.Location = new System.Drawing.Point(548, 159);
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
            this.runLine.Location = new System.Drawing.Point(531, 38);
            this.runLine.Name = "runLine";
            this.runLine.Size = new System.Drawing.Size(454, 115);
            this.runLine.Speed = 1F;
            this.runLine.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1058, 610);
            this.Controls.Add(this.runTurn);
            this.Controls.Add(this.runArc);
            this.Controls.Add(this.runLine);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.RunTurn runTurn;
        private RobotView.RunArc runArc;
        private RobotView.RunLine runLine;
    }
}

