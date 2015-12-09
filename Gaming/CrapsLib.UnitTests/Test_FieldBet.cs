using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrapsLib.Bets;

namespace CrapsLib.UnitTests
{
    [TestClass]
    public class Test_FieldBet
    {
        [TestMethod]
        public void Test_SinglePayout()
        {
            decimal payout;
            var fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(3), out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(4), out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(9), out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(10), out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(11), out payout));
            Assert.AreEqual(payout, 100);

        }

        [TestMethod]
        public void Test_DoublePayout()
        {
            decimal payout;
            var fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(2), out payout));
            Assert.AreEqual(payout, 200);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(12), out payout));
            Assert.AreEqual(payout, 200);
        }

        [TestMethod]
        public void Test_Loss()
        {
            decimal payout;
            var fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(5), out payout));
            Assert.AreEqual(payout, -100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(6), out payout));
            Assert.AreEqual(payout, -100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(7), out payout));
            Assert.AreEqual(payout, -100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(DiceRoll.SpecificTotal(8), out payout));
            Assert.AreEqual(payout, -100);
        }

    }
}
