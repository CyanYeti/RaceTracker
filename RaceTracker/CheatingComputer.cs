using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class CheatingComputer : Subject, Observer
    {
        internal List<Racer> Cheaters = new List<Racer>();

        public CheatingComputer()
        {
            // For every racer, subscribe to them
            foreach (KeyValuePair<int, Racer> racer in Program.State.GetRacers())
            {
                Subscribe(racer.Value);
            }
        }
        private void AddCheater(Racer racer)
        {
            Cheaters.Add(racer);
            Notify(); // Send me to observers
        }

        // Update, Subscribe, Unsubscribe as this is an observer
        public void Update(Subject subject)
        {
            Racer racer = subject as Racer;

            // Test if they are cheating
            // Cheating flag, if they cheat with anyone then they are marked a cheater
            bool cheating = false;
            foreach (KeyValuePair<int, Racer> otherRacers in Program.State.GetRacers())
            {
                // If this is the first sensor for either racer, we don't have the data to know
                if (racer.Sensor == 0 || otherRacers.Value.Sensor== 0) { continue; }
                // if the two racers are not at the same sensor we don't check them, we will once the other one has caught up
                if (otherRacers.Value.Sensor != racer.Sensor) { continue; }
                // Skip if it is us
                if (otherRacers.Key == racer.BIB) { continue; }
                // Skip if they are in our group
                if (otherRacers.Value.getRaceGroup().Id == racer.getRaceGroup().Id) { continue; }
                // If they are at the same sensor and the sensor before within 3 seconds of each other they are cheating
                /*
                Console.WriteLine("Others progress:");
                foreach(KeyValuePair<int, int> sensor in otherRacers.Value.Progress) Console.WriteLine("{0}, {1},{2}", sensor.Key, sensor.Value, otherRacers.Value.Sensor);

                Console.WriteLine("My progress:");
                foreach (KeyValuePair<int, int> sensor in racer.Progress) Console.WriteLine("{0}, {1}, {2}", sensor.Key, sensor.Value, racer.Sensor);
                */
                if (Math.Abs( otherRacers.Value.Progress[racer.Sensor] - racer.Progress[racer.Sensor]) < 3000 && Math.Abs(otherRacers.Value.Progress[racer.Sensor - 1] - racer.Progress[racer.Sensor - 1]) < 3000)
                {
                    //Console.WriteLine("Cheater {0}", racer.BIB);
                    cheating = true;
                }
                
            }
            if (cheating) { AddCheater(racer); }

        }
        public void Subscribe(Subject subject)
        {
            Racer racer = subject as Racer;
            racer.Subscribe(this);
            // We all ready subscribe to everything, don't need to track
        }
        public void Unsubscribe(Subject subject)
        {
            return; //Cheating computer needs to track all racers, never unsubscribes
        }

    }
}
