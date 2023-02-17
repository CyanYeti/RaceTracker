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
        // One master list of Racers. Only thing that changes any data in this is when a message comes in and updates a racer
        // This is not to allow observers to directly access racers, they only receive a Notify from from the UpdateRacer in the 
        // This is needed so that when a RacerObserver or the CheatingComputer subscribe to a racer they subscribe to the same object
        internal static readonly Tracker State = new Tracker();

        [STAThread]
        static void Main()
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
