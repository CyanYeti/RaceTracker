using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("RaceTrackerUnitTests")]

namespace RaceTracker
{
    // This is primarily a storage object seen around the code as State. This is the master list of racers, groups and sensors
    // When a message is received, the message updates the racer in here. That update is dispersed from the racer to all of its 
    // subscribers through its update function. On thing I was confused on in this assignment was how c# kept tracker of different 
    // objects when I believe it passes by value and pass by reference doesn't seem to be needed.
    internal class Tracker
    {
        private Dictionary<int, Racer> Racers = new Dictionary<int, Racer>();
        private Dictionary<int, RaceGroup> Groups = new Dictionary<int, RaceGroup>();
        private Dictionary<int, int> Sensors = new Dictionary<int, int>(); 
        public Tracker(string racerPath, string sensorPath, string groupPath)
        {
            List<List<string>> groupsData = CSVParser.ParseCSV(groupPath);
            // Group ID is the groups key
            foreach (List<string> group in groupsData)
            {
                Groups.Add(Convert.ToInt32(group[0]), new RaceGroup(Convert.ToInt32(group[0]), group[1], Convert.ToInt32(group[2]), Convert.ToInt32(group[3]), Convert.ToInt32(group[4])));
            }

            List<List<string>> racersData = CSVParser.ParseCSV(racerPath);
            // BIB number is the racer key
            foreach (List<string> racer in racersData)
            {
                Racers.Add(Convert.ToInt32(racer[2]), new Racer(racer[0], racer[1], Convert.ToInt32(racer[2]), Groups[Convert.ToInt32(racer[3])]));
            }

            List<List<string>> sensorData = CSVParser.ParseCSV(sensorPath);
            // Sensor number  is the mile key
            foreach (List<string> sensor in sensorData)
            {
                Sensors.Add(Convert.ToInt32(sensor[0]), Convert.ToInt32(sensor[1]));
            }

        } 

        public void UpdateRacer(int BIB, int position, int time)
        {
            Console.Write(BIB);
            Racers[BIB].UpdateRacerState(position, time);
        }
        public Dictionary<int, Racer> GetRacers() 
        {
            return Racers;
        }
        public Racer GetRacer(int BIB)
        {
            return Racers[BIB];
        }
    }
}
