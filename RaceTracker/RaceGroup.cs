using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class RaceGroup
    {
        private int Id { get; set; }
        private string Label { get; set; }
        private int RacerCount { get; set; }
        private List<int> BIBNumbers = new List<int>();
        private int BIBStart;
        private int BIBEnd;
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
