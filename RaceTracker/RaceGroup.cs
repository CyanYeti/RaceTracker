using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RaceTrackerUnitTests")]
namespace RaceTracker
{
    internal class RaceGroup
    {
        internal int Id { get; set; }
        internal string Label { get; set; }
        internal int RacerCount { get; set; }
        internal List<int> BIBNumbers = new List<int>();
        internal int BIBStart;
        internal int BIBEnd;
        internal int BlockStartTime { get; set; }
        public RaceGroup(int id, string label, int blockStartTime, int bibStart, int bibEnd)
        {
            Id = id;
            Label = label;
            BlockStartTime= blockStartTime;
            BIBStart = bibStart;
            BIBEnd = bibEnd;
        }
    }
}
