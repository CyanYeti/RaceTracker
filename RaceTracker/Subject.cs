
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Subject
    {
        // Trey: Here is the parent subject class for observable classes
        // After struggling for a while I used a very similar structure to the BouncingBall
        private List<Observer> observers = new List<Observer>();
        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
        }
        public void Unsubscribe(Observer observer)  
        {
            observers.Remove(observer);
        }
        public void UnsubscribeAll()
        {
            observers.Clear();
        }
        public void Notify()
        {
            // This could be a pointer but this is a copy of the current state
            foreach(Observer observer in observers)
            {
                observer.Update(MemberwiseClone() as Subject);
            }
        }
    }
}

