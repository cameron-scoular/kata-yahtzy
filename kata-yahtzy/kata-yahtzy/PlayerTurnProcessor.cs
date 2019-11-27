namespace kata_yahtzy
{
    public class PlayerTurnProcessor
    {

        private readonly IDieScoreCalculator DieScoreCalculator;
        private readonly IDieRoller DieRoller;
        private readonly IUserInterface UserInterface;
        private PlayerGameState PlayerGameState;

        public PlayerTurnProcessor(IDieScoreCalculator dieScoreCalculator, IDieRoller dieRoller, IUserInterface userInterface, PlayerGameState playerGameState)
        {
            DieScoreCalculator = dieScoreCalculator;
            DieRoller = dieRoller;
            PlayerGameState = playerGameState;
            UserInterface = userInterface;
        }

        public void PlayTurn(Player player)
        {
            PlayerGameState.StartTurn();
            UserInterface.TellUserStartingNewTurn(player);
                        
            var dieArray = DieRoller.RollDie();
            PlayerGameState.DecrementRollsLeft();
            
            while (PlayerGameState.RollsAreLeftInTurn())
            {
                UserInterface.ShowDieRoll(dieArray);
                
                if (UserInterface.AskIfUserWantsToScoreDie(PlayerGameState.NumberRollsLeftInTurn))
                {
                    ChooseCategoryAndScoreDieRoll(dieArray);
                    break;
                }
                
                var rerollDieArray = UserInterface.AskDieToReroll(dieArray);

                dieArray = DieRoller.RerollDie(dieArray, rerollDieArray);
                PlayerGameState.DecrementRollsLeft();
                
                if ( !PlayerGameState.RollsAreLeftInTurn() )
                {
                    ChooseCategoryAndScoreDieRoll(dieArray);
                    break;
                }
            }
        }

        private void ChooseCategoryAndScoreDieRoll(int[] dieArray)
        {
            UserInterface.ShowDieRoll(dieArray);
            var scoringCategory = UserInterface.AskScoringCategory(PlayerGameState.ScoreCategoryToScoreDictionary);
            var turnScore = DieScoreCalculator.ScoreDieRoll(dieArray, scoringCategory);
            PlayerGameState.AddScore(scoringCategory, turnScore);
        }
    }
}