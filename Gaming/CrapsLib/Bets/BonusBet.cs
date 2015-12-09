using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib.Bets
{
    public class BonusBet : IBet
    {
        public decimal Amount { get; set; }
        public decimal Multiplier { get; set; }

        protected List<int> Numbers
        {
            get; set;
        }
        public BonusBet(decimal amount)
        {
            Amount = amount;
        }

        public bool Roll(DiceRoll diceRoll, out decimal payout)
        {
            if (diceRoll.TotalRoll == 7)
            {
                payout = -1M * Amount;
                return false;
            }

            if (Numbers.Exists(d => d == diceRoll.TotalRoll))
                Numbers.Remove(diceRoll.TotalRoll);

            if (Numbers.Count == 0)
            {
                payout = Multiplier * Amount;
                return false;
            }
            payout = 0M;
            return true;
        }
    }

    public class TallBonusBet : BonusBet
    {
        public TallBonusBet(decimal amount) : base(amount)
        {
            Numbers = new List<int> { 12, 11, 10, 9, 8 };
            Multiplier = 34M;
        }
    }

    public class SmallBonusBet : BonusBet
    {
        public SmallBonusBet(decimal amount) : base(amount)
        {
            Numbers = new List<int> { 2, 3, 4, 5, 6 };
            Multiplier = 34M;
        }
    }

    public class AllBonusBet : BonusBet
    {
        public AllBonusBet(decimal amount) : base(amount)
        {
            Numbers = new List<int> { 12, 11, 10, 9, 8, 2, 3, 4, 5, 6 };
            Multiplier = 175M;
        }
    }


}
