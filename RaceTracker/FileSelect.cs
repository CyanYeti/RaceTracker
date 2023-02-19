using System;
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
        public FileSelect()
        {
            InitializeComponent();
            this.textBox1.Text = Path.GetFullPath("Racers.CSV");
            this.textBox2.Text = Path.GetFullPath("Groups.CSV");
            this.textBox3.Text = Path.GetFullPath("Sensors.CSV");
        }

        private void FileExploreRacers_Click(object sender, EventArgs e)
        {

        }

        private void FileExploreGroups_Click(object sender, EventArgs e)
        {

        }

        private void FileExploreSensors_Click(object sender, EventArgs e)
        {

        }
    }
    }
}
