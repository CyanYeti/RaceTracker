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

        [STAThread]
        static void Main()
        {
            // MainMenu handles everything
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());

        }

    }
}