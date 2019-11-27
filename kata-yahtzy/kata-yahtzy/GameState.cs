using System.Collections.Generic;
using System.Dynamic;

namespace kata_yahtzy
{
    public class GameState
    {
        
        public int NumberRollsLeftInTurn { get; private set; }

        public int TurnNumber;

        public int TotalScore
        {
            get
            {
                var totalScore = 0;
                foreach (var (scoreCategory, score) in ScoreCategoryToScoreDictionary)
                {
                    if (score != null)
                    {
                        totalScore += score.Value;
                    }
                }

                return totalScore;
            }
        }

        public bool IsPlaying => TurnNumber <= ScoreCategoryToScoreDictionary.Count;

        public Dictionary<ScoringCategory, int?> ScoreCategoryToScoreDictionary;

        public void InitializeScoreCategoryToScoreDictionary()
        {
            ScoreCategoryToScoreDictionary = new Dictionary<ScoringCategory, int?>()
            {
                {ScoringCategory.Chance, null},
                {ScoringCategory.Yatzy, null},
                {ScoringCategory.Ones, null},
                {ScoringCategory.Twos, null},
                {ScoringCategory.Threes, null},
                {ScoringCategory.Fours, null},
                {ScoringCategory.Fives, null},
                {ScoringCategory.Sixes, null},
                {ScoringCategory.Pair, null},
                {ScoringCategory.TwoPair, null},
                {ScoringCategory.ThreeOfAKind, null},
                {ScoringCategory.FourOfAKind, null},
                {ScoringCategory.SmallStraight, null},
                {ScoringCategory.LargeStraight, null},
                {ScoringCategory.FullHouse, null}
            };
        }

        public void ResetGameState()
        {
            TurnNumber = 1;
            InitializeScoreCategoryToScoreDictionary();
        }

        public void StartTurn()
        {
            NumberRollsLeftInTurn = 3;
        }

        public void DecrementRollsLeft()
        {
            NumberRollsLeftInTurn--;
        }

        public bool RollsAreLeftInTurn()
        {
            return NumberRollsLeftInTurn != 0;
        }

        public void AddScore(ScoringCategory category, int score)
        {
            ScoreCategoryToScoreDictionary[category] = score;
        }

    }
}