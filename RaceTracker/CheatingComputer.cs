using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("RaceTrackerUnitTests")]

namespace RaceTracker
{
    internal class CheatingComputer : Subject, Observer
    {
        internal List<Racer> Cheaters = new List<Racer>();
        internal List<Racer> CheatedWith = new List<Racer>();
        private string Name;
        private readonly object myLock = new object();

        private List<Racer> RacersWatched = new List<Racer>();

        string Observer.ObserverName => "Main Cheating Computer";

        public CheatingComputer()
        {
            // For every racer, subscribe to them
            foreach (KeyValuePair<int, Racer> racer in Program.State.GetRacers())
            {
                Subscribe(racer.Value);
            }
        }
        
        private void AddCheater(Racer cheater, Racer cheaterWith)
        {
            Cheaters.Add(cheater);
            CheatedWith.Add(cheaterWith);
            Notify(); // Send me to observers
        }

        // Update, Subscribe, Unsubscribe as this is an observer
        // Trey: The cheaters seem to finding the same right ones as far as I can tell. It does swap the order of some of the cheaters in the list though
        public void Update(Subject subject)
        {
            Racer racer = subject as Racer;

            // Test if they are cheating
            foreach (KeyValuePair<int, Racer> otherRacer in Program.State.GetRacers())
            {
                // If this is the first sensor for either racer, we don't have the data to know
                if (racer.Sensor == 0 || otherRacer.Value.Sensor== 0) { continue; }
                // if the two racers are not at the same sensor we don't check them, we will once the other one has caught up
                if (otherRacer.Value.Sensor != racer.Sensor) { continue; }
                // Skip if it is us
                if (otherRacer.Key == racer.BIB) { continue; }
                // Skip if they are in our group
                if (otherRacer.Value.getRaceGroup().Id == racer.getRaceGroup().Id) { continue; }
                // If they are at the same sensor and the sensor before within 3 seconds of each other they are cheating
                if (Math.Abs( otherRacer.Value.Progress[racer.Sensor] - racer.Progress[racer.Sensor]) < 3000 && Math.Abs(otherRacer.Value.Progress[racer.Sensor - 1] - racer.Progress[racer.Sensor - 1]) < 3000)
                {
                    lock (myLock)
                    {
                        if (Cheaters.Contains(racer)) { continue; }
                        if (!AlreadyCheatedPair(racer, otherRacer.Value))
                        {
                            AddCheater(racer, otherRacer.Value);
                        }
                    }
                    
                }
                
            }

        }

        // Makes sure there are no duplicate pairs in the cheating computer.
        private bool AlreadyCheatedPair(Racer cheater, Racer cheatedWith)
        {
            for (int i = 0; i < Cheaters.Count; i++)
            {
                if (Cheaters[i].BIB == cheater.BIB && CheatedWith[i].BIB == cheatedWith.BIB)
                {
                    return true;
                }
                if (Cheaters[i].BIB == cheatedWith.BIB && CheatedWith[i].BIB == cheater.BIB)
                {
                    return true;
                }
            }
           
            return false;
        }
        public void Subscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            RacersWatched.Add(racer);
            racer.Subscribe(this);
        }
        public void Unsubscribe(Subject subject)
        {
            return; //Cheating computer needs to track all racers, never unsubscribes
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            foreach (Racer racer in RacersWatched)
            {
                subjects.Add(racer as Subject);
            }
            return subjects;
        }
    }
}
