using System;
using System.Collections.Generic;
using System.Linq;

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
        
    }
}