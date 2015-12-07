using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib.Bets
{
    public class FieldBet
    {
        public decimal Amount { get; set; }
        public List<int> FieldNumbersSingle { get; set; }
        public List<int> FieldNumbersDouble { get; set; }

        public FieldBet(decimal amount)
        {
            FieldNumbersDouble = new List<int> { 2, 12 };
            FieldNumbersSingle = new List<int> { 3, 4, 9, 10, 11};
            Amount = amount;
        }

        public bool Roll(int diceRoll, bool hard, out decimal payout)
        {
            if (FieldNumbersDouble.Exists(d => d == diceRoll))
            {
                payout = 2M * Amount;
            }
            else if (FieldNumbersSingle.Exists(d => d == diceRoll))
            {
                payout = 1M * Amount;
            }
            else
                payout = -1M * Amount;

            return false;
        }
    }
}
