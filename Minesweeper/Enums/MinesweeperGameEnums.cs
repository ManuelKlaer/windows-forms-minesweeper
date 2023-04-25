namespace Minesweeper.Enums;

public static class MinesweeperGameEnums
{
    /// <summary>
    ///     Minesweeper-Game states.
    /// </summary>
    public enum GameState
    {
        Stopped,
        Paused, // ToDo: Paused needs to update StartTimeUtc - How to implement paused?
        Running
    }

    /// <summary>
    ///     Minesweeper-Game won or lost enum.
    /// </summary>
    public enum GameWonLost
    {
        Lost,
        Won
    }
}