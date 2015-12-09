using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrapsLib.Bets;

namespace CrapsLib.UnitTests
{
    [TestClass]
    public class Test_DontPassBet
    {
        [TestMethod]
        public void DontCome_Point_4()
        {
            decimal payout;
            var plb = new DontPassBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, -100.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new DontPassBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            plb.Lay = 200;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, -300.0M);
            Assert.IsTrue(plb.State == GameState.Off);

            plb = new DontPassBet(100.0M);
            Assert.IsFalse(plb.Roll(DiceRoll.SpecificRoll(4), out payout));
            Assert.AreEqual(payout, 0M);
            Assert.IsTrue(plb.State == GameState.On);

            plb.Lay = 200;
            Assert.IsTrue(plb.Roll(DiceRoll.SpecificRoll(7), out payout));
            Assert.AreEqual(payout, 200.0M);
            Assert.IsTrue(plb.State == GameState.Off);

        }
    }
}
