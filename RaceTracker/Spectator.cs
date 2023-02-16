using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Spectator : RacerObserver
    {
        public Spectator(string name, string observerType = "support") : base(observerType) { }
    }
}
