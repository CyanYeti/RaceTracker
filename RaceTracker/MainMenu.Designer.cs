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
            this.lbAllRacers = new System.Windows.Forms.ListBox();
            this.RacerSelector = new System.Windows.Forms.Label();
            this.btnSelectRacer = new System.Windows.Forms.Button();
            this.btnDeselectRacer = new System.Windows.Forms.Button();
            this.lbSelectedRacers = new System.Windows.Forms.ListBox();
            this.lblSelectedRacers = new System.Windows.Forms.Label();
            this.lbObserverTypes = new System.Windows.Forms.ListBox();
            this.lblObserverOptions = new System.Windows.Forms.Label();
            this.btnCreateObserver = new System.Windows.Forms.Button();
            this.lblCreatedObservers = new System.Windows.Forms.Label();
            this.lbCreatedObservers = new System.Windows.Forms.ListBox();
            this.txtObserverName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbAllRacers
            // 
            this.lbAllRacers.FormattingEnabled = true;
            this.lbAllRacers.Location = new System.Drawing.Point(575, 25);
            this.lbAllRacers.Name = "lbAllRacers";
            this.lbAllRacers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAllRacers.Size = new System.Drawing.Size(213, 407);
            this.lbAllRacers.TabIndex = 0;
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
            // btnSelectRacer
            // 
            this.btnSelectRacer.Location = new System.Drawing.Point(537, 182);
            this.btnSelectRacer.Name = "btnSelectRacer";
            this.btnSelectRacer.Size = new System.Drawing.Size(32, 23);
            this.btnSelectRacer.TabIndex = 2;
            this.btnSelectRacer.Text = "<";
            this.btnSelectRacer.UseVisualStyleBackColor = true;
            this.btnSelectRacer.Click += new System.EventHandler(this.btnSelectRacer_Click);
            // 
            // btnDeselectRacer
            // 
            this.btnDeselectRacer.Location = new System.Drawing.Point(537, 211);
            this.btnDeselectRacer.Name = "btnDeselectRacer";
            this.btnDeselectRacer.Size = new System.Drawing.Size(32, 23);
            this.btnDeselectRacer.TabIndex = 3;
            this.btnDeselectRacer.Text = ">";
            this.btnDeselectRacer.UseVisualStyleBackColor = true;
            // 
            // lbSelectedRacers
            // 
            this.lbSelectedRacers.FormattingEnabled = true;
            this.lbSelectedRacers.Location = new System.Drawing.Point(318, 25);
            this.lbSelectedRacers.Name = "lbSelectedRacers";
            this.lbSelectedRacers.Size = new System.Drawing.Size(213, 407);
            this.lbSelectedRacers.TabIndex = 4;
            // 
            // lblSelectedRacers
            // 
            this.lblSelectedRacers.AutoSize = true;
            this.lblSelectedRacers.Location = new System.Drawing.Point(315, 9);
            this.lblSelectedRacers.Name = "lblSelectedRacers";
            this.lblSelectedRacers.Size = new System.Drawing.Size(86, 13);
            this.lblSelectedRacers.TabIndex = 5;
            this.lblSelectedRacers.Text = "Selected Racers";
            // 
            // lbObserverTypes
            // 
            this.lbObserverTypes.FormattingEnabled = true;
            this.lbObserverTypes.Location = new System.Drawing.Point(12, 25);
            this.lbObserverTypes.Name = "lbObserverTypes";
            this.lbObserverTypes.Size = new System.Drawing.Size(213, 82);
            this.lbObserverTypes.TabIndex = 6;
            // 
            // lblObserverOptions
            // 
            this.lblObserverOptions.AutoSize = true;
            this.lblObserverOptions.Location = new System.Drawing.Point(12, 9);
            this.lblObserverOptions.Name = "lblObserverOptions";
            this.lblObserverOptions.Size = new System.Drawing.Size(69, 13);
            this.lblObserverOptions.TabIndex = 7;
            this.lblObserverOptions.Text = "Create Peron";
            // 
            // btnCreateObserver
            // 
            this.btnCreateObserver.Location = new System.Drawing.Point(12, 139);
            this.btnCreateObserver.Name = "btnCreateObserver";
            this.btnCreateObserver.Size = new System.Drawing.Size(213, 23);
            this.btnCreateObserver.TabIndex = 8;
            this.btnCreateObserver.Text = "Create Person w/ Selected Racers";
            this.btnCreateObserver.UseVisualStyleBackColor = true;
            this.btnCreateObserver.Click += new System.EventHandler(this.btnCreateObserver_Click);
            // 
            // lblCreatedObservers
            // 
            this.lblCreatedObservers.AutoSize = true;
            this.lblCreatedObservers.Location = new System.Drawing.Point(15, 195);
            this.lblCreatedObservers.Name = "lblCreatedObservers";
            this.lblCreatedObservers.Size = new System.Drawing.Size(40, 13);
            this.lblCreatedObservers.TabIndex = 10;
            this.lblCreatedObservers.Text = "People";
            // 
            // lbCreatedObservers
            // 
            this.lbCreatedObservers.FormattingEnabled = true;
            this.lbCreatedObservers.Location = new System.Drawing.Point(15, 211);
            this.lbCreatedObservers.Name = "lbCreatedObservers";
            this.lbCreatedObservers.Size = new System.Drawing.Size(213, 82);
            this.lbCreatedObservers.TabIndex = 9;
            // 
            // txtObserverName
            // 
            this.txtObserverName.Location = new System.Drawing.Point(12, 113);
            this.txtObserverName.Name = "txtObserverName";
            this.txtObserverName.Size = new System.Drawing.Size(213, 20);
            this.txtObserverName.TabIndex = 11;
            this.txtObserverName.Text = "Person Name";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtObserverName);
            this.Controls.Add(this.lblCreatedObservers);
            this.Controls.Add(this.lbCreatedObservers);
            this.Controls.Add(this.btnCreateObserver);
            this.Controls.Add(this.lblObserverOptions);
            this.Controls.Add(this.lbObserverTypes);
            this.Controls.Add(this.lblSelectedRacers);
            this.Controls.Add(this.lbSelectedRacers);
            this.Controls.Add(this.btnDeselectRacer);
            this.Controls.Add(this.btnSelectRacer);
            this.Controls.Add(this.RacerSelector);
            this.Controls.Add(this.lbAllRacers);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbAllRacers;
        private System.Windows.Forms.Label RacerSelector;
        private System.Windows.Forms.Button btnSelectRacer;
        private System.Windows.Forms.Button btnDeselectRacer;
        private System.Windows.Forms.ListBox lbSelectedRacers;
        private System.Windows.Forms.Label lblSelectedRacers;
        private System.Windows.Forms.ListBox lbObserverTypes;
        private System.Windows.Forms.Label lblObserverOptions;
        private System.Windows.Forms.Button btnCreateObserver;
        private System.Windows.Forms.Label lblCreatedObservers;
        private System.Windows.Forms.ListBox lbCreatedObservers;
        private System.Windows.Forms.TextBox txtObserverName;
    }
}

