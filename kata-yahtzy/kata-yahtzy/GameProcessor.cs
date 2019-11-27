using System;
using System.Collections.Generic;

namespace kata_yahtzy
{
    public class GameProcessor
    {
        private readonly IUserInterface UserInterface;
        private readonly List<Player> PlayerList;

        public bool GameIsActive
        {
            get
            {
                foreach (var player in PlayerList)
                {
                    foreach (var score in player.PlayerGameState.ScoreCategoryToScoreDictionary)
                    {
                        if (score.Value == null)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public GameProcessor(IUserInterface userInterface, List<Player> playerList)
        {
            UserInterface = userInterface;
            PlayerList = playerList;
        }

        public void InitializeNewGame()
        {
            foreach (var player in PlayerList)
            {
                player.PlayerGameState.ResetGameState();
            }
        }

        public void PlayGame()
        {
            UserInterface.TellUserGameStarting();
            
            while (GameIsActive)
            {
                foreach (var player in PlayerList)
                {
                    player.PlayerTurnProcessor.PlayTurn(player);
                }
            }

            UserInterface.TellUsersGameCompleted();

            foreach (var player in PlayerList)
            {
                UserInterface.TellUserCurrentCategoryScores(player);
            }
        }
        
        
    }
}