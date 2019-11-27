using System;
using System.Linq;
using System.Security.Cryptography;
using NUnit.Framework;

namespace kata_yahtzy
{
    public class OneTwoThreeFourFiveAndSixScoringTests
    {
        private DefaultDieScoreCalculator _defaultDieScoreCalculator;
        
        [SetUp]
        public void Setup()
        {
            _defaultDieScoreCalculator = new DefaultDieScoreCalculator();
            
        }

        [Test]
        public void ScoreDieRoll_MaxSumScore_WithValidNumberArray()
        {

            var dieArray = new int[5];
            
            for (var dieNumber = 1; dieNumber <= 6; dieNumber++)
            {
                for (var i = 0; i < 5; i++)
                {
                    dieArray[i] = dieNumber;
                }

                Assert.AreEqual(dieArray.Sum(), _defaultDieScoreCalculator.ScoreDieRoll(dieArray, MapIntToScoringCategory(dieNumber)));
            }
            
        }
        
        [Test]
        public void ScoreDieRoll_SumScore_WithValidNumberArray()
        {
            var dieArray = new int[5] {1, 1, 2, 4, 5};

            Assert.AreEqual(2, _defaultDieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Ones));

            dieArray = new int[5] {2, 2, 2, 4, 5};

            Assert.AreEqual(6, _defaultDieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Twos));

            dieArray = new int[5] {3, 3, 3, 3, 5};

            Assert.AreEqual(12, _defaultDieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Threes));

            dieArray = new int[5] {4, 3, 3, 3, 5};

            Assert.AreEqual(4, _defaultDieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Fours));

            dieArray = new int[5] {5, 3, 3, 3, 5};

            Assert.AreEqual(10, _defaultDieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Fives));

            dieArray = new int[5] {6, 3, 6, 3, 5};

            Assert.AreEqual(12, _defaultDieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Sixes));

        }

        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidNumberArray()
        {
            var dieArray = new int[5] {1, 3, 5, 5, 5};
            
            Assert.AreEqual(0, _defaultDieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Fours));
        }
        

        private ScoringCategory MapIntToScoringCategory(int integer)
        {
            switch (integer)
            {
                case 1:
                    return ScoringCategory.Ones;
                case 2:
                    return ScoringCategory.Twos;
                case 3:
                    return ScoringCategory.Threes;
                case 4:
                    return ScoringCategory.Fours;
                case 5:
                    return ScoringCategory.Fives;
                case 6:
                    return ScoringCategory.Sixes;
            }

            throw new ArgumentException();
        }
    }
}