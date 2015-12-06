using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib
{
    public enum GameState
    {
        On,
        Off
    }

    public class PassLineBet
    {
        public GameState State { get; set; }

        public PassLineBet(decimal amount)
        {
            State = GameState.Off;
        }

        public bool Roll(int diceRoll, out decimal payout)
        {
            payout = 0.0M;
            return false;
        }
    }
}
