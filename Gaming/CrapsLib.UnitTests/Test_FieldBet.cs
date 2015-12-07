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
            Assert.IsFalse(fb.Roll(3, false, out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(4, false, out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(9, false, out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(10, false, out payout));
            Assert.AreEqual(payout, 100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(11, false, out payout));
            Assert.AreEqual(payout, 100);

        }

        [TestMethod]
        public void Test_DoublePayout()
        {
            decimal payout;
            var fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(2, false, out payout));
            Assert.AreEqual(payout, 200);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(12, false, out payout));
            Assert.AreEqual(payout, 200);
        }

        [TestMethod]
        public void Test_Loss()
        {
            decimal payout;
            var fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(5, false, out payout));
            Assert.AreEqual(payout, -100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(6, false, out payout));
            Assert.AreEqual(payout, -100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(7, false, out payout));
            Assert.AreEqual(payout, -100);

            fb = new FieldBet(100);
            Assert.IsFalse(fb.Roll(8, false, out payout));
            Assert.AreEqual(payout, -100);
        }

    }
}
