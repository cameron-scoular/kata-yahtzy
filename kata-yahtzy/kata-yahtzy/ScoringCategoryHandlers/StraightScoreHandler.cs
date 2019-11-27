using System.Linq;

namespace kata_yahtzy
{
    public class StraightScoreHandler : IScoreHandler
    {
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {
            for (var i = 2; i < 6; i++)
            {
                if (!dieArray.Contains(i)) return 0;
            }

            return dieArray.Contains(1) ? 15 : dieArray.Contains(6) ? 20 : 0;
        }
    }
}