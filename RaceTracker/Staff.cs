using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Staff : RacerObserverOld
    {
        public Staff(string name, string observerType = "staff") : base(observerType) { }
    }
}
