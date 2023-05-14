namespace Minesweeper.Views.Interfaces;

/// <summary>
///     The interface for an overlay.
/// </summary>
public interface IOverlay
{
    /// <summary>
    ///     Whether this overlay is currently active.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    ///     Overlay background color.
    /// </summary>
    public Color BackgroundColor { get; set; }

    /// <summary>
    ///     Render this <see cref="IOverlay" /> to the screen.
    /// </summary>
    /// <param name="clientRectangle">The client <see cref="Rectangle" /> of the screen.</param>
    /// <param name="graphics">The <see cref="Graphics" /> object to draw this <see cref="IOverlay" /> onto.</param>
    public void Paint(Rectangle clientRectangle, Graphics graphics);
}