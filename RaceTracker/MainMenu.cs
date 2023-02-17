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
        private Dictionary<string, Form> ObserverWindows = new Dictionary<string, Form>();
        private CheatingComputer CheaterComputer = new CheatingComputer();
        
        public MainMenu()
        {
            InitializeComponent();

            // PUll in all racers into select box
            foreach (KeyValuePair<int, Racer> racer in Program.State.GetRacers() )
            {
                this.lbAllRacers.Items.Add(racer.Value.ToString());
            }

            // Populate observer types
            string[] observerTypes = { "spectator", "support", "big screen", "staff", "cheaters" };
            foreach (string observerType in observerTypes)
            {
                this.lbObserverTypes.Items.Add(observerType);
            }

            // Start the data receiver,
            receiver = new DataReceiver();
            receiver.Start();


            // Start cheating computer

            
            // For now just read a line from the console 
            //string tmp = Console.ReadLine();

        }

        private void dequeueMessages()
        {
            RacerStatus statusMessage;
            while (messageQueue.TryDequeue(out statusMessage))
            {
                Program.State.UpdateRacer(statusMessage.RacerBibNumber, statusMessage.SensorId, statusMessage.Timestamp);
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



            if(type != "cheaters")
            {
                RacerObserver form = new RacerObserver(observerName);

                foreach (string racer in this.lbSelectedRacers.Items)
                {
                    form.Subscribe(Program.State.GetRacer(getBIB(racer)));
                }
                ObserverWindows.Add(observerName, form as Form);

            }
            else
            {
                // The selected racers go straight into the observer. 
                // It could subscribe to racers, but we don't actually care about the racers state, just who they are (BIB)
                Dictionary<int, Racer> racersToWatch = new Dictionary<int, Racer>();

                foreach (string racer in this.lbSelectedRacers.Items)
                {
                    racersToWatch.Add(getBIB(racer), Program.State.GetRacer(getBIB(racer)));
                }
                CheaterObserver form = new CheaterObserver(observerName, racersToWatch);

                form.Subscribe(CheaterComputer);
                ObserverWindows.Add(observerName, form as Form);
            }


            lbCreatedObservers.Items.Add(observerName);
            ObserverWindows[observerName].Show();


        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            receiver.Stop();
        }

        private int ReadMessageFrequency;
        private System.Windows.Forms.Timer MessageTimer = new System.Windows.Forms.Timer();

        private void btnStartRace_Click(object sender, EventArgs e)
        {
            // Open simulator before start
            //dequeueMessages();
            //System.Threading.Timer newMessages = new System.Threading.Timer(dequeueMessages, null, 0, 20);
            if (ReadMessageFrequency== 0) { ReadMessageFrequency = 20; }
            MessageTimer.Interval = ReadMessageFrequency;
            MessageTimer.Tick += MessageTimer_Tick;
            MessageTimer.Start();

        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            dequeueMessages();
        }
    }
}
