using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
[assembly: InternalsVisibleTo("RaceTrackerUnitTests")]

namespace RaceTracker
{
    // Trey: Here is the racer observer wich watches the selected racers and displays their current status.
    internal partial class RacerObserver : Form, Observer
    {
        internal readonly Dictionary<int, Racer> RacersWatched = new Dictionary<int, Racer>();
        private bool RefreshNeeded;
        private readonly Timer refreshTimer = new Timer();
        public int RefreshFrequency { get; set; }
        private readonly object myLock = new object();


        public string ObserverName { get; }

        public RacerObserver(string name)
        {
            InitializeComponent();

            this.Text  = name;
            ObserverName = name;
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
            this.lvRacersWatched.View = View.Details;
            this.Load += RacerObserver_Load;
            lock (myLock)
            {
                DisplayWatched();
            }

        }
        private void DisplayWatched()
        {
            this.lvRacersWatched.Items.Clear();
            
            foreach (KeyValuePair<int, Racer> racer in RacersWatched)
            {
                //Console.WriteLine(racer.Value.ToString());
                ListViewItem lvi = new ListViewItem(racer.Value.BIB.ToString());
                lvi.SubItems.Add(racer.Value.LastName + ", " + racer.Value.FirstName);
                lvi.SubItems.Add(racer.Value.Sensor.ToString());
                lvi.SubItems.Add(TimeSpan.FromMilliseconds(racer.Value.CurrentTime).ToString());
                this.lvRacersWatched.Items.Add(lvi);
                this.lvRacersWatched.View = View.Details;
            }
        }

        // Trey: Here are the implementations of the observer functions
        public void Update(Subject subject)
        {
            Racer racer = subject as Racer;

            if (racer == null) return;
            lock (myLock)
            {

                RacersWatched[racer.BIB] = racer;
            }


            RefreshNeeded = true;
        }
        public void Subscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            lock (myLock)
            {
                racer.Subscribe(this);
                RacersWatched.Add(racer.BIB, racer);
            }

            RefreshNeeded = true;
        }
        public void Unsubscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            lock (myLock)
            {
                racer.Unsubscribe(this);
                RacersWatched.Remove(racer.BIB);
            }
            RefreshNeeded = true;
        }
        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            foreach(KeyValuePair<int, Racer> kvp in RacersWatched)
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
            refreshTimer.Interval= RefreshFrequency;
            refreshTimer.Tick += refreshTimer_Tick;
            refreshTimer.Start();
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (!RefreshNeeded) return;
            lock (myLock)
            {
                DisplayWatched();
            }
            RefreshNeeded = false;
        }
    }
}
