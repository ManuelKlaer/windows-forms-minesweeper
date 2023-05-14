namespace Minesweeper.Views.Interfaces;

/// <summary>
///     The interface for a component that supports text rendering.
/// </summary>
public interface IComponentText : IComponent
{
    /// <summary>
    ///     The rendered text of this <see cref="IComponentText" />.
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
    ///     The text / foreground color of this <see cref="IComponentText" />.
    /// </summary>
    public Color ForeColor { get; set; }
}