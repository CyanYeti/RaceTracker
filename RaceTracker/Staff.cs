using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Staff : RaceViewer
    {
        public Staff(string name, string observerType = "staff") : base(name, observerType) { }
    }
}
