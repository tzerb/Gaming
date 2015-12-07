using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsTrue(smb.Roll(2, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(smb.Roll(3, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(smb.Roll(4, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(smb.Roll(5, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsFalse(smb.Roll(6, out payout));
            Assert.AreEqual(payout, 3400);
        }

        [TestMethod]
        public void Test_SmallBonusBet_BasicLoss()
        {
            decimal payout;
            var smb = new SmallBonusBet(100);
            Assert.IsFalse(smb.Roll(7, out payout));
            Assert.AreEqual(payout, -100);
        }

        [TestMethod]
        public void Test_TallBonusBet_BasicWin()
        {
            decimal payout;
            var tbb = new TallBonusBet(100);
            Assert.IsTrue(tbb.Roll(12, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(tbb.Roll(11, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(tbb.Roll(10, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(tbb.Roll(9, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsFalse(tbb.Roll(8, out payout));
            Assert.AreEqual(payout, 3400);
        }

        [TestMethod]
        public void Test_TallBonusBet_BasicLoss()
        {
            decimal payout;
            var tbb = new TallBonusBet(100);
            Assert.IsFalse(tbb.Roll(7, out payout));
            Assert.AreEqual(payout, -100);
        }

        [TestMethod]
        public void Test_AllBonusBet_BasicWin()
        {
            decimal payout;
            var abb = new AllBonusBet(100);
            Assert.IsTrue(abb.Roll(2, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(3, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(4, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(5, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(6, out payout));
            Assert.AreEqual(payout, 0);

            Assert.IsTrue(abb.Roll(8, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(9, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(10, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsTrue(abb.Roll(11, out payout));
            Assert.AreEqual(payout, 0);
            Assert.IsFalse(abb.Roll(12, out payout));

            Assert.AreEqual(payout, 17500);
        }
        [TestMethod]
        public void Test_AllBonusBet_BasicLoss()
        {
            decimal payout;
            var abb = new AllBonusBet(100);
            Assert.IsFalse(abb.Roll(7, out payout));
            Assert.AreEqual(payout, -100);
        }
    }
}
