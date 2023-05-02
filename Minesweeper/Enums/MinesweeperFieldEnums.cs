using Minesweeper.Views.Components;

namespace Minesweeper.Enums;

/// <summary>
///     A collection of enums for the MinesweeperField-Component
/// </summary>
public static class MinesweeperFieldEnums
{
    /// <summary>
    ///     State a <see cref="MinesweeperField" /> can have.
    /// </summary>
    public enum State
    {
        Hidden,
        Flag,
        Question,
        Mine,
        Tip,
        Visible
    }
}