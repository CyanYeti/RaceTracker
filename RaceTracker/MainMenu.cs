using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTracker
{
    public partial class MainMenu : Form
    {
        //private Tracker Rtracker { get; set; }
        private DataReceiver receiver;
        public MainMenu()
        {
            InitializeComponent();
            Tracker Rtracker = new Tracker();

            // PUll in all racers into select box
            foreach (KeyValuePair<int, Racer> racer in Rtracker.GetRacers() )
            {
                this.lbAllRacers.Items.Add(racer.Value.toString());
            }

            // Populate observer types

            // Passing the data storage class Tracker by reference
            DataReceiver receiver = new DataReceiver(ref Rtracker);
            receiver.Start();

            // For now just read a line from the console 
            //string tmp = Console.ReadLine();

        }

        private void btnSelectRacer_Click(object sender, EventArgs e)
        {
            foreach (int index in this.lbAllRacers.SelectedIndices)
            {
                string racer = this.lbAllRacers.Items[index].ToString();
                lbSelectedRacers.Items.Add(racer);
            }
        }

        private int getBIB(string racer)
        {
            return Convert.ToInt32(racer.Split(':')[0]);
        }
    }
}
