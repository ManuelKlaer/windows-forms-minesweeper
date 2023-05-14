namespace Minesweeper.Views.Interfaces;

/// <summary>
///     The interface for an overlay that supports text rendering.
/// </summary>
public interface IOverlayText : IOverlay
{
    /// <summary>
    ///     The rendered text of this <see cref="IOverlayText" />.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///     The font for the <see cref="Text" />.
    /// </summary>
    public Font Font { get; set; }

    /// <summary>
    ///     Formatting rules for the <see cref="Text" />.
    /// </summary>
    public StringFormat TextFormat { get; set; }

    /// <summary>
    ///     The text color of this <see cref="IOverlayText" />.
    /// </summary>
    public Color TextColor { get; set; }
}