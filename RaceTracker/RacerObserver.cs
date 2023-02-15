using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class RacerObserver
    {
        // Type must be staff, support, or spectator
        // We need this as the Racer has to send each one updates at different times
        internal string Type { get; set; }
        public RacerObserver(Racer racer, string type)
        {
            Type = type;
            Subscribe(racer);
        }

        public void Update(int BIB, int position, int time)
        {
            // Todo take in new state and set it


        }
        private void Subscribe(Racer racer)
        {
            racer.Subscribe(this);
        }
        public void Unsubscribe(Racer racer)
        {
            racer.Unsubscribe(this);
        }
    }
}
