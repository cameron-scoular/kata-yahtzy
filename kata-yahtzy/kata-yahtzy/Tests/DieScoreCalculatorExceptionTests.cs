using System;
using NUnit.Framework;

namespace kata_yahtzy
{
    public class DieScoreCalculatorExceptionTests
    {
        private DiceScoreCalculator DiceScoreCalculator;
        
        [SetUp]
        public void Setup()
        {
            DiceScoreCalculator = new DiceScoreCalculator();
        }
        
        [Test]
        public void ScoreDieRoll_ThrowsException_WithTooLongDieArray()
        {

            var dieArray = new int[] {1, 2, 3, 4, 5, 6};

            try
            {
                var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
                Assert.Fail();
            }
            catch (Exception e)
            {
            }
            
        }
        
        [Test]
        public void ScoreDieRoll_ThrowsException_WithTooShortDieArray()
        {

            var dieArray = new int[] {1, 2, 3, 4};

            try
            {
                var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
                Assert.Fail();
            }
            catch (Exception e)
            {
            }
            
        }
        
        [Test]
        public void ScoreDieRoll_ThrowsException_WithTooHighDieValue()
        {

            var dieArray = new int[] {1, 3, 4, 7, 6};

            try
            {
                var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
                Assert.Fail();
            }
            catch (Exception e)
            {
            }
            
        }
        
        [Test]
        public void ScoreDieRoll_ThrowsException_WithNegativeDieValue()
        {

            var dieArray = new int[] {1, 2, 4, -5, 6};

            try
            {
                var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
                Assert.Fail();
            }
            catch (Exception e)
            {
            }
            
        }
        
        [Test]
        public void ScoreDieRoll_ThrowsException_WithZeroDieValue()
        {

            var dieArray = new int[] {1, 3, 3, 4, 0};

            try
            {
                var score = DiceScoreCalculator.ScoreDieRoll(dieArray, ScoringCategory.Chance);
                Assert.Fail();
            }
            catch (Exception e)
            {
            }
            
        }
    }
}