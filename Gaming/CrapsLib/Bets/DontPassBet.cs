using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib.Bets
{
    public class DontPassBet : IBet
    {
        public GameState State { get; set; }
        public decimal Amount { get; }
        public decimal Lay { get; set; }

        public int Point { get; set; }

        public DontPassBet(decimal amount)
        {
            State = GameState.Off;
            Amount = amount;
            Lay = 0M;
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
                    payout = -1M * Amount;
                    //Console.WriteLine("7/11 winner {0}", payout);
                    return true;
                }

                if (diceRoll == 2 || diceRoll == 3)
                {
                    payout = Amount;
                    //Console.WriteLine("Craps loser {0}", payout);
                    return true;
                }

                if (diceRoll == 12)
                {
                    // push
                    payout = 0;
                    return true;
                }

                Point = diceRoll;
                State = GameState.On;
                return false;
            }

            if (diceRoll == 7)
            {
                switch (Point)
                {
                    case 4:
                    case 10:
                        payout = Amount + (Lay / 2.0M);
                        State = GameState.Off;
                        break;

                    case 5:
                    case 9:
                        payout = Amount + ((int)(Lay * 2.0M)) / 3.0M;
                        State = GameState.Off;
                        break;

                    case 6:
                    case 8:
                        payout = Amount + ((int)(Lay * 5.0M)) / 6.0M;
                        State = GameState.Off;
                        break;
                }

                State = GameState.Off;
                return true;
            }

            if (diceRoll == Point)
            {
                payout = -1M * (Amount + Lay);
                State = GameState.Off;

                //Console.WriteLine("Winner! {0} - {1}", diceRoll, payout);
                return true;
            }
            return false;

        }
    }
}
