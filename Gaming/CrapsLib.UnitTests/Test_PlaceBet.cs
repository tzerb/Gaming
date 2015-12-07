using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrapsLib.Bets;

namespace CrapsLib.UnitTests
{
    [TestClass]
    public class Test_PlaceBet
    {
        [TestMethod]
        public void Test_6_Win()
        {
            decimal payout;
            var pb = new PlaceBet(120, 6);
            Assert.IsFalse(pb.Roll(6, out payout));
            Assert.AreEqual(payout, 140);
        }
        [TestMethod]
        public void Test_6_Loss()
        {
            decimal payout;
            var pb = new PlaceBet(120, 6);
            Assert.IsFalse(pb.Roll(7, out payout));
            Assert.AreEqual(payout, -120);
        }
    }
}
