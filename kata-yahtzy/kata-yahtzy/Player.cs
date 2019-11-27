namespace kata_yahtzy
{
    public class Player
    {
        public PlayerGameState PlayerGameState;
        public readonly PlayerTurnProcessor PlayerTurnProcessor;
        public readonly string PlayerName;

        public Player(PlayerGameState gameState, PlayerTurnProcessor turnProcessor, string playerName)
        {
            PlayerGameState = gameState;
            PlayerGameState.ResetGameState();
            PlayerTurnProcessor = turnProcessor;
            PlayerName = playerName;
        }
        
    }
}