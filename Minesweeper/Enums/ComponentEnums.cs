namespace Minesweeper.Enums;

/// <summary>
///     A collection of enums for the components.
/// </summary>
public static class ComponentEnums
{
    /// <summary>
    ///     Enum for the current state of the mouse.
    /// </summary>
    [Flags]
    public enum MouseState
    {
        None = 0,
        Hover = 1 << 0,
        Press = 1 << 1
    }
}