﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib
{
    class DiceRoll
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
    }
}
