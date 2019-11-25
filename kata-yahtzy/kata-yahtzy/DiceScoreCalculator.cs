using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_yahtzy
{
    public class DiceScoreCalculator
    {

        public int ScoreDieRoll(int[] dieArray, ScoringCategory scoringCategory)
        {
            
            if (!ValidateDieRollArray(dieArray))
            {
                throw new ArgumentException();
            }
            
            if (scoringCategory == ScoringCategory.Chance)
            {
                return dieArray.Sum();
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
        
    }
}