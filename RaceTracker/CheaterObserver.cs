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
    internal partial class CheaterObserver : Form, Observer
    {
        private Dictionary<int, Racer> RacersWatched = new Dictionary<int, Racer>();
        private Dictionary<int, Racer> CheatersFound = new Dictionary<int, Racer>();
        private bool RefreshNeeded;
        private readonly Timer refreshTimer = new Timer();
        public int RefreshFrequency { get; set; }
        public CheaterObserver(string name, Dictionary<int, Racer> cheatersToWatchFor)
        {
            InitializeComponent();

            RacersWatched = cheatersToWatchFor;

            this.Text = name;
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
            this.Load += RacerObserver_Load;

            DisplayWatched();
        }

        private void DisplayWatched()
        {
            this.lvRacersWatched.Items.Clear();
            this.lvRacersWatched.Items.Add(new ListViewItem("test"));
            foreach (KeyValuePair<int, Racer> racer in CheatersFound)
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

        // Check if any of the racers we care about are in the cheating computers new state
        public void Update(Subject subject)
        {
            CheatingComputer cheaters = subject as CheatingComputer;

            if (cheaters == null) return;
            foreach(Racer racer in cheaters.Cheaters) Console.WriteLine(racer.ToString());

            // If one of the racers we care about cheats, add it to our list of cheats to display
            //cheaters.Cheaters.Contains(racer.Value) && 
            foreach (KeyValuePair<int, Racer> racer in cheaters.Cheaters)
            {
                if (!CheatersFound.ContainsKey(racer.Key))
                {
                    CheatersFound.Add(racer.Key, racer.Value);
                }
            }

            RefreshNeeded = true;
        }

        // All we do is subscribe to the cheating computer, nothing else
        public void Subscribe(Subject subject)
        {
            CheatingComputer cheaters = subject as CheatingComputer;
            cheaters.Subscribe(this);
            RefreshNeeded = true;
        }
        public void Unsubscribe(Subject subject)
        {
            CheatingComputer cheaters = subject as CheatingComputer;
            cheaters.Unsubscribe(this);
            RefreshNeeded = true;
        }

        private void RacerObserver_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Loaded");
            StartRefreshTimer();
        }
        private void StartRefreshTimer()
        {
            if (RefreshFrequency <= 0) RefreshFrequency = 50;
            refreshTimer.Interval = RefreshFrequency;
            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Start();
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (!RefreshNeeded) return;
            DisplayWatched();
            RefreshNeeded = false;
        }
    }
}
