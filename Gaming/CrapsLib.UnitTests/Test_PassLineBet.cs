using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrapsLib.Bets;

namespace CrapsLib.UnitTests
{
    [TestClass]
    public class Test_PassLineBet
    {
        [TestMethod]
        public void ComeOut_7()
        {
            decimal payout;
            var plb = new PassLineBet(100.0M);
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(7), out payout));
            Assert.AreEqual(payout, 100.0M);
            Assert.IsTrue(plb.State == GameState.Off);
        }

        [TestMethod]
        public void ComeOut_11()
        {
            decimal payout;
            var plb = new PassLineBet(100.0M);
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(11), out payout));
            Assert.AreEqual(payout, 100.0M);
            Assert.IsTrue(plb.State == GameState.Off);
        }

        [TestMethod]
        public void ComeOut_Craps()
        {
            decimal payout;
            var plb = new PassLineBet(100.0M);
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(2), out payout));
            Assert.AreEqual(payout, -100.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(3), out payout));
            Assert.AreEqual(payout, -100.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(12), out payout));
            Assert.AreEqual(payout, -100.0M);
            Assert.IsTrue(plb.State == GameState.Off);
        }

        [TestMethod]
        public void ComeOut_Point_4()
        {
            decimal payout;
            var plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 100.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            plb.Odds = 100;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 300.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);
            plb.Odds = 100;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(7), out payout));
            Assert.AreEqual(payout, -200.0M);
            Assert.IsTrue(plb.State == GameState.Off);

        }

        [TestMethod]
        public void ComeOut_Point_5()
        {
            decimal payout;
            var plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(5), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(5), out payout));
            Assert.AreEqual(payout, 100.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(5), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            plb.Odds = 100;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(5), out payout));
            Assert.AreEqual(payout, 250.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(5), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            plb.Odds = 100;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(7), out payout));
            Assert.AreEqual(payout, -200.0M);
            Assert.IsTrue(plb.State == GameState.Off);

        }

        [TestMethod]
        public void ComeOut_Point_6()
        {
            int point = 6;
            decimal payout;
            var plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(point), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(point), out payout));
            Assert.AreEqual(payout, 100.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(point), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            plb.Odds = 100;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(point), out payout));
            Assert.AreEqual(payout, 220.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new PassLineBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(point), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            plb.Odds = 100;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(7), out payout));
            Assert.AreEqual(payout, -200.0M);
            Assert.IsTrue(plb.State == GameState.Off);
        }
    }
}
