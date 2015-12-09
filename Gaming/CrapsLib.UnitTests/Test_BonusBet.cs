using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrapsLib.Bets;

namespace CrapsLib.UnitTests
{
    [TestClass]
    public class Test_BonusBet
    {
        [TestMethod]
        public void Test_SmallBonusBet_BasicWin()
        {
            decimal payout;
            var smb = new SmallBonusBet(100);
            Assert.IsTrue(smb.Roll(new DiceRoll(1,1), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(smb.Roll(new DiceRoll(1, 2), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(smb.Roll(new DiceRoll(1, 3), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(smb.Roll(new DiceRoll(1, 4), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsFalse(smb.Roll(new DiceRoll(1, 5), out payout));
            Assert.AreEqual(payout, 3400);
        }

        [TestMethod]
        public void Test_SmallBonusBet_BasicLoss()
        {
            decimal payout;
            var smb = new SmallBonusBet(100);
            Assert.IsFalse(smb.Roll(new DiceRoll(1, 6), out payout));
            Assert.AreEqual(payout, -100);
        }

        [TestMethod]
        public void Test_TallBonusBet_BasicWin()
        {
            decimal payout;
            var tbb = new TallBonusBet(100);
            Assert.IsTrue(tbb.Roll(new DiceRoll(6, 6), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(tbb.Roll(new DiceRoll(6, 5), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(tbb.Roll(new DiceRoll(6, 4), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(tbb.Roll(new DiceRoll(6, 3), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsFalse(tbb.Roll(new DiceRoll(6, 2), out payout));
            Assert.AreEqual(payout, 3400);
        }

        [TestMethod]
        public void Test_TallBonusBet_BasicLoss()
        {
            decimal payout;
            var tbb = new TallBonusBet(100);
            Assert.IsFalse(tbb.Roll(new DiceRoll(1, 6), out payout));
            Assert.AreEqual(payout, -100);
        }

        [TestMethod]
        public void Test_AllBonusBet_BasicWin()
        {
            decimal payout;
            var abb = new AllBonusBet(100);
            Assert.IsTrue(abb.Roll(new DiceRoll(1, 1), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(new DiceRoll(1, 2), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(new DiceRoll(1, 3), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(new DiceRoll(1, 4), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(new DiceRoll(1, 5), out payout));
            Assert.AreEqual(payout, 0);

            Assert.IsTrue(abb.Roll(new DiceRoll(6, 6), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(new DiceRoll(6, 5), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(new DiceRoll(6, 4), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(new DiceRoll(6, 3), out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsFalse(abb.Roll(new DiceRoll(6, 2), out payout));

            Assert.AreEqual(payout, 17500);
        }
        [TestMethod]
        public void Test_AllBonusBet_BasicLoss()
        {
            decimal payout;
            var abb = new AllBonusBet(100);
            Assert.IsFalse(abb.Roll(new DiceRoll(6, 1), out payout));
            Assert.AreEqual(payout, -100);
        }
    }
}
