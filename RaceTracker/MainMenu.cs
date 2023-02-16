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
        internal static ConcurrentQueue<RacerStatus> messageQueue = new ConcurrentQueue<RacerStatus>();
        private DataReceiver receiver;
        private Dictionary<string, RacerObserver> ObserverWindows = new Dictionary<string, RacerObserver>();
        private Tracker StartingState = new Tracker();

        public MainMenu()
        {
            InitializeComponent();

            // PUll in all racers into select box
            foreach (KeyValuePair<int, Racer> racer in StartingState.GetRacers() )
            {
                this.lbAllRacers.Items.Add(racer.Value.toString());
            }

            // Populate observer types
            string[] observerTypes = { "spectator", "support", "big screen", "staff", "cheaters" };
            foreach (string observerType in observerTypes)
            {
                this.lbObserverTypes.Items.Add(observerType);
            }

            // Passing the data storage class Tracker by reference
            receiver = new DataReceiver();
            receiver.Start();

            
            // For now just read a line from the console 
            //string tmp = Console.ReadLine();

        }

        private void dequeueMessages()
        {
            RacerStatus statusMessage;
            while (messageQueue.TryDequeue(out statusMessage))
            {
                //Console.WriteLine(statusMessage.ToString());
                StartingState.UpdateRacer(statusMessage.RacerBibNumber, statusMessage.SensorId, statusMessage.Timestamp);

            }
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


        private void btnCreateObserver_Click(object sender, EventArgs e)
        {
            if(this.lbObserverTypes.SelectedItem == null) { return; }
            string type = this.lbObserverTypes.SelectedItem.ToString();
            string observerName = type.ToString() + ObserverWindows.Count.ToString();

            RacerObserver form = new RacerObserver(observerName);

            ObserverWindows.Add(observerName, new RacerObserver(observerName));

            foreach (string racer in this.lbSelectedRacers.Items)
            {
                ObserverWindows[observerName].Subscribe(StartingState.getRacer(getBIB(racer)));
            }

            lbCreatedObservers.Items.Add(observerName);
            ObserverWindows[observerName].Show();


        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            receiver.Stop();
        }

        private void btnStartRace_Click(object sender, EventArgs e)
        {
            // Open simulator before start
            while (true)
            {
                dequeueMessages();
            }
            //System.Threading.Timer newMessages = new System.Threading.Timer(dequeueMessages, null, 20, 20);

        }
    }
}
