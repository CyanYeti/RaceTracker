namespace RaceTracker
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.RaceSelectorBox = new System.Windows.Forms.ListBox();
            this.RacerSelector = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RaceSelectorBox
            // 
            this.RaceSelectorBox.FormattingEnabled = true;
            this.RaceSelectorBox.Location = new System.Drawing.Point(575, 25);
            this.RaceSelectorBox.Name = "RaceSelectorBox";
            this.RaceSelectorBox.Size = new System.Drawing.Size(213, 407);
            this.RaceSelectorBox.TabIndex = 0;
            
            // 
            // RacerSelector
            // 
            this.RacerSelector.AutoSize = true;
            this.RacerSelector.Location = new System.Drawing.Point(572, 9);
            this.RacerSelector.Name = "RacerSelector";
            this.RacerSelector.Size = new System.Drawing.Size(41, 13);
            this.RacerSelector.TabIndex = 1;
            this.RacerSelector.Text = "Racers";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RacerSelector);
            this.Controls.Add(this.RaceSelectorBox);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RaceSelectorBox;
        private System.Windows.Forms.Label RacerSelector;
    }
}

