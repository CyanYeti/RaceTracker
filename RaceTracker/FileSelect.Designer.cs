namespace RaceTracker
{
    partial class FileSelect
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
            this.FileExploreRacers = new System.Windows.Forms.Button();
            this.FileExploreGroups = new System.Windows.Forms.Button();
            this.FileExploreSensors = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FileExploreRacers
            // 
            this.FileExploreRacers.Location = new System.Drawing.Point(13, 13);
            this.FileExploreRacers.Name = "FileExploreRacers";
            this.FileExploreRacers.Size = new System.Drawing.Size(75, 23);
            this.FileExploreRacers.TabIndex = 0;
            this.FileExploreRacers.Text = "Racer File";
            this.FileExploreRacers.UseVisualStyleBackColor = true;
            this.FileExploreRacers.Click += new System.EventHandler(this.FileExploreRacers_Click);
            // 
            // FileExploreGroups
            // 
            this.FileExploreGroups.Location = new System.Drawing.Point(13, 42);
            this.FileExploreGroups.Name = "FileExploreGroups";
            this.FileExploreGroups.Size = new System.Drawing.Size(75, 23);
            this.FileExploreGroups.TabIndex = 1;
            this.FileExploreGroups.Text = "Groups File";
            this.FileExploreGroups.UseVisualStyleBackColor = true;
            this.FileExploreGroups.Click += new System.EventHandler(this.FileExploreGroups_Click);
            // 
            // FileExploreSensors
            // 
            this.FileExploreSensors.Location = new System.Drawing.Point(13, 71);
            this.FileExploreSensors.Name = "FileExploreSensors";
            this.FileExploreSensors.Size = new System.Drawing.Size(75, 23);
            this.FileExploreSensors.TabIndex = 2;
            this.FileExploreSensors.Text = "Sensor File";
            this.FileExploreSensors.UseVisualStyleBackColor = true;
            this.FileExploreSensors.Click += new System.EventHandler(this.FileExploreSensors_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(494, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(494, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(94, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(494, 20);
            this.textBox3.TabIndex = 5;
            // 
            // FileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 117);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FileExploreSensors);
            this.Controls.Add(this.FileExploreGroups);
            this.Controls.Add(this.FileExploreRacers);
            this.Name = "FileSelect";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileExploreRacers;
        private System.Windows.Forms.Button FileExploreGroups;
        private System.Windows.Forms.Button FileExploreSensors;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}