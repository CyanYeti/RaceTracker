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
        private List<Racer> CheatersFound = new List<Racer>();
        private List<Racer> CheatedWith = new List<Racer>();
        private bool RefreshNeeded;
        private readonly Timer refreshTimer = new Timer();
        private readonly object mylock = new object();
        public int RefreshFrequency { get; set; }

        public string ObserverName { get; }

        public CheaterObserver(string name)
        {
            InitializeComponent();


            this.Text = name;
            ObserverName = name;

            // Add Columns to main cheaters
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

            // Add Columns to cheated with
            this.lvCheatedWith.Columns.Add(bibHeader.Clone() as ColumnHeader);
            this.lvCheatedWith.Columns.Add(nameHeader.Clone() as ColumnHeader);
            this.lvCheatedWith.Columns.Add(columnHeader.Clone() as ColumnHeader);
            this.lvCheatedWith.Columns.Add(timeHeader.Clone() as ColumnHeader);
            // Start update timer/thread on load
            this.Load += RacerObserver_Load;

            lock (mylock)
            {
                DisplayWatched();
            }
        }

        private void DisplayWatched()
        {
            this.lvRacersWatched.Items.Clear();
            this.lvCheatedWith.Items.Clear();
            foreach (Racer racer in CheatersFound)
            {
                ListViewItem lvi = new ListViewItem(racer.BIB.ToString());
                lvi.SubItems.Add(racer.LastName + ", " + racer.FirstName);
                lvi.SubItems.Add(racer.Sensor.ToString());
                lvi.SubItems.Add(TimeSpan.FromMilliseconds(racer.CurrentTime).ToString());
                this.lvRacersWatched.Items.Add(lvi);
                this.lvRacersWatched.View = View.Details;
            }
            foreach (Racer racer in CheatedWith)
            {
                ListViewItem lvi = new ListViewItem(racer.BIB.ToString());
                lvi.SubItems.Add(racer.LastName + ", " + racer.FirstName);
                lvi.SubItems.Add(racer.Sensor.ToString());
                lvi.SubItems.Add(TimeSpan.FromMilliseconds(racer.CurrentTime).ToString());
                this.lvCheatedWith.Items.Add(lvi);
                this.lvCheatedWith.View = View.Details;
            }
        }

        // Check if any of the racers we care about are in the cheating computers new state
        public void Update(Subject subject)
        {
            CheatingComputer cheaterComp = subject as CheatingComputer;

            if (cheaterComp == null) return;

            // If one of the racers we care about cheats, add it to our list of cheats to display
            //cheaters.Cheaters.Contains(racer.Value) && 
            List<Racer> cheaters = cheaterComp.Cheaters;
            List<Racer> cheatedWith = cheaterComp.CheatedWith;

            CheatersFound.Clear();
            CheatedWith.Clear();

            lock (mylock)
            {
                for (int i = 0; i < cheaters.Count; i++)
                {
                    if (RacersWatched.ContainsKey(cheaters[i].BIB))
                    {
                        CheatersFound.Add(cheaters[i]);
                        CheatedWith.Add(cheatedWith[i]);
                    }
                }
            }

            RefreshNeeded = true;
        }

        // All we do is subscribe to the cheating computer, nothing else
        public void Subscribe(Subject subject)
        {
            lock (mylock)
            {
                CheatingComputer cheaters = subject as CheatingComputer;
                cheaters.Subscribe(this);
            }
            RefreshNeeded = true;
        }
        public void Unsubscribe(Subject subject)
        {
            lock (mylock)
            {
                CheatingComputer cheaters = subject as CheatingComputer;
                cheaters.Unsubscribe(this);
            }
            RefreshNeeded = true;
        }

        public void AddRacerToWatch(Racer racer)
        {
            RacersWatched.Add(racer.BIB, racer);
        }
        public void RemoveRacerToWatch(Racer racer)
        {
            RacersWatched.Remove(racer.BIB);
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            foreach (KeyValuePair<int, Racer> kvp in RacersWatched)
            {
                subjects.Add(kvp.Value as Subject);
            }
            return subjects;
        }

        private void RacerObserver_Load(object sender, EventArgs e)
        {
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
            lock (mylock)
            {
                DisplayWatched();
                RefreshNeeded = false;
            }
        }

    }
}
