using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace kata_yahtzy
{
    public class DefaultDieScoreCalculator : IDieScoreCalculator
    {
        private readonly Dictionary<ScoringCategory, IScoreHandler> ScoringCategoryHandlerDictionary;

        public DefaultDieScoreCalculator()
        {
            ScoringCategoryHandlerDictionary = new Dictionary<ScoringCategory, IScoreHandler>()
            {
                {ScoringCategory.Chance, new ChanceScoreHandler()},
                {ScoringCategory.Yatzy, new YatzyScoreHandler()},
                {ScoringCategory.Ones, new RepeatedSingleDieScoreHandler()},
                {ScoringCategory.Twos, new RepeatedSingleDieScoreHandler()},
                {ScoringCategory.Threes, new RepeatedSingleDieScoreHandler()},
                {ScoringCategory.Fours, new RepeatedSingleDieScoreHandler()},
                {ScoringCategory.Fives, new RepeatedSingleDieScoreHandler()},
                {ScoringCategory.Sixes, new RepeatedSingleDieScoreHandler()},
                {ScoringCategory.Pair, new MultipleOfAKindScoreHandler()},
                {ScoringCategory.TwoPair, new TwoPairScoreHandler()},
                {ScoringCategory.ThreeOfAKind, new MultipleOfAKindScoreHandler()},
                {ScoringCategory.FourOfAKind, new MultipleOfAKindScoreHandler()},
                {ScoringCategory.SmallStraight, new StraightScoreHandler()},
                {ScoringCategory.LargeStraight, new StraightScoreHandler()},
                {ScoringCategory.FullHouse, new FullHouseScoreHandler()}
            };
        }

        public int ScoreDieRoll(int[] dieArray, ScoringCategory scoringCategory)
        {
            
            if (!ValidateDieRollArray(dieArray))
            {
                throw new ArgumentException();
            }

            return ScoringCategoryHandlerDictionary[scoringCategory].ScoreCategory(dieArray, scoringCategory);

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