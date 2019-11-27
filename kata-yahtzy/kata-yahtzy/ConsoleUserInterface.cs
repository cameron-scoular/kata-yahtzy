using System;
using System.Collections.Generic;

namespace kata_yahtzy
{
    public class ConsoleUserInterface : IUserInterface
    {
        private IDictionary<ScoringCategory, string> _scoringCategoryDisplayStringDictionary;

        public ConsoleUserInterface(IDictionary<ScoringCategory, string> scoringCategoryDisplayStringDict)
        {
            _scoringCategoryDisplayStringDictionary = scoringCategoryDisplayStringDict;
        }
        
        public bool AskIfUserWantsToScoreDie(int rerollsLeft)
        {
            
            Console.WriteLine("You have {0} rerolls left. Do you wish to score this die roll (y/n)?", rerollsLeft);
            var response = Console.ReadLine();

            if (response.ToLower() == "y")
            {
                return true;
            }

            return false;
        }

        public ScoringCategory AskScoringCategory(Dictionary<ScoringCategory, int?> categoryDict)
        {
            
            Console.WriteLine("What scoring category do you wish to use?");
            Console.WriteLine("Available scoring categories are:");

            var categoryIndex = 1;
            var remainingCategoryDictionary = new Dictionary<int, ScoringCategory>();

            foreach (var (scoringCategory, score) in categoryDict)
            {
                if (score == null)
                {
                    Console.WriteLine("{0}: {1}", categoryIndex, _scoringCategoryDisplayStringDictionary[scoringCategory]);
                    remainingCategoryDictionary[categoryIndex] = scoringCategory;
                    categoryIndex++;
                }
            }
            
            Console.WriteLine("Enter the index of your chosen scoring category:");
            var responseIndex = Console.ReadLine();

            return remainingCategoryDictionary[int.Parse(responseIndex)];

        }

        public bool[] AskDieToReroll(int[] dieArray)
        {
            
            Console.WriteLine("Choose which die to reroll (using binary string e.g. 10010, where 1 => reroll, and 0 => keep)");
            var response = Console.ReadLine();

            var rerollArray = new bool[5];
            
            for (var i = 0; i < 5; i++)
            {
                var binaryChar = response[i];
                
                if (binaryChar == '1')
                {
                    rerollArray[i] = true;
                }
                else
                {
                    rerollArray[i] = false;
                }
            }

            return rerollArray;
        }

        public void ShowDieRoll(int[] dieArray)
        {
            Console.WriteLine("Current die roll:");
            foreach(var die in dieArray)
            {
                Console.Write(die + "    ");
            }
        }

        public void TellUserStartingNewTurn(Player player)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Starting {0}'s turn {1}", player.PlayerName, player.PlayerGameState.TurnNumber);
            Console.WriteLine("--------------------------------------------------------------------------");
            TellUserCurrentCategoryScores(player);
            Console.WriteLine("--------------------------------------------------------------------------");
        }

        public void TellUserCurrentCategoryScores(Player player)
        {
            Console.WriteLine("Score categories for {0}:", player.PlayerName);

            foreach (var (category, score) in player.PlayerGameState.ScoreCategoryToScoreDictionary)
            {
                if (score != null)
                {
                    Console.WriteLine("{0}: {1}", _scoringCategoryDisplayStringDictionary[category], score);
                }
                else
                {
                    Console.WriteLine("{0}: Unscored", _scoringCategoryDisplayStringDictionary[category]);
                }
            }
            
            Console.WriteLine("{0} Total Score: {1}", player.PlayerName, player.PlayerGameState.TotalScore);
        }

        public void TellUserGameStarting()
        {
            Console.WriteLine("New game is starting...");
        }

        public void TellUsersGameCompleted()
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Game Completed");
            
        }
    }
}