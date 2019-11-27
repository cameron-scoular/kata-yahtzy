namespace kata_yahtzy
{
    public class TurnProcessor
    {

        public readonly IDieScoreCalculator DieScoreCalculator;
        public readonly IDieRoller DieRoller;
        public readonly IUserInterface UserInterface;
        public GameState GameState;

        public TurnProcessor(IDieScoreCalculator dieScoreCalculator, IDieRoller dieRoller, IUserInterface userInterface, GameState gameState)
        {
            DieScoreCalculator = dieScoreCalculator;
            DieRoller = dieRoller;
            GameState = gameState;
            UserInterface = userInterface;
        }

        public void PlayTurn()
        {
            GameState.StartTurn();
            UserInterface.TellUserStartingNewTurn(GameState);
                        
            var dieArray = DieRoller.RollDie();
            GameState.DecrementRollsLeft();
            
            while (GameState.RollsAreLeftInTurn())
            {
                UserInterface.ShowDieRoll(dieArray);
                
                if (UserInterface.AskIfUserWantsToScoreDie(GameState.NumberRollsLeftInTurn))
                {
                    ChooseCategoryAndScoreDieRoll(dieArray);
                    break;
                }
                
                var rerollDieArray = UserInterface.AskDieToReroll(dieArray);

                dieArray = DieRoller.RerollDie(dieArray, rerollDieArray);
                GameState.DecrementRollsLeft();
                
                if ( !GameState.RollsAreLeftInTurn() )
                {
                    ChooseCategoryAndScoreDieRoll(dieArray);
                    break;
                }
            }

            GameState.TurnNumber++;

        }

        private void ChooseCategoryAndScoreDieRoll(int[] dieArray)
        {
            UserInterface.ShowDieRoll(dieArray);
            var scoringCategory = UserInterface.AskScoringCategory(GameState.ScoreCategoryToScoreDictionary);
            var turnScore = DieScoreCalculator.ScoreDieRoll(dieArray, scoringCategory);
            GameState.AddScore(scoringCategory, turnScore);
        }
    }
}