using static Minesweeper.Enums.MinesweeperGameEnums;

namespace Minesweeper.Controllers.CustomEventArgs;

/// <summary>
///     Event args for the <see cref="MinesweeperBoardController" /> to tell the won / lost state.
/// </summary>
public class GameFinishedEventArgs : EventArgs
{
    /// <summary>
    ///     Initialize a new instance of <see cref="GameFinishedEventArgs" />.
    /// </summary>
    /// <param name="wonLostState">Whether the game was won or lost.</param>
    public GameFinishedEventArgs(GameWonLost wonLostState) => WonLostState = wonLostState;

    /// <summary>
    ///     Whether the game was won or lost.
    /// </summary>
    public GameWonLost WonLostState { get; }
}