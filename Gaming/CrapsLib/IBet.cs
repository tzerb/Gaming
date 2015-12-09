using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsLib
{
    public interface IBet
    {
        bool Roll(DiceRoll diceRoll, out decimal payout);
    }
}
