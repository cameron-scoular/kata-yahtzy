using System.Linq;

namespace kata_yahtzy
{
    public class YatzyScoreHandler : IScoreHandler
    {
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {
            return dieArray.All(x => x == dieArray[0]) ? 50 : 0;
        }
    }
}