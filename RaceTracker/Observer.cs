using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal interface Observer
    {
        void Update(Subject subject);
        void Subscribe(Subject subject);
        void Unsubscribe(Subject subject);
    }
}
