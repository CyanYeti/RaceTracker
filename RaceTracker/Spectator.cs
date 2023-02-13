using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Spectator
    {
        List<Observer> Subscriptions = new List<Observer>();
        string Name { get; set; }
        public Spectator() { }
        public void Subscribe(Racer racer)
        {
            Observer watcher = new Observer(racer, "spectator");
            Subscriptions.Add(watcher);
        }
    }
}
