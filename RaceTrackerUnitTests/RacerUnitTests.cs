using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceTracker;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceTrackerUnitTests
{
    [TestClass]
    public class RacerUnitTests
    {
        [TestMethod]
        public void RacerTest()
        {
            string FirstName = "Testy";
            string LastName = "McTester";
            RaceGroup RacerGroup = new RaceTracker.RaceGroup(0, "Bikers 1", 000000, 1, 50);
            int BIB = 1;

            Racer testRacer = new Racer(FirstName, LastName, BIB, RacerGroup);

            Assert.AreEqual(FirstName, testRacer.FirstName);
            Assert.AreEqual(LastName, testRacer.LastName);
            Assert.AreEqual(RacerGroup, testRacer.RacerGroup);
            Assert.AreEqual(BIB, testRacer.BIB);
    }
        [TestMethod]
        public void UpdateTest()
        {
            string FirstName = "Testy";
            string LastName = "McTester";
            RaceGroup RacerGroup = new RaceTracker.RaceGroup(0, "Bikers 1", 000000, 1, 50);
            int BIB = 1;
            Racer testRacer = new Racer(FirstName, LastName, BIB, RacerGroup);

            int posistion = 1;
            int time = 123456;
            Dictionary<int,int> testProgress= new Dictionary<int,int>();
            testProgress.Add(posistion,time);

            testRacer.UpdateRacerState(posistion, time);

            Assert.AreEqual(testProgress[posistion], testRacer.Progress[posistion]);
            Assert.AreEqual(posistion, testRacer.Sensor);
            Assert.AreEqual(time, testRacer.CurrentTime);
            
        }
        [TestMethod]
        public void GetRaceGroupTest()
        {
            string FirstName = "Testy";
            string LastName = "McTester";
            RaceGroup RacerGroup = new RaceTracker.RaceGroup(0, "Bikers 1", 000000, 1, 50);
            int BIB = 1;
            Racer testRacer = new Racer(FirstName, LastName, BIB, RacerGroup);

            Assert.AreEqual(RacerGroup, testRacer.getRaceGroup());
        }
        [TestMethod]
        public void NotifyTest()
        {
            string FirstName = "Testy";
            string LastName = "McTester";
            RaceGroup RacerGroup = new RaceTracker.RaceGroup(0, "Bikers 1", 000000, 1, 50);
            int BIB = 1;
            Racer testRacer = new Racer(FirstName, LastName, BIB, RacerGroup);

            RacerObserver testSubscriber = new RacerObserver("Test Observer");

            testRacer.Subscribe(testSubscriber);

            int posistion = 1;
            int time = 123456;
            Dictionary<int, int> testProgress = new Dictionary<int, int>();
            testProgress.Add(posistion,time);

            testRacer.UpdateRacerState(posistion, time); //Notify is called from update, this is what we want to test

            // The updated progress was passed to subscriber correctly
            Assert.AreEqual(testProgress[posistion], testSubscriber.RacersWatched[testRacer.BIB].Progress[posistion]);
            // Racers should be the same updated
            Assert.AreEqual(testRacer.Sensor, testSubscriber.RacersWatched[testRacer.BIB].Sensor);
            Assert.AreEqual(testRacer.Progress[posistion], testSubscriber.RacersWatched[testRacer.BIB].Progress[posistion]);
            Assert.AreEqual(testRacer.BIB, testSubscriber.RacersWatched[testRacer.BIB].BIB);
            Assert.AreEqual(testRacer.CurrentTime, testSubscriber.RacersWatched[testRacer.BIB].CurrentTime);



        }
    }
}
