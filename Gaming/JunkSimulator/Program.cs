using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //DisplayRollDistribution();
            do
            {
                decimal bank = 0M;
                int trips = 100;
                for (int i = 1; i < trips; i++)
                {
                    bank += PassLineResults();
                }
                Console.WriteLine("TotalBank = {0} | {1:n2} / trip", bank, bank / trips);
            } while (Console.ReadKey().Key != ConsoleKey.A);
        }

        static decimal PassLineResults()
        {
            long totalRolls = 300;
            const decimal betAmount = 25.0M;
            decimal bank = 0M;
            decimal bankMax = 0M;
            decimal bankMin = 0M;
            for (long i = 0; i < totalRolls; i++)
            {
                decimal payout = 0M;
                var roll = CrapsLib.DiceRoll.RandomRoll();
                // var p = new CrapsLib.Bets.PropositionBet(betAmount, 11);
                var p = new CrapsLib.Bets.PassLineBet(betAmount);
                p.Odds = betAmount * 5.0M;
                while (!p.Roll(roll, out payout))
                {
                    roll = CrapsLib.DiceRoll.RandomRoll();
                }
                bank += payout;
                bankMax = Math.Max(bank, bankMax);
                bankMin = Math.Min(bank, bankMin);
                if (bank < -500)
                {
                    totalRolls = i;
                    break;
                }
            }
            // Console.WriteLine("Total Rolls ={0} ", totalRolls);
            Console.WriteLine($@"Bank = {bank}");
            //Console.WriteLine($@"Max  = {bankMax}");
            //Console.WriteLine($@"Min  = {bankMin}");
            //Console.WriteLine($@"House = {(bank / ((decimal)totalRolls * betAmount))}");
            return bank;
        }
        static void DisplayRollDistribution()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 2; i <= 12; i++)
            {
                dict.Add(i, 0);
            }

            const long totalRolls = 1000000;
            for (long i = 0; i < totalRolls; i++)
            {
                int roll = CrapsLib.DiceRoll.RandomRoll().TotalRoll;
                dict[roll] = dict[roll] + 1;
            }

            for (int i = 2; i <= 12; i++)
            {
                Console.WriteLine($@"{i} = {dict[i]} - {((dict[i] * 100.0) / totalRolls).ToString("n2")}%");
            }
        }
    }
}
