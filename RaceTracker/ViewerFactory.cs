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
        public static RacerObserverOld Creator(string type, string name) 
        { 
            switch(type)
            {
                case "support":
                    return new RacerObserverOld(name);
                case "spectator":
                    return new RacerObserverOld(name);
                case "bigscreen":
                    return new RacerObserverOld(name);
                case "staff":
                    return new RacerObserverOld(name);
                case "cheaters":
                    break;
            }   
            return null;
        }
    }
}
