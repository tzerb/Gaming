using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib.Bets
{
    public class PropositionBet : IBet
    {
        public decimal Amount { get; set; }
        public int ProposedDiceRoll { get; set; }
        public PropositionBet(decimal amount, int proposedDiceRoll)
        {
            Amount = amount;
            ProposedDiceRoll = proposedDiceRoll;
            if ((proposedDiceRoll != 2)
                && (proposedDiceRoll != 3)
                && (proposedDiceRoll != 11)
                && (proposedDiceRoll != 12))
            {
                throw new Exception("Bad Bet!");
            }
        }

        public bool Roll(DiceRoll dice, out decimal payout)
        {
            var diceRoll = dice.TotalRoll;
            if (diceRoll == ProposedDiceRoll)
            {
                switch (diceRoll)
                {
                    case 2:
                    case 12:
                        payout = Amount * 30;
                        break;

                    case 3:
                    case 11:
                        payout = Amount * 15;
                        break;

                    default:
                        throw new Exception("Bad");
                }
            }
            else
            {
                payout = -1M * Amount;
            }
            return true;
        }
    }
}
