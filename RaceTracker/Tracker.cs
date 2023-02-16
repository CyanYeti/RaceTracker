using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class Tracker
    {
        private Dictionary<int, Racer> Racers = new Dictionary<int, Racer>();
        private Dictionary<int, RaceGroup> Groups = new Dictionary<int, RaceGroup>();
        public Tracker() 
        {
            List<List<string>> groupsData = CSVParser.ParseCSV("Groups.csv");
            // Group ID is the groups key
            foreach (List<string> group in groupsData)
            {
                Groups.Add(Convert.ToInt32(group[0]), new RaceGroup(Convert.ToInt32(group[0]), group[1], Convert.ToInt32(group[2]), Convert.ToInt32(group[3]), Convert.ToInt32(group[4])));
            }

            List<List<string>> racersData = CSVParser.ParseCSV("Racers.csv");
            // BIB number is the racer key
            foreach (List<string> racer in racersData)
            {
                Racers.Add(Convert.ToInt32(racer[2]), new Racer(racer[0], racer[1], Convert.ToInt32(racer[2]), Groups[Convert.ToInt32(racer[3])]));
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
        public Racer getRacer(int BIB)
        {
            return Racers[BIB];
        }
    }
}
