using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrapsLib.Bets;

namespace CrapsLib.UnitTests
{
    [TestClass]
    public class Test_HardWaysBet
    {
        [TestMethod]
        public void Hardway_4()
        {
            decimal payout = 0M;
            var hwb = new HardWaysBet(100M, 4);
            hwb.State = GameState.On;
            Assert.IsTrue(hwb.Roll(DiceRoll.SpecificRoll(2,2), out payout));
            Assert.AreEqual(payout, 700);

            payout = 0M;
            hwb = new HardWaysBet(100M, 4);
            hwb.State = GameState.On;
            Assert.IsTrue(hwb.Roll(DiceRoll.SpecificRoll(3, 1), out payout));
            Assert.AreEqual(payout, -100);

            payout = 0M;
            hwb = new HardWaysBet(100M, 4);
            hwb.State = GameState.On;
            Assert.IsTrue(hwb.Roll(DiceRoll.SpecificRoll(3, 4), out payout));
            Assert.AreEqual(payout, -100);

            payout = 0M;
            hwb = new HardWaysBet(100M, 4);
            hwb.State = GameState.On;
            Assert.IsFalse(hwb.Roll(DiceRoll.SpecificRoll(3, 2), out payout));
            Assert.AreEqual(payout, 0M);

        }
    }
}
