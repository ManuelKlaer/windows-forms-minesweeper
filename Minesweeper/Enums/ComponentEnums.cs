namespace Minesweeper.Enums;

public static class ComponentEnums
{
    [Flags]
    public enum MouseState
    {
        None = 0,
        Hover = 1 << 0,
        Press = 1 << 1
    }
}