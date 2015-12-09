using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib.Bets
{
    public class PlaceBet : IBet
    {
        public decimal Amount { get; }
        public int DesiredRoll { get; }
        private Dictionary<int, decimal> multipliers = new Dictionary<int, decimal>();
        public PlaceBet(decimal amount, int desiredRoll)
        {
            Amount = amount;
            DesiredRoll = desiredRoll;
            multipliers.Add(4, 9M / 5M);
            multipliers.Add(5, 7M / 5M);
            multipliers.Add(6, 7M / 6M);
            multipliers.Add(8, 7M / 6M);
            multipliers.Add(9, 7M / 5M);
            multipliers.Add(10, 9M / 5M);
        }

        public bool Roll(DiceRoll diceRoll, out decimal payout)
        {
            if (diceRoll.TotalRoll == 7)
            {
                payout = -1M * Amount;
                return false;
            }

            if (multipliers.ContainsKey(diceRoll.TotalRoll))
            {
                payout = multipliers[diceRoll.TotalRoll] * Amount;
                return false;
            }

            payout = 0;
            return true;
        }
    }
}
