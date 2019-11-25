using NUnit.Framework;

namespace kata_yahtzy
{
    public class PairTwoPairsThreeOfAKindFourOfAKindAndFullHouseScoringTests
    {
        
        private DieScoreCalculator DieScoreCalculator;
        
        [SetUp]
        public void Setup()
        {
            DieScoreCalculator = new DieScoreCalculator();
            
        }

        [Test]
        public void ScoreDieRoll_SumOfPairScore_WithValidPairDieArray()
        {

            var dieArray = new[] {1, 1, 2, 3, 4};
            
            Assert.AreEqual(2, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Pair));

            dieArray = new[] {1, 1, 2, 2, 4};
            
            Assert.AreEqual(4, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Pair));

            dieArray = new[] {3, 4, 4, 3, 4};
            
            Assert.AreEqual(8, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Pair));

        }
        
        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidPairDieArray()
        {
            var dieArray = new[] {1, 2, 3, 4, 5};
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Pair));
        }

        [Test]
        public void ScoreDieRoll_SumOfThreeScore_WithValidThreeDieArray()
        {
            var dieArray = new[] {1, 1, 1, 3, 4};
            
            Assert.AreEqual(3, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.ThreeOfAKind));

            dieArray = new[] {1, 2, 2, 2, 4};
            
            Assert.AreEqual(6, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.ThreeOfAKind));

            dieArray = new[] {3, 3, 4, 3, 4};
            
            Assert.AreEqual(9, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.ThreeOfAKind));

        }

        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidThreeDieArray()
        {
            var dieArray = new[] {1, 2, 3, 4, 4};
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.ThreeOfAKind));
        }

        [Test]
        public void ScoreDiceRoll_SumOfTwoPairs_WithValidTwoPairsArray()
        {
            var dieArray = new[] {1, 1, 2, 2, 4};
            
            Assert.AreEqual(6, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.TwoPair));

            dieArray = new[] {6, 5, 6, 5, 3};
            
            Assert.AreEqual(22, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.TwoPair));
            
        }

        [Test]
        public void ScoreDiceRoll_ZeroScore_WithValidTwoPairsArray()
        {
            var dieArray = new[] {2, 2, 3, 4, 5};
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.TwoPair));
            
            dieArray = new[] {2, 1, 3, 4, 5};
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.TwoPair));
        }

        [Test]
        public void ScoreDiceRoll_SumOfFourOfAKind_WithValidFourOfAKindArray()
        {
            var dieArray = new[] {4, 4, 4, 1, 4};
            Assert.AreEqual(16, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.FourOfAKind));
            
            dieArray = new[] {4, 3, 3, 3, 3};
            Assert.AreEqual(12, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.FourOfAKind));
        }

        [Test]
        public void ScoreDiceRoll_ZeroScore_WithValidFourOfAKindArray()
        {
            var dieArray = new[] {1, 1, 1, 4, 5};
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.FourOfAKind));
        }

        [Test]
        public void ScoreDiceRoll_SumOfFullHouse_WithValidFullHouseArray()
        {
            var dieArray = new[] {1, 1, 2, 1, 2};
            Assert.AreEqual(7, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.FullHouse));

            dieArray = new[] {5, 4, 5, 4, 5};
            Assert.AreEqual(23, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.FullHouse));
        }

        public void ScoreDiceRoll_ZeroScore_WithValidFullHouseArray()
        {
            var dieArray = new[] {1, 1, 1, 3, 4};
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.FullHouse));

            dieArray = new[] {2, 3, 4, 4, 5};
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.FullHouse));
        }

    }
}