using static Minesweeper.Enums.MinesweeperGameEnums;

namespace Minesweeper.Controllers.CustomEventArgs;

public class GameFinishedEventArgs : EventArgs
{
    public GameFinishedEventArgs(GameWonLost wonLostState)
    {
        WonLostState = wonLostState;
    }

    public GameWonLost WonLostState { get; }
}