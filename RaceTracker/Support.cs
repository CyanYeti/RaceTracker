using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Support : RacerObserver
    {
        public Support(string name, string observerType = "support") : base(observerType) { }
    }
}
