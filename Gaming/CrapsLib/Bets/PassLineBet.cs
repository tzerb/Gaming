using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib.Bets
{
    public enum GameState
    {
        On,
        Off
    }

    public enum RollResult
    {
        Win, Lose
    }

    public enum BetDisposition
    {

    }

    public class PassLineBet : IBet
    {
        public GameState State { get; set; }
        public int Point { get; set; }
        public decimal Amount { get; set; }
        public decimal Odds { get; set; }

        public PassLineBet(decimal amount)
        {
            State = GameState.Off;
            Amount = amount;
            Odds = 0M;
            State = GameState.Off;
        }

        public bool Roll(DiceRoll dice, out decimal payout)
        {
            int diceRoll = dice.TotalRoll;
            payout = 0M;
            if (State == GameState.Off)
            {
                if (diceRoll == 7 || diceRoll == 11)
                {
                    payout = Amount;
                    //Console.WriteLine("7/11 winner {0}", payout);
                    return true;
                }

                if (diceRoll == 2 || diceRoll == 3 || diceRoll == 12)
                {
                    payout = -1 * Amount;
                    //Console.WriteLine("Craps loser {0}", payout);
                    return true;
                }

                Point = diceRoll;
                State = GameState.On;
                return false;
            }

            if (diceRoll == 7)
            {
                payout = -1.0M * (Amount + Odds);
                //Console.WriteLine("7 out {0}", payout);
                State = GameState.Off;
                return true;
            }
            if (diceRoll == Point)
            {
                switch (diceRoll)
                {
                    case 4:
                    case 10:
                        payout = Amount + (Odds * 2.0M);
                        State = GameState.Off;
                        break;

                    case 5:
                    case 9:
                        payout = Amount + ((int)(Odds / 2.0M)) * 3.0M;
                        State = GameState.Off;
                        break;

                    case 6:
                    case 8:
                        payout = Amount + ((int)(Odds / 5.0M)) * 6.0M;
                        State = GameState.Off;
                        break;
                }
                //Console.WriteLine("Winner! {0} - {1}", diceRoll, payout);
                return true;
            }
            return false;
        }
    }
}
