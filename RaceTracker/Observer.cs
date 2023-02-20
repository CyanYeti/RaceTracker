using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    // Trey: This is the "abstract" observer. It is an interface as cheating computer needs to be both observer and subject, so one needs to be an interface.
    internal interface Observer
    {
        string ObserverName { get;  }
        void Update(Subject subject);
        void Subscribe(Subject subject);
        void Unsubscribe(Subject subject);
        List<Subject> GetSubjects();
    }
}
