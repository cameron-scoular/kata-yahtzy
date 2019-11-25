using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace kata_yahtzy
{
    public class ChanceStraightAndYahtzyScoringTests
    {
        private DiceScoreCalculator DiceScoreCalculator;
        
        [SetUp]
        public void Setup()
        {
            DiceScoreCalculator = new DiceScoreCalculator();
            
        }

        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidChanceDieArray()
        {

            var dieArray = new int[] {1, 2, 3, 2, 5};

            var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
            
            Assert.AreEqual(13, score);

        }
        
        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidChanceDieArrayWithSameNumber()
        {

            var dieArray = new int[] {2, 2, 2, 2, 2};

            var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
            
            Assert.AreEqual(10, score);

        }
        
        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidSmallStraightDieArray()
        {

            var dieArray = new int[] {1, 2, 3, 4, 5};

            var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.SmallStraight);
            
            Assert.AreEqual(15, score);

        }
        
        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidSmallStraightDieArray()
        {

            var dieArray = new int[] {1, 2, 4, 4, 5};

            var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.SmallStraight);
            
            Assert.AreEqual(0, score);

        }
        
        [Test]
        public void ScoreDieRoll_SumOfDie_WithValidLargeStraightDieArray()
        {

            var dieArray = new int[] {2, 3, 4, 5, 6};

            var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.LargeStraight);
            
            Assert.AreEqual(20, score);

        }
        
        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidLargeStraightDieArray()
        {

            var dieArray = new int[] {2, 3, 5, 5, 6};

            var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.LargeStraight);
            
            Assert.AreEqual(0, score);

        }

        [Test]
        public void ScoreDieRoll_FullScore_WithValidYatzyDieArray()
        {
            var dieArray = new int[5];

            for (int i = 1; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    dieArray[j] = i;
                }

                Assert.AreEqual(50, DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Yatzy));

            }
        }
        
        [Test]
        public void ScoreDieRoll_ZeroScore_WithValidYatzyDieArray()
        {
            var dieArray = new int[5]{1, 2, 1, 1, 1};
            
            Assert.AreEqual(0, DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Yatzy));
            
        }
       
        
    }
}