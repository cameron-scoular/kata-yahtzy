using System.Linq;

namespace kata_yahtzy
{
    public class TwoPairScoreHandler : IScoreHandler
    {
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {
            
            var pairValues = dieArray.GroupBy(g => g).Where(x => x.Count() >= 2).Select(g => g.Key).ToList();

            return pairValues.Count() == 2 ? 2 * pairValues.Sum() : 0;
            

            
        }
    }
}