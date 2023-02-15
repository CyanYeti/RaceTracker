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
        private Dictionary<string, Spectator> spectators = new Dictionary<string, Spectator>();
        private Dictionary<string, Support> supports = new Dictionary<string, Support>();
        private Dictionary<string, Staff> staffs = new Dictionary<string, Staff>();
        private Dictionary<string, BigScreen> bigscreens = new Dictionary<string, BigScreen>();
        private Tracker RTracker = new Tracker();
        public MainMenu()
        {
            InitializeComponent();

            // PUll in all racers into select box
            foreach (KeyValuePair<int, Racer> racer in RTracker.GetRacers() )
            {
                this.lbAllRacers.Items.Add(racer.Value.toString());
            }

            // Populate observer types
            string[] observerTypes = { "spectator", "support", "big screen", "staff" };
            foreach (string observerType in observerTypes)
            {
                this.lbObserverTypes.Items.Add(observerType);
            }

            // Passing the data storage class Tracker by reference
            receiver = new DataReceiver(ref RTracker);
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

        // Trey: Here I am using a factory pattern to create the diffrent types of viewers and add them to the correct list
        private void addViewer<TChild>(string type, Dictionary<string, TChild> viewers) where TChild : RaceViewer
        {
            string observerName = this.txtObserverName.Text.ToString();
            if(viewers.ContainsKey(observerName))
            {
                this.txtObserverName.Text = "Name Exists";
                return;
            }
            viewers.Add(observerName, (TChild)ViewerFactory.Creator(type, observerName));
            Console.WriteLine(viewers);
            foreach (string racer in this.lbSelectedRacers.SelectedItems)
            {
                viewers[observerName].Subscribe(RTracker.getRacer(getBIB(racer)));
            }
            Console.WriteLine(viewers[observerName].getName());
            lbCreatedObservers.Items.Add(viewers[observerName].getName());
        }

        private void btnCreateObserver_Click(object sender, EventArgs e)
        {
            string type = this.lbObserverTypes.SelectedItem.ToString();
            type = type.ToLower().Replace(" ", "");
            switch (type)
            {
                case "spectator":
                    addViewer(type, spectators);
                    break;
                case "support":
                    addViewer(type, supports);
                    break;
                case "bigscreen":
                    Console.WriteLine("Adding viewer");
                    addViewer(type, bigscreens);
                    break;
                case "staff":
                    addViewer(type, staffs);
                    break;
            }

        }

    }
}
