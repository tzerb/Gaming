using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib
{
    public class DiceRoll
    {
        public int Die1 { get; }
        public int Die2 { get; }

        public bool IsHardWay => Die1 == Die2;
        public int TotalRoll => Die1 + Die2;
        public DiceRoll(int die1, int die2)
        {
            Die1 = die1;
            Die2 = die2;
        }

        static private Random r = new Random((int)(DateTime.Now.Ticks % 10000));
        public static DiceRoll RandomRoll()
        {
            return new DiceRoll(r.Next(1, 7), r.Next(1, 7));
        }

        public static DiceRoll SpecificTotal(int total)
        {
            if (total < 2 || total > 12)
            {
                throw new Exception("Bad total");
            }
            int die1 = total / 2;
            int die2 = total - die1;
            return new DiceRoll(die1, die2);
        }

        public static DiceRoll SpecificRoll(int die1, int die2)
        {
            return new DiceRoll(die1, die2);
        }
    }
}
