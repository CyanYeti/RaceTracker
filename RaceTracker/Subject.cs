using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal abstract class Subject
    {
        private List<Observer> observers;
        public void Subscribe(Observer observer)
        {
            observers.Add(observer);
        }
    }
}
