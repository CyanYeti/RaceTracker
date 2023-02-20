using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceTracker
{
    internal class CSVParser
    {
        public static List<List<string>> ParseCSV(string file)
        {
            Console.WriteLine(file);
            using(StreamReader sr = new StreamReader(file))
            {
                List<List<string>>  data = new List<List<string>>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    data.Add(line.Split(',').ToList());
                }
                sr.Close();
                return data;

            }
        }
    }
}
