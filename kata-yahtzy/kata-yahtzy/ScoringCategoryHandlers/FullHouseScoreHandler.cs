using System;
using System.Linq;

namespace kata_yahtzy
{
    public class FullHouseScoreHandler : IScoreHandler
    {
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {

            try
            {
                var fullHousePairValue = dieArray.GroupBy(g => g).Where(x => x.Count() == 2).Select(g => g.Key).First();
                var fullHouseThreeValue = dieArray.GroupBy(g => g).Where(x => x.Count() == 3).Select(g => g.Key).First();
                return dieArray.Sum();
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
            
        }
    }
}