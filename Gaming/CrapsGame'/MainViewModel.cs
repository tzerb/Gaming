using Caliburn.Micro;
using CrapsGame.ViewModels;
using CrapsLib;
using CrapsLib.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsGame
{
    class MainViewModel : Screen
    {
        public List<BetViewModel> Bets { get; set; }

        public bool IsOn { get; private set; }
        public int? Point { get; private set; }

        public int Die1 {
            get
            {
                return DiceRoll.Die1;
            }
        }
        public int Die2
        {
            get
            {
                return DiceRoll.Die2;
            }
        }

        private DiceRoll _diceRoll;
        public DiceRoll DiceRoll
        {
            get
            {
                return _diceRoll;
            }
            set
            {
                _diceRoll = value;
                NotifyOfPropertyChange("Die1");
                NotifyOfPropertyChange("Die2");
                NotifyOfPropertyChange("Roll");
                NotifyOfPropertyChange("IsOn");
            }
        }
        public MainViewModel()
        {
            DiceRoll = DiceRoll.SpecificRoll(1, 1);
            Bets = new List<BetViewModel>();
            Bets.Add(new BetViewModel(new PassLineBet(100)));
        }

        public decimal Bank { get; set; }

        public void Roll()
        {
            DiceRoll = DiceRoll.RandomRoll();
            if (IsOn)
            {
                if (DiceRoll.TotalRoll == 7)
                {
                    IsOn = false;
                    Point = new int?();
                }
                else if (DiceRoll.TotalRoll == Point)
                {
                    IsOn = false;
                    Point = new int?();
                }
            }
            else
            {
                if (DiceRoll.IsPointNumber)
                {
                    Point = DiceRoll.TotalRoll;
                    IsOn = true;
                }
            }

            for (int i = Bets.Count - 1; i > -1; i--)
            {
                BetViewModel b = Bets[i];
                if (b.Roll(DiceRoll))
                {
                    Bank += b.Payout.Value;
                    Bets.RemoveAt(i);
                };
            }

            NotifyOfPropertyChange("IsOn");
            NotifyOfPropertyChange("Point");
            NotifyOfPropertyChange("Bank");

        }
    }
}
