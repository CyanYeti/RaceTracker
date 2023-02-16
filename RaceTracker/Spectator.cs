using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Spectator : RacerObserverOld
    {
        public Spectator(string name, string observerType = "support") : base(observerType) { }
    }
}
