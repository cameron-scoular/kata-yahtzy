using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace kata_yahtzy
{
    public class DieScoreCalculator
    {

        public int ScoreDieRoll(int[] dieArray, ScoringCategory scoringCategory)
        {
            
            if (!ValidateDieRollArray(dieArray))
            {
                throw new ArgumentException();
            }

            switch (scoringCategory)
            {
                case ScoringCategory.Chance:
                    return dieArray.Sum();
                case ScoringCategory.Yatzy:
                    return IsYatzy(dieArray) ? 50 : 0;
                case ScoringCategory.Ones:
                    return ScoreOnesTwosThreesFoursFivesOrSixes(dieArray, scoringCategory);
                case ScoringCategory.Twos:
                    return ScoreOnesTwosThreesFoursFivesOrSixes(dieArray, scoringCategory);
                case ScoringCategory.Threes:
                    return ScoreOnesTwosThreesFoursFivesOrSixes(dieArray, scoringCategory);
                case ScoringCategory.Fours:
                    return ScoreOnesTwosThreesFoursFivesOrSixes(dieArray, scoringCategory);
                case ScoringCategory.Fives:
                    return ScoreOnesTwosThreesFoursFivesOrSixes(dieArray, scoringCategory);
                case ScoringCategory.Sixes:
                    return ScoreOnesTwosThreesFoursFivesOrSixes(dieArray, scoringCategory);
                case ScoringCategory.SmallStraight:
                    return IsSmallStraight(dieArray) ? dieArray.Sum() : 0;
                case ScoringCategory.LargeStraight:
                    return IsLargeStraight(dieArray) ? dieArray.Sum() : 0;
            }
        

            

            return -1;
        }

        private bool ValidateDieRollArray(int[] dieArray)
        {

            if (dieArray.Length != 5)
            {
                return false;
            }
            
            foreach (var dieValue in dieArray)
            {
                if (dieValue < 1 || dieValue > 6)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSmallStraight(int[] dieArray)
        {
            for (var i = 1; i < 6; i++)
            {
                if (!dieArray.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }
        
        private bool IsLargeStraight(int[] dieArray)
        {
            for (var i = 2; i < 7; i++)
            {
                if (!dieArray.Contains(i))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsYatzy(int[] dieArray)
        {
            return dieArray.All(x => x == dieArray[0]);
        }

        private int ScoreOnesTwosThreesFoursFivesOrSixes(int[] dieArray, ScoringCategory category)
        {
            switch (category)
            {
                case ScoringCategory.Ones:
                    return dieArray.Count(x => x == 1);
                case ScoringCategory.Twos:
                    return 2 * dieArray.Count(x => x == 2);
                case ScoringCategory.Threes:
                    return 3 * dieArray.Count(x => x == 3);
                case ScoringCategory.Fours:
                    return 4 * dieArray.Count(x => x == 4);
                case ScoringCategory.Fives:
                    return 5 * dieArray.Count(x => x == 5);
                case ScoringCategory.Sixes:
                    return 6 * dieArray.Count(x => x == 6);
            }
            
            throw new ArgumentException();
        }
        
    }
}