using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class RaceGroup
    {
        private string Label { get; set; }
        private int RacerCount { get; set; }
        private List<int> BIBNumbers = new List<int>();
        internal int BlockStartTime { get; set; }
    }
}
