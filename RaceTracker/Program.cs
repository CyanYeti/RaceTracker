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
            /*
            Tracker Rtracker = new Tracker();

            Thread uiThread = new Thread (new ThreadStart (LaunchDisplay));
            uiThread.Start();
            // This dummy server receives RacerStatus Messages from the simulator
            


            // Passing the data storage class Tracker by reference
            DataReceiver receiver = new DataReceiver(ref Rtracker);
            receiver.Start();

            // For now just read a line from the console 
            //string tmp = Console.ReadLine();

            // Wait for display to be close, clean up receiver thread
            while (uiThread.IsAlive);
            receiver.Stop();
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

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
 * Test
 * UML
 */
