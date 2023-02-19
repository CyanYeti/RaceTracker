using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceTracker;
using System;
using System.Collections.Generic;

namespace RaceTrackerUnitTests
{
    [TestClass]
    public class CheaterComputerTests
    {
        [TestMethod]
        public void ConstructorTest() // I wish I set up the main state better
        {
            CheatingComputer testComputer  = new CheatingComputer();
            foreach(KeyValuePair<int,Racer> racer in Program.State.GetRacers())
            {
                Assert.IsTrue(racer.Value.observers.Contains(testComputer));
            }
        }
        [TestMethod]
        public void UpdateTest()
        {
            CheatingComputer testComputer = new CheatingComputer();
            Racer testRacer1 = Program.State.GetRacer(1);
            Racer testRacer2 = Program.State.GetRacer(2);
            testRacer1.Progress = new Dictionary<int, int>{ 
                { 0, 1000}, 
                { 1, 3000 }
            };
            testRacer2.Progress = new Dictionary<int, int>{
                { 0, 1000},
                { 1, 4000 }
            };
            testRacer1.RacerGroup.Id = 1;
            testRacer2.RacerGroup.Id = 2;
            testRacer1.Sensor = 1;
            testRacer2.Sensor = 1;

            testComputer.Update(testRacer1);
            testComputer.Update(testRacer2);

            Console.WriteLine(testComputer.Cheaters[0].BIB);
            Assert.IsTrue(testComputer.Cheaters.Contains(testRacer1));
            Assert.IsTrue(testComputer.CheatedWith.Contains(testRacer2));


        }
        [TestMethod]
        public void SubscribeTest()
        {

        }
        [TestMethod]
        public void UnsubscribeTest()
        {

        }
    }
}
