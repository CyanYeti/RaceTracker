using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Thread uiThread = new Thread (new ThreadStart (LaunchDisplay));
            uiThread.Start();
            // This dummy server receives RacerStatus Messages from the simulator
            // and simply prints them to the screen
            

            DataReceiver receiver = new DataReceiver();
            receiver.Start();

            List<List<string>> groupsData = CSVParser.ParseCSV("Groups.csv");

            // Group ID is the groups key
            Dictionary<int, RaceGroup> groups = new Dictionary<int, RaceGroup>();
            foreach(List<string> group in groupsData)
            {
                groups.Add(Convert.ToInt32(group[0]), new RaceGroup(Convert.ToInt32(group[0]), group[1], Convert.ToInt32(group[2]), Convert.ToInt32(group[3]), Convert.ToInt32(group[4])));
            }

            List<List<string>> racersData = CSVParser.ParseCSV("Racers.csv");
            // BIB number is the racer key
            Dictionary<int, Racer> racers = new Dictionary<int, Racer>();
            foreach(List<string> racer in racersData)
            {
                racers.Add(Convert.ToInt32(racer[2]), new Racer(racer[0], racer[1], Convert.ToInt32(racer[2]), groups[Convert.ToInt32(racer[3]) - 1]));
            }

            // For now just read a line from the console 
            //string tmp = Console.ReadLine();

            // Wait for display to be close, clean up receiver thread
            while (uiThread.IsAlive);
            receiver.Stop();

        }
        static void LaunchDisplay()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
        }
    }
}

/* TODO:
 * Copy over needed sensor simulator code, basically call it up.
 * Create a list of racers
 * Spectators, Support, and Staff need to be able to select multiple racers to subscribe to
 * 
 * Email is to a txt file.
 * 
 * Cheating detection
 * 
 * Multithread?
 * 
 * 
 * Test
 * UML
 * 
 * 
 * 
 */
