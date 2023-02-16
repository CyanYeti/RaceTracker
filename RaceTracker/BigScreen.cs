using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class BigScreen : RacerObserver
    {
        public BigScreen(string name, string observerType = "big screen") : base(observerType) { }
    }
}
