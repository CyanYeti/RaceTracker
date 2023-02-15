using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class CheatingComputer
    {
        Tracker CurrentState = new Tracker();
        List<Racer> Cheaters = new List<Racer>();
        Dictionary<int, Racer> Racers = new Dictionary<int, Racer>();
        List<RacerObserver> RacerObservers = new List<RacerObserver>();
        public CheatingComputer(Tracker startingState)
        {
            CurrentState = startingState;

            // For every racer, subscribe to them
            foreach(KeyValuePair<int, Racer> racer in PreviousState.GetRacers().ToList())
            {
                RacerObservers.Add(new RacerObserver(racer.Value, "cheatercomputer"));
            }
        } 
        public void SetState(Tracker state) { CurrentState= state; }
        public void SetState(int BIB, int position, int time)
        {
            CurrentState.UpdateRacer(BIB, position, time);
        }
    }
}
