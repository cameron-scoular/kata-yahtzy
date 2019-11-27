using System;

namespace kata_yahtzy
{
    public class GameProcessor
    {
        public readonly TurnProcessor TurnProcessor;
        public GameState GameState;
        public readonly IUserInterface UserInterface;
        
        public GameProcessor(TurnProcessor turnProcessor, GameState gameState, IUserInterface userInterface)
        {
            TurnProcessor = turnProcessor;
            GameState = gameState;
            UserInterface = userInterface;
        }

        public void InitializeNewGame()
        {
            GameState.ResetGameState();
        }

        public void PlayGame()
        {
            UserInterface.TellUserGameStarting();
            
            while (GameState.IsPlaying)
            {
                TurnProcessor.PlayTurn();
                
            }

            UserInterface.TellUserGameCompleted();
            UserInterface.TellUserCurrentCategoryScores(GameState);            
        }
        
        
    }
}