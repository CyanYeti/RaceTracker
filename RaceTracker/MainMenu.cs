using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RaceTracker
{
    public partial class MainMenu : Form
    {
        // A concurrent queue gets the messages from the receiver for us to process.
        internal static ConcurrentQueue<RacerStatus> messageQueue = new ConcurrentQueue<RacerStatus>();
        private DataReceiver receiver;

        // Trey: MainMenu keeps all the observer forms here
        private Dictionary<string, RacerObserver> RacerWindows = new Dictionary<string, RacerObserver>();
        private Dictionary<string, CheaterObserver> CheaterWindows = new Dictionary<string, CheaterObserver>();
        private Observer SelectedObserver;

        private CheatingComputer CheaterComputer;

        // Internal only for testing
        internal readonly Tracker State;


        public MainMenu()
        {
            InitializeComponent();

            // Get the state using provide files or the defualts.
            string racersFilePath = "";
            string sensorsFilePath = "";
            string groupsFilePath = "";
            using (FileSelect fileSelect = new FileSelect(racersFilePath, sensorsFilePath, groupsFilePath))
            {
                var paths = fileSelect.ShowDialog();
                if (paths == DialogResult.OK)
                {
                    racersFilePath = fileSelect.FinalRacerPath;
                    sensorsFilePath = fileSelect.FinalSensorPath;
                    groupsFilePath = fileSelect.FinalGroupPath;
                }
            }

            // Get initial state from csvs and start cheating computer
            State = new Tracker(racersFilePath, sensorsFilePath, groupsFilePath);

            CheaterComputer = new CheatingComputer(State);


            // PUll in all racers into select box
            ColumnHeader bibHeader = new ColumnHeader();
            bibHeader.Text = "BIB";
            this.lvAllRacers.Columns.Add(bibHeader);
            ColumnHeader nameHeader = new ColumnHeader();
            nameHeader.Text = "Name";
            this.lvAllRacers.Columns.Add(nameHeader);
            foreach (KeyValuePair<int, Racer> racer in State.GetRacers() )
            {
                ListViewItem lvi = new ListViewItem(racer.Value.BIB.ToString());
                lvi.SubItems.Add(racer.Value.FirstName + " " + racer.Value.LastName);
                this.lvAllRacers.Items.Add(lvi);
                this.lvAllRacers.View = View.Details;
            }

            // Headers for the subscribed racers
            ColumnHeader bibHeaderSubscribed = new ColumnHeader();
            bibHeader.Text = "BIB";
            this.lvSubscribedRacers.Columns.Add(bibHeaderSubscribed);
            ColumnHeader nameHeaderSubscribed = new ColumnHeader();
            nameHeader.Text = "Name";
            this.lvSubscribedRacers.Columns.Add(nameHeaderSubscribed);
            this.lvSubscribedRacers.View = View.Details;


            // Populate observer types
            string[] observerTypes = { "spectator", "support", "big screen", "staff", "cheaters" };
            ColumnHeader observerHeader = new ColumnHeader();
            observerHeader.Text = "Select Option";
            this.lvObserverOptions.Columns.Add(observerHeader);
            foreach (string observerType in observerTypes)
            {
                ListViewItem item = new ListViewItem(observerType);
                this.lvObserverOptions.Items.Add(observerType);

            }
            this.lvObserverOptions.MultiSelect = false;
            this.lvObserverOptions.View = View.Details;

            // Set on change
            this.lvCreatedCheaters.SelectedIndexChanged += lvCreatedCheaters_SelectedIndexChanged;
            this.lvCreatedCheaters.GotFocus += lvCreatedCheaters_OnFocus;
            this.lvCreatedCheaters.MultiSelect = false;
            this.lvRacerObservers.SelectedIndexChanged += LvRacerObservers_SelectedIndexChanged;
            this.lvRacerObservers.GotFocus += lvRacerObservers_OnFocus;
            this.lvRacerObservers.MultiSelect = false;

            // Adding column headers to created boxes
            ColumnHeader observerName = new ColumnHeader();
            observerName.Text = "Name";
            this.lvRacerObservers.Columns.Add(observerName);
            this.lvCreatedCheaters.Columns.Add(observerName.Clone() as ColumnHeader);
            this.lvRacerObservers.View = View.Details;
            this.lvCreatedCheaters.View = View.Details;



            // Start the data receiver,
            receiver = new DataReceiver();
            receiver.Start();


            // Start cheating computer
            // The selected racers go straight into the observer. 
            // It could subscribe to racers, but we don't actually care about the racers state, just who they are (BIB)
            Dictionary<int, Racer> racersToWatch = new Dictionary<int, Racer>();
            string mainComputer = "MainComputer";

            CheaterObserver form = new CheaterObserver(mainComputer);
            foreach (KeyValuePair<int, Racer> racer in State.GetRacers())
            {
                form.AddRacerToWatch(racer.Value);
            }
            form.Subscribe(CheaterComputer);

            CheaterWindows.Add(mainComputer, form);
            this.lvCreatedCheaters.Items.Add(new ListViewItem(mainComputer));
            CheaterWindows[mainComputer].Show();


            // Start reading messages

            StartMessageTimer();

        }

        // Dequeue messages checks for new messages from the receiver
        private void dequeueMessages()
        {
            RacerStatus statusMessage;
            while (messageQueue.TryDequeue(out statusMessage))
            {
                State.UpdateRacer(statusMessage.RacerBibNumber, statusMessage.SensorId, statusMessage.Timestamp);
            }
        }


        private void btnCreateObserver_Click(object sender, EventArgs e)
        {
            // No createy with no selecty
            if(this.lvObserverOptions.SelectedItems == null) { return; }

            // Pull the type, TODO: Does the type matter besides for naming?
            string type = this.lvObserverOptions.SelectedItems[0].Text;



            if(type != "cheaters")
            {
                string observerName = type.ToString() + RacerWindows.Count.ToString();

                RacerObserver form = new RacerObserver(observerName);

                RacerWindows.Add(observerName, form);
                this.lvRacerObservers.Items.Add(new ListViewItem( observerName));
                RacerWindows[observerName].Show();
            }
            else
            {
                // The selected racers go straight into the observer. 
                // It could subscribe to racers, but we don't actually care about the racers state, just who they are (BIB)
                Dictionary<int, Racer> racersToWatch = new Dictionary<int, Racer>();
                string observerName = type.ToString() + CheaterWindows.Count.ToString();

                CheaterObserver form = new CheaterObserver(observerName);

                form.Subscribe(CheaterComputer);
                CheaterWindows.Add(observerName, form);
                this.lvCreatedCheaters.Items.Add(new ListViewItem(observerName));
                CheaterWindows[observerName].Show();

            }
        }

        // On close we make sure the receiver is stopped
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            receiver.Stop();
        }

        // Timer thread for checking for messages
        private int ReadMessageFrequency;
        private System.Windows.Forms.Timer MessageTimer = new System.Windows.Forms.Timer();

        private void StartMessageTimer()
        {
            if (ReadMessageFrequency == 0) { ReadMessageFrequency = 20; }
            MessageTimer.Interval = ReadMessageFrequency;
            MessageTimer.Tick += MessageTimer_Tick;
            MessageTimer.Start();
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            dequeueMessages();
        }

        private void SelectObserver(Observer observer)
        {
            if (observer == null) { return;}
            this.lvSubscribedRacers.Items.Clear();
            foreach(Racer racer in observer.GetSubjects())
            {
                if (racer == null) continue;
                ListViewItem lvi = new ListViewItem(racer.BIB.ToString());
                lvi.SubItems.Add(racer.FirstName + " " + racer.LastName);
                this.lvSubscribedRacers.Items.Add(lvi);
            }
            this.lblSubscribedRacers.Text = "Racers for " + observer.ObserverName;

            SelectedObserver = observer;
        }

        // When we select a racer or move focus we need to make sure we have the correct observer selected
        private void lvCreatedCheaters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lvCreatedCheaters.SelectedItems.Count == 0) return;
            SelectObserver(CheaterWindows[this.lvCreatedCheaters.SelectedItems[0].Text]);
        }
        private void LvRacerObservers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lvRacerObservers.SelectedItems.Count == 0) return;
            SelectObserver(RacerWindows[this.lvRacerObservers.SelectedItems[0].Text]);
        }
        private void lvCreatedCheaters_OnFocus(object sender, EventArgs e)
        {
            if (this.lvCreatedCheaters.SelectedItems.Count == 0) return;
            Console.Write(this.lvCreatedCheaters.SelectedItems);
            SelectObserver(CheaterWindows[this.lvCreatedCheaters.SelectedItems[0].Text]);
        }
        private void lvRacerObservers_OnFocus(object sender, EventArgs e)
        {
            if (this.lvRacerObservers.SelectedItems.Count == 0) return;
            SelectObserver(RacerWindows[this.lvRacerObservers.SelectedItems[0].Text]);
        }

        // On subscribe button, subscribe racer to the selected observer
        // Trey: Here is where the observer are subscribed to the selected racers
        private void btnSubscribeRacer_Click(object sender, EventArgs e)
        {
            if(SelectedObserver == null) return;
            foreach(ListViewItem racer in this.lvAllRacers.SelectedItems)
            {
                if (CheaterWindows.ContainsKey(SelectedObserver.ObserverName))
                {
                    CheaterWindows[SelectedObserver.ObserverName].AddRacerToWatch(State.GetRacer(Convert.ToInt32(racer.Text)));
                }
                else if (RacerWindows.ContainsKey(SelectedObserver.ObserverName))
                {
                    RacerWindows[SelectedObserver.ObserverName].Subscribe(State.GetRacer(Convert.ToInt32(racer.Text)));
                }
                this.lvSubscribedRacers.Items.Add(racer.Clone() as ListViewItem);
            }
        }

        private void btnUnsubscribeRacer_Click(object sender, EventArgs e)
        {
            if (SelectedObserver == null) return;
            foreach (ListViewItem racer in this.lvSubscribedRacers.SelectedItems)
            {
                if (CheaterWindows.ContainsKey(SelectedObserver.ObserverName))
                {
                    CheaterWindows[SelectedObserver.ObserverName].RemoveRacerToWatch(State.GetRacer(Convert.ToInt32(racer.Text)));
                }
                else if (RacerWindows.ContainsKey(SelectedObserver.ObserverName))
                {
                    RacerWindows[SelectedObserver.ObserverName].Unsubscribe(State.GetRacer(Convert.ToInt32(racer.Text)));
                }
                this.lvSubscribedRacers.Items.Remove(racer);
            }
        }

    }
}
