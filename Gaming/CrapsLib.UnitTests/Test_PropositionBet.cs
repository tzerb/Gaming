using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrapsLib.UnitTests
{
    [TestClass]
    public class Test_PropositionBet
    {
        [TestMethod]
        public void Prop_2()
        {
            decimal payout = 0M;
            var pb = new PropositionBet(100, 2);
            Assert.IsTrue(pb.Roll(2, out payout));
            Assert.AreEqual(payout, 3000M);

            payout = 0M;
            pb = new PropositionBet(100, 2);
            Assert.IsTrue(pb.Roll(5, out payout));
            Assert.AreEqual(payout, -100M);

        }
    }
}
