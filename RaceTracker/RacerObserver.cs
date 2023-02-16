using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTracker
{
    internal partial class RacerObserver : Form, Observer
    {
        Dictionary<int, Racer> RacersWatched = new Dictionary<int, Racer>();

        public RacerObserver(string name)
        {
            InitializeComponent();
            this.Text  = name;
            // Add Columns
            ColumnHeader bibHeader = new ColumnHeader();
            bibHeader.Text = "BIB";
            this.lvRacersWatched.Columns.Add(bibHeader);
            ColumnHeader nameHeader = new ColumnHeader();
            nameHeader.Text = "Name";
            this.lvRacersWatched.Columns.Add(nameHeader);
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = "Current Sensor";
            this.lvRacersWatched.Columns.Add(columnHeader);
            ColumnHeader timeHeader = new ColumnHeader();
            timeHeader.Text = "Current Sensor";
            this.lvRacersWatched.Columns.Add(timeHeader);

            DisplayWatched();

        }
        private void DisplayWatched()
        {
            this.lvRacersWatched.Items.Clear();
            
            foreach (KeyValuePair<int, Racer> racer in RacersWatched)
            {
                //Console.WriteLine(racer.Value.ToString());
                ListViewItem lvi = new ListViewItem(racer.Value.BIB.ToString());
                lvi.SubItems.Add(racer.Value.FirstName + racer.Value.LastName);
                lvi.SubItems.Add(racer.Value.Sensor.ToString());
                lvi.SubItems.Add(racer.Value.CurrentTime.ToString());
                this.lvRacersWatched.Items.Add(lvi);
                this.lvRacersWatched.View = View.Details;
            }
        }

        public void Update(Subject subject)
        {
            // Todo take in new state and set it
            Racer racer = subject as Racer;
            Console.WriteLine(racer.ToString());

            if (racer == null) return;

            RacersWatched[racer.BIB] = racer;

            DisplayWatched();

        }
        public void Subscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            racer.Subscribe(this);
            RacersWatched.Add(racer.BIB, racer);
            DisplayWatched();
        }
        public void Unsubscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            racer.Unsubscribe(this);
            RacersWatched.Remove(racer.BIB);
        }
    }
}
