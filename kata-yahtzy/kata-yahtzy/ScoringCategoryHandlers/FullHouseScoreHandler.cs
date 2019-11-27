using System;
using System.Linq;

namespace kata_yahtzy
{
    public class FullHouseScoreHandler : IScoreHandler
    {
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {

            var fullHousePairs = dieArray.GroupBy(g => g).Where(x => x.Count() == 2).Select(g => g.Key);
            var fullHouseThrees = dieArray.GroupBy(g => g).Where(x => x.Count() == 3).Select(g => g.Key);

            if (fullHousePairs.Count() != 0 && fullHouseThrees.Count() != 0)
            {
                return dieArray.Sum();
            }

            return 0;
        }
    }
}