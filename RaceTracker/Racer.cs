using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    // Trey: Racer is a subject that can be observed
    internal class Racer : Subject
    {
        internal string FirstName;
        internal string LastName;
        internal RaceGroup RacerGroup;
        internal readonly int BIB;
        internal int FinishTime;
        internal int StartTime;
        internal int Sensor;
        internal Dictionary<int, int> Progress = new Dictionary<int, int>();
        internal int CurrentTime;  

        public Racer(string firstname, string lastname, int bib, RaceGroup raceGroup, int finish = -1)
        {
            FirstName = firstname;
            LastName = lastname;
            RacerGroup = raceGroup;
            BIB = bib;
            StartTime = RacerGroup.BlockStartTime;

        }

        // Update racer state and notify subscribers
        public void UpdateRacerState(int position, int time)
        {
            Progress.Add(position, time);
            Sensor = position;
            CurrentTime = time;
            // Send info every 5 minutes or major position changes +- 3 positions, or when they enter 1st or 2nd of their block
            Notify();
        }

        public RaceGroup getRaceGroup() { return RacerGroup; }
    }
}
