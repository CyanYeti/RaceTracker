using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Racer
    {
        private string Name { get; set; }
        private string Birthday { get; set; }
        private RaceGroup RacerGroup { get; set; }
        private int BIB { get; set; }
        private int FinishTime { get; set; }
        private int StartTime { get; set; }
        List<Observer> Subscribers = new List<Observer>();
        private int position { get; set; }

        public Racer(string name, string birthday, RaceGroup raceGroup, int bib, int finish = -1)
        {
            Name = name;
            Birthday = birthday;
            RacerGroup = raceGroup;
            BIB = bib;
            StartTime = -1; //TODO Based on race group start

        }

        public void Update()
        {
            // TODO Take in things that update and send it to observers
            // Send info every 5 minutes or major position changes +- 3 positions, or when they enter 1st or 2nd of their block
            // Staff can change email message 
            foreach (Observer sub in Subscribers)
            {
                sub.Update();
            }
        }
        public void Subscribe(Observer watcher)
        {
            Subscribers.Add(watcher);
        }
    }
}
