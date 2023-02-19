namespace RaceTracker
{
    partial class CheaterObserver
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
            this.lvRacersWatched = new System.Windows.Forms.ListView();
            this.lvCheatedWith = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvRacersWatched
            // 
            this.lvRacersWatched.HideSelection = false;
            this.lvRacersWatched.Location = new System.Drawing.Point(12, 25);
            this.lvRacersWatched.Name = "lvRacersWatched";
            this.lvRacersWatched.Size = new System.Drawing.Size(383, 413);
            this.lvRacersWatched.TabIndex = 1;
            this.lvRacersWatched.UseCompatibleStateImageBehavior = false;
            // 
            // lvCheatedWith
            // 
            this.lvCheatedWith.HideSelection = false;
            this.lvCheatedWith.Location = new System.Drawing.Point(416, 25);
            this.lvCheatedWith.Name = "lvCheatedWith";
            this.lvCheatedWith.Size = new System.Drawing.Size(372, 413);
            this.lvCheatedWith.TabIndex = 2;
            this.lvCheatedWith.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cheaters";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cheated With";
            // 
            // CheaterObserver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCheatedWith);
            this.Controls.Add(this.lvRacersWatched);
            this.Name = "CheaterObserver";
            this.Text = "CheaterObserver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvRacersWatched;
        private System.Windows.Forms.ListView lvCheatedWith;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}