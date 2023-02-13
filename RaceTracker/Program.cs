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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread uiThread = new Thread (new ThreadStart (LaunchDisplay));
            uiThread.Start();
            // This dummy server receives RacerStatus Messages from the simulator
            // and simply prints them to the screen
            

            DataReceiver receiver = new DataReceiver();
            receiver.Start();
            // For now just read a line from the console 
            string tmp = Console.ReadLine();
            //receiver.Stop();

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
 * 
 * 
 * 
 * 
 */
