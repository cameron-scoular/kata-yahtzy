using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_yahtzy
{
    public class RepeatedSingleDieScoreHandler : IScoreHandler
    {
        private Dictionary<ScoringCategory, int> CategoryToIntegerDictionary = new Dictionary<ScoringCategory, int>()
        {
            {ScoringCategory.Ones, 1},
            {ScoringCategory.Twos, 2},
            {ScoringCategory.Threes, 3},
            {ScoringCategory.Fours, 4},
            {ScoringCategory.Fives, 5},
            {ScoringCategory.Sixes, 6}
        };
        
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {
            var categoryInt = CategoryToIntegerDictionary[category];
            return categoryInt * dieArray.Count(x => x == categoryInt);
        }
    }
}