using System.Collections.Generic;

namespace kata_yahtzy
{
    static class Program
    {
        static readonly Dictionary<ScoringCategory, string> ScoringCategoryDisplayStringDict = new Dictionary<ScoringCategory, string>()
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
        
        static void Main(string[] args)
        {
            
            var dieScoreCalculator = new DefaultDieScoreCalculator();
            var dieRoller = new RandomDieRoller();
            var userInterface = new ConsoleUserInterface(ScoringCategoryDisplayStringDict);
            
            var playerFactory = new PlayerFactory();

            var playerList = playerFactory.CreateNPlayers(2, dieScoreCalculator, dieRoller, userInterface);
            
            var gameProcessor = new GameProcessor(userInterface, playerList);
            
            gameProcessor.InitializeNewGame();
            gameProcessor.PlayGame();
            
        }
    }
}