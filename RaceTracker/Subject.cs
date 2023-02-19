
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("RaceTrackerUnitTests")]
namespace RaceTracker
{
    internal class Subject
    {
        // Trey: Here is the parent subject class for observable classes
        // After struggling for a while I used a very similar structure to the BouncingBall
        internal List<Observer> observers = new List<Observer>();
        private readonly object myLock = new object();
        public void Subscribe(Observer observer)
        {
            lock (myLock)
            {
                if(observer != null && !observers.Contains(observer))
                {
                    observers.Add(observer);
                }
            }
        }
        public void Unsubscribe(Observer observer)  
        {
            lock (myLock)
            {
                if (!observers.Contains(observer)) return;
                observers.Remove(observer);
            }
        }
        public void UnsubscribeAll()
        {
            lock (myLock)
            {
                observers.Clear();
            }
        }
        public void Notify()
        {
            lock (myLock)
            {
                // This could be a pointer but this is a copy of the current state
                foreach(Observer observer in observers)
                {
                    observer.Update(MemberwiseClone() as Subject);
                }
            }
        }
    }
}

