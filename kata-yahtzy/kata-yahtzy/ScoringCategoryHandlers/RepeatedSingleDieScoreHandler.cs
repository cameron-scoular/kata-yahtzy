using System;
using System.Linq;

namespace kata_yahtzy
{
    public class RepeatedSingleDieScoreHandler : IScoreHandler
    {
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
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
            
            throw new ArgumentException();        }
    }
}