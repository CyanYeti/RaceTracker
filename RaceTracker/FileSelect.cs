using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTracker
{
    public partial class FileSelect : Form
    {
        public string FinalRacerPath { get; set; }
        public string FinalSensorPath { get; set; }
        public string FinalGroupPath { get; set; }
        public FileSelect(string finalRacerFilePath, string finalSensorFilePath, string finalGroupFilePath)
        {
            InitializeComponent();
            this.textBox1.Text = Path.GetFullPath("Racers.CSV");
            this.textBox2.Text = Path.GetFullPath("Groups.CSV");
            this.textBox3.Text = Path.GetFullPath("Sensors.CSV");
        }

        private void FileExploreRacers_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog getRacerPath = new OpenFileDialog())
            {
                getRacerPath.InitialDirectory= this.textBox1.Text;
                getRacerPath.Filter = "*.csv";
                getRacerPath.RestoreDirectory= true;

                if(getRacerPath.ShowDialog() == DialogResult.OK)
                {
                    FinalRacerPath= getRacerPath.FileName;
                    this.textBox1.Text = FinalSensorPath;
                }
            }
        }

        private void FileExploreGroups_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog getGroupPath = new OpenFileDialog())
            {
                getGroupPath.InitialDirectory = this.textBox1.Text;
                getGroupPath.Filter = "*.csv";
                getGroupPath.RestoreDirectory = true;

                if (getGroupPath.ShowDialog() == DialogResult.OK)
                {
                    FinalGroupPath = getGroupPath.FileName;
                    this.textBox2.Text = FinalSensorPath;
                }
            }
        }

        private void FileExploreSensors_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog getSensorPath = new OpenFileDialog())
            {
                getSensorPath.InitialDirectory = this.textBox1.Text;
                getSensorPath.Filter = "*.csv";
                getSensorPath.RestoreDirectory = true;

                if (getSensorPath.ShowDialog() == DialogResult.OK)
                {
                    FinalSensorPath = getSensorPath.FileName;
                    this.textBox3.Text = FinalSensorPath;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FinalRacerPath = this.textBox1.Text;
            FinalSensorPath = this.textBox3.Text;
            FinalGroupPath = this.textBox2.Text;
            
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
