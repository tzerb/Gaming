using CrapsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsGame.ViewModels
{
    class BetViewModel
    {
        private IBet _bet;

        public decimal? Payout { get; set; }

        public BetViewModel(IBet bet)
        {
            _bet = bet;
        }

        public bool Roll(DiceRoll diceRoll)
        {
            if (Payout.HasValue)
                throw new Exception("Bet has been paid!");

            decimal payout = 0M;
            if (_bet.Roll(diceRoll, out payout))
            {
                Payout = payout;
                return true;
            }
            return false;
        }
    }
}
