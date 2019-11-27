using System.Collections.Generic;
using NUnit.Framework;

namespace kata_yahtzy
{
    public class PlayerFactory
    {

        public List<Player> CreateNPlayers(int n, IDieScoreCalculator dieScoreCalculator, IDieRoller dieRoller,
            IUserInterface userInterface)
        {
            var playerList = new List<Player>();

            for (var i = 0; i < n; i++)
            {
                var playerName = string.Format("Player {0}", i + 1);
                playerList.Add(CreateNewPlayer(dieScoreCalculator, dieRoller, userInterface, playerName));
            }

            return playerList;
        }
        
        public Player CreateNewPlayer(IDieScoreCalculator dieScoreCalculator, IDieRoller dieRoller, IUserInterface userInterface, string playerName)
        {
            var gameState = new PlayerGameState();
            var playerTurnProcessor = new PlayerTurnProcessor(dieScoreCalculator, dieRoller, userInterface, gameState);
            return new Player(gameState, playerTurnProcessor, playerName);
        }
    }
}