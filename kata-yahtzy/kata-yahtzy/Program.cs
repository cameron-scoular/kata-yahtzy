using System.Collections.Generic;

namespace kata_yahtzy
{
    static class Program
    {
        static void Main(string[] args)
        {

            var scoringCategoryDisplayStringDict = new Dictionary<ScoringCategory, string>()
            {
                {ScoringCategory.Chance, "Chance"},
                {ScoringCategory.Yatzy, "Yatzy"},
                {ScoringCategory.Ones, "Ones"},
                {ScoringCategory.Twos, "Twos"},
                {ScoringCategory.Threes, "Threes"},
                {ScoringCategory.Fours, "Fours"},
                {ScoringCategory.Fives, "Fives"},
                {ScoringCategory.Sixes, "Sixes"},
                {ScoringCategory.Pair, "Pair"},
                {ScoringCategory.TwoPair, "Two Pairs"},
                {ScoringCategory.ThreeOfAKind, "Three of a Kind"},
                {ScoringCategory.FourOfAKind, "Four of a kind"},
                {ScoringCategory.SmallStraight, "Small Straight"},
                {ScoringCategory.LargeStraight, "Large Straight"},
                {ScoringCategory.FullHouse, "Full House"}
            };
            
            var dieScoreCalculator = new DefaultDieScoreCalculator();
            var dieRoller = new RandomDieRoller();
            var userInterface = new ConsoleUserInterface(scoringCategoryDisplayStringDict);
            var gameState = new GameState();
            var turnProcessor = new TurnProcessor(dieScoreCalculator, dieRoller, userInterface, gameState);
            var gameProcessor = new GameProcessor(turnProcessor, gameState, userInterface);
            
            gameProcessor.InitializeNewGame();
            gameProcessor.PlayGame();
            
        }
    }
}