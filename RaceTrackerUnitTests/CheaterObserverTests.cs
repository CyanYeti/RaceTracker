using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceTracker;
using System;
using System.Collections.Generic;

namespace RaceTrackerUnitTests
{
    [TestClass]
    public class CheaterObserverTests
    {
        [TestMethod]
        public void UpdateTest()
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
            testProgress.Add(posistion, time);

            testRacer.UpdateRacerState(posistion, time); // Update is called by this function

            // The updated progress was passed to subscriber correctly
            Assert.AreEqual(testProgress[posistion], testSubscriber.RacersWatched[testRacer.BIB].Progress[posistion]);
        }
        [TestMethod]
        public void SubscribeTest()
        {
            string FirstName = "Testy";
            string LastName = "McTester";
            RaceGroup RacerGroup = new RaceTracker.RaceGroup(0, "Bikers 1", 000000, 1, 50);
            int BIB = 1;
            Racer testRacer = new Racer(FirstName, LastName, BIB, RacerGroup);

            RacerObserver testSubscriber = new RacerObserver("Test Observer");


            testSubscriber.Subscribe(testRacer);


            Assert.IsTrue(testSubscriber.RacersWatched.ContainsKey(testRacer.BIB));
            Assert.AreEqual(testRacer, testSubscriber.RacersWatched[testRacer.BIB]);
        }

        [TestMethod]
        public void UnsubscribeTest()
        {
            string FirstName = "Testy";
            string LastName = "McTester";
            RaceGroup RacerGroup = new RaceTracker.RaceGroup(0, "Bikers 1", 000000, 1, 50);
            int BIB = 1;
            Racer testRacer = new Racer(FirstName, LastName, BIB, RacerGroup);

            RacerObserver testSubscriber = new RacerObserver("Test Observer");
            testSubscriber.Subscribe(testRacer);

            testSubscriber.Unsubscribe(testRacer);

            Assert.IsFalse(testSubscriber.RacersWatched.ContainsKey(testRacer.BIB));
        }
        [TestMethod]
        public void GetSubjectsTest()
        {
            string FirstName = "Testy";
            string LastName = "McTester";
            RaceGroup RacerGroup = new RaceTracker.RaceGroup(0, "Bikers 1", 000000, 1, 50);
            int BIB = 1;
            Racer testRacer = new Racer(FirstName, LastName, BIB, RacerGroup);

            RacerObserver testSubscriber = new RacerObserver("Test Observer");
            testSubscriber.Subscribe(testRacer);


            Assert.AreEqual(testRacer, testSubscriber.GetSubjects()[0]);
        }
    }
}
