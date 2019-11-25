using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace kata_yahtzy
{
    public class ChanceStraightAndYahtzyScoringTests
    {
        private DieScoreCalculator DieScoreCalculator;
        
        [SetUp]
        public void Setup()
        {
            DieScoreCalculator = new DieScoreCalculator();
            
        }

        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidChanceDieArray()
        {

            var dieArray = new int[] {1, 2, 3, 2, 5};

            var score = DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
            
            Assert.AreEqual(13, score);

        }
        
        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidChanceDieArrayWithSameNumber()
        {

            var dieArray = new int[] {2, 2, 2, 2, 2};

            var score = DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
            
            Assert.AreEqual(10, score);

        }
        
        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidSmallStraightDieArray()
        {

            var dieArray = new int[] {1, 2, 3, 4, 5};

            var score = DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.SmallStraight);
            
            Assert.AreEqual(15, score);

        }
        
        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidSmallStraightDieArray()
        {

            var dieArray = new int[] {1, 2, 4, 4, 5};

            var score = DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.SmallStraight);
            
            Assert.AreEqual(0, score);

        }
        
        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidLargeStraightDieArray()
        {

            var dieArray = new int[] {2, 3, 4, 5, 6};

            var score = DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.LargeStraight);
            
            Assert.AreEqual(20, score);

        }
        
        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidLargeStraightDieArray()
        {

            var dieArray = new int[] {2, 3, 5, 5, 6};

            var score = DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.LargeStraight);
            
            Assert.AreEqual(0, score);

        }

        [Test]
        public void ScoreDieRoll_FullScore_WithValidYatzyDieArray()
        {
            var dieArray = new int[5];

            for (int dieNumber = 1; dieNumber <= 6; dieNumber++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dieArray[j] = dieNumber;
                }

                Assert.AreEqual(50, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Yatzy));

            }
        }
        
        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidYatzyDieArray()
        {
            var dieArray = new int[5]{1, 2, 1, 1, 1};
            
            Assert.AreEqual(0, DieScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Yatzy));
            
        }
       
        
    }
}