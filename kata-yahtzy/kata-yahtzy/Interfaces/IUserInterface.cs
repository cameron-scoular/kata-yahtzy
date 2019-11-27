using System.Collections.Generic;

namespace kata_yahtzy
{
    public interface IUserInterface
    {
        bool AskIfUserWantsToScoreDie(int rerollsLeft);

        ScoringCategory AskScoringCategory(Dictionary<ScoringCategory, int?> categoryDict);

        bool[] AskDieToReroll(int[] dieArray);

        void ShowDieRoll(int[] dieArray);

        void TellUserStartingNewTurn(GameState gameState);

        void TellUserCurrentCategoryScores(GameState gameState);

        void TellUserGameStarting();

        void TellUserGameCompleted();
    }
}