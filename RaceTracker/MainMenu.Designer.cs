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
            this.RacerSelector = new System.Windows.Forms.Label();
            this.btnSubscribeRacer = new System.Windows.Forms.Button();
            this.btnUnsubscribeRacer = new System.Windows.Forms.Button();
            this.lblSubscribedRacers = new System.Windows.Forms.Label();
            this.lblObserverOptions = new System.Windows.Forms.Label();
            this.btnCreateObserver = new System.Windows.Forms.Button();
            this.lblCreatedObservers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvAllRacers = new System.Windows.Forms.ListView();
            this.lvSubscribedRacers = new System.Windows.Forms.ListView();
            this.lvObserverOptions = new System.Windows.Forms.ListView();
            this.lvCreatedCheaters = new System.Windows.Forms.ListView();
            this.lvRacerObservers = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // RacerSelector
            // 
            this.RacerSelector.AutoSize = true;
            this.RacerSelector.Location = new System.Drawing.Point(531, 9);
            this.RacerSelector.Name = "RacerSelector";
            this.RacerSelector.Size = new System.Drawing.Size(41, 13);
            this.RacerSelector.TabIndex = 1;
            this.RacerSelector.Text = "Racers";
            // 
            // btnSubscribeRacer
            // 
            this.btnSubscribeRacer.Location = new System.Drawing.Point(496, 152);
            this.btnSubscribeRacer.Name = "btnSubscribeRacer";
            this.btnSubscribeRacer.Size = new System.Drawing.Size(32, 23);
            this.btnSubscribeRacer.TabIndex = 2;
            this.btnSubscribeRacer.Text = "<";
            this.btnSubscribeRacer.UseVisualStyleBackColor = true;
            this.btnSubscribeRacer.Click += new System.EventHandler(this.btnSubscribeRacer_Click);
            // 
            // btnUnsubscribeRacer
            // 
            this.btnUnsubscribeRacer.Location = new System.Drawing.Point(496, 181);
            this.btnUnsubscribeRacer.Name = "btnUnsubscribeRacer";
            this.btnUnsubscribeRacer.Size = new System.Drawing.Size(32, 23);
            this.btnUnsubscribeRacer.TabIndex = 3;
            this.btnUnsubscribeRacer.Text = ">";
            this.btnUnsubscribeRacer.UseVisualStyleBackColor = true;
            this.btnUnsubscribeRacer.Click += new System.EventHandler(this.btnUnsubscribeRacer_Click);
            // 
            // lblSubscribedRacers
            // 
            this.lblSubscribedRacers.AutoSize = true;
            this.lblSubscribedRacers.Location = new System.Drawing.Point(228, 9);
            this.lblSubscribedRacers.Name = "lblSubscribedRacers";
            this.lblSubscribedRacers.Size = new System.Drawing.Size(86, 13);
            this.lblSubscribedRacers.TabIndex = 5;
            this.lblSubscribedRacers.Text = "Selected Racers";
            // 
            // lblObserverOptions
            // 
            this.lblObserverOptions.AutoSize = true;
            this.lblObserverOptions.Location = new System.Drawing.Point(12, 9);
            this.lblObserverOptions.Name = "lblObserverOptions";
            this.lblObserverOptions.Size = new System.Drawing.Size(84, 13);
            this.lblObserverOptions.TabIndex = 7;
            this.lblObserverOptions.Text = "Create Observer";
            // 
            // btnCreateObserver
            // 
            this.btnCreateObserver.Location = new System.Drawing.Point(12, 113);
            this.btnCreateObserver.Name = "btnCreateObserver";
            this.btnCreateObserver.Size = new System.Drawing.Size(213, 23);
            this.btnCreateObserver.TabIndex = 8;
            this.btnCreateObserver.Text = "Create Observer";
            this.btnCreateObserver.UseVisualStyleBackColor = true;
            this.btnCreateObserver.Click += new System.EventHandler(this.btnCreateObserver_Click);
            // 
            // lblCreatedObservers
            // 
            this.lblCreatedObservers.AutoSize = true;
            this.lblCreatedObservers.Location = new System.Drawing.Point(12, 289);
            this.lblCreatedObservers.Name = "lblCreatedObservers";
            this.lblCreatedObservers.Size = new System.Drawing.Size(55, 13);
            this.lblCreatedObservers.TabIndex = 10;
            this.lblCreatedObservers.Text = "Observers";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Create Cheater Observer";
            // 
            // lvAllRacers
            // 
            this.lvAllRacers.HideSelection = false;
            this.lvAllRacers.Location = new System.Drawing.Point(534, 25);
            this.lvAllRacers.Name = "lvAllRacers";
            this.lvAllRacers.Size = new System.Drawing.Size(254, 407);
            this.lvAllRacers.TabIndex = 15;
            this.lvAllRacers.UseCompatibleStateImageBehavior = false;
            // 
            // lvSubscribedRacers
            // 
            this.lvSubscribedRacers.HideSelection = false;
            this.lvSubscribedRacers.Location = new System.Drawing.Point(231, 25);
            this.lvSubscribedRacers.Name = "lvSubscribedRacers";
            this.lvSubscribedRacers.Size = new System.Drawing.Size(259, 407);
            this.lvSubscribedRacers.TabIndex = 16;
            this.lvSubscribedRacers.UseCompatibleStateImageBehavior = false;
            // 
            // lvObserverOptions
            // 
            this.lvObserverOptions.HideSelection = false;
            this.lvObserverOptions.Location = new System.Drawing.Point(12, 25);
            this.lvObserverOptions.Name = "lvObserverOptions";
            this.lvObserverOptions.Size = new System.Drawing.Size(213, 82);
            this.lvObserverOptions.TabIndex = 17;
            this.lvObserverOptions.UseCompatibleStateImageBehavior = false;
            // 
            // lvCreatedCheaters
            // 
            this.lvCreatedCheaters.HideSelection = false;
            this.lvCreatedCheaters.Location = new System.Drawing.Point(12, 152);
            this.lvCreatedCheaters.Name = "lvCreatedCheaters";
            this.lvCreatedCheaters.Size = new System.Drawing.Size(213, 134);
            this.lvCreatedCheaters.TabIndex = 18;
            this.lvCreatedCheaters.UseCompatibleStateImageBehavior = false;
            // 
            // lvRacerObservers
            // 
            this.lvRacerObservers.HideSelection = false;
            this.lvRacerObservers.Location = new System.Drawing.Point(12, 305);
            this.lvRacerObservers.Name = "lvRacerObservers";
            this.lvRacerObservers.Size = new System.Drawing.Size(213, 127);
            this.lvRacerObservers.TabIndex = 19;
            this.lvRacerObservers.UseCompatibleStateImageBehavior = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 439);
            this.Controls.Add(this.lvRacerObservers);
            this.Controls.Add(this.lvCreatedCheaters);
            this.Controls.Add(this.lvObserverOptions);
            this.Controls.Add(this.lvSubscribedRacers);
            this.Controls.Add(this.lvAllRacers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCreatedObservers);
            this.Controls.Add(this.btnCreateObserver);
            this.Controls.Add(this.lblObserverOptions);
            this.Controls.Add(this.lblSubscribedRacers);
            this.Controls.Add(this.btnUnsubscribeRacer);
            this.Controls.Add(this.btnSubscribeRacer);
            this.Controls.Add(this.RacerSelector);
            this.Name = "MainMenu";
            this.Text = "sv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label RacerSelector;
        private System.Windows.Forms.Button btnSubscribeRacer;
        private System.Windows.Forms.Button btnUnsubscribeRacer;
        private System.Windows.Forms.Label lblSubscribedRacers;
        private System.Windows.Forms.Label lblObserverOptions;
        private System.Windows.Forms.Button btnCreateObserver;
        private System.Windows.Forms.Label lblCreatedObservers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvAllRacers;
        private System.Windows.Forms.ListView lvSubscribedRacers;
        private System.Windows.Forms.ListView lvObserverOptions;
        private System.Windows.Forms.ListView lvCreatedCheaters;
        private System.Windows.Forms.ListView lvRacerObservers;
    }
}

