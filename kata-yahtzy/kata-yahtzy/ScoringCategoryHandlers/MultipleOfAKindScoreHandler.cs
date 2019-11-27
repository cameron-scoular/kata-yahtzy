using System.Collections.Generic;
using System.Linq;

namespace kata_yahtzy
{
    public class MultipleOfAKindScoreHandler : IScoreHandler
    {
        private readonly Dictionary<ScoringCategory, int> CategoryToIntegerDictionary = new Dictionary<ScoringCategory, int>()
        {
            {ScoringCategory.Pair, 2},
            {ScoringCategory.ThreeOfAKind, 3},
            {ScoringCategory.FourOfAKind, 4}
        };
        
        public int ScoreCategory(int[] dieArray, ScoringCategory category)
        {
            var kindNumber = CategoryToIntegerDictionary[category];

            var kindList = dieArray.GroupBy(g => g).Where(x => x.Count() >= kindNumber).Select(g => g.Key).ToList();

            if (kindList.Count() != 0)
            {
                return kindList.Last() * kindNumber;
            }

            return 0;
        }
    }
}