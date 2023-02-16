using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class RacerObserverOld : Observer
    {
        // TODO: This needs to be a form
        // Type must be staff, support, or spectator
        // We need this as the Racer has to send each one updates at different times
        // int key is BIB number
        Dictionary<int, Racer> RacersWatched = new Dictionary<int, Racer>();
        internal string Type { get; set; }
        public RacerObserverOld(string type)
        {
            Type = type;
        }

        public void Update(Subject subject)
        {
            // Todo take in new state and set it
            Racer racer = subject as Racer;
            if (racer == null) return;

            RacersWatched[racer.BIB] = racer;

        }
        public void Subscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            racer.Subscribe(this);
            RacersWatched.Add(racer.BIB, racer);
        }
        public void Unsubscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            racer.Unsubscribe(this);
            RacersWatched.Remove(racer.BIB);
        }
    }
}
