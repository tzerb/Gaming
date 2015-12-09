using CrapsLib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib
{
    public class BetFactory
    {
        public IBet BonusBet(decimal amount)
        {
            return new BonusBet(amount);
        }

        public IBet PassLineBet(decimal amount)
        {
            return new PassLineBet(amount);
        }

        public IBet Hard(decimal amount, int proposedDiceRoll)
        {
            return new HardWaysBet(amount, proposedDiceRoll);
        }
    }
}
