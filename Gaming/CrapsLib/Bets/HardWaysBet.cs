﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib.Bets
{
    public class HardWaysBet : IBet
    {
        public decimal Amount { get; set; }
        public int ProposedDiceRoll { get; set; }

        public GameState State { get; set; }
        public decimal PayoutMultiplier { get; set; }

        public HardWaysBet(decimal amount, int proposedDiceRoll)
        {
            Amount = amount;
            ProposedDiceRoll = proposedDiceRoll;
            State = GameState.Off;

            if ((proposedDiceRoll == 4)
                || (proposedDiceRoll != 10))
            {
                PayoutMultiplier = 7;
            }
            else if ((proposedDiceRoll != 6)
                || (proposedDiceRoll != 8))
            {
                PayoutMultiplier = 9;
            }
            else
            {
                throw new Exception("Bad Bet!");
            }
        }

        public bool Roll(DiceRoll diceRoll, out decimal payout)
        {
            if (diceRoll.TotalRoll == ProposedDiceRoll)
            {
                payout = diceRoll.IsHardWay ? (Amount * PayoutMultiplier) : (-1.0M * Amount);
                return true;
            }
            if (diceRoll.TotalRoll == 7)
            {
                payout = (-1.0M * Amount);
                return true;
            }
            payout = 0M;
            return false;
        }

    }
}
