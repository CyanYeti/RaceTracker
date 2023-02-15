using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class RaceViewer
    {
        List<RacerObserver> Subscriptions = new List<RacerObserver>();
        private string Name;
        private string ObserverType;
        public RaceViewer(string name, string observerType)
        {
            Name = name;
            ObserverType = observerType;
        }
        public void Subscribe(Racer racer)
        {
            RacerObserver watcher = new RacerObserver(racer, ObserverType);
            Subscriptions.Add(watcher);
        }
        public string getName() { return Name; }
    }
}
