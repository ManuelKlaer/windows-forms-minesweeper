namespace Minesweeper.Enums;

/// <summary>
///     A collection of enums for the minesweeper game.
/// </summary>
public static class MinesweeperGameEnums
{
    /// <summary>
    ///     Minesweeper-Game states.
    /// </summary>
    public enum GameState
    {
        Stopped,
        Paused,
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