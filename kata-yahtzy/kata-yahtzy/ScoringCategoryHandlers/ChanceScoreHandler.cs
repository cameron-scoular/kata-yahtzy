using System.Linq;

namespace kata_yahtzy
{
    public class ChanceScoreHandler : IScoreHandler
    {
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {
            return dieArray.Sum();
        }
    }
}