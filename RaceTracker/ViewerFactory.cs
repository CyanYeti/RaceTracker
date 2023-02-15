using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class ViewerFactory
    {
        // Trey: Here is the simple factory to make the right type of viewer
        public static RaceViewer Creator(string type, string name) 
        { 
            switch(type)
            {
                case "support":
                    return new Support(name);
                case "spectator":
                    return new Spectator(name);
                case "bigscreen":
                    Console.WriteLine("In Factory");
                    return new BigScreen(name);
                case "staff":
                    return new Staff(name);
            }
            return null;
        }
    }
}
