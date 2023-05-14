using Minesweeper.Views.Interfaces;

namespace Minesweeper.Views.Overlays;

/// <summary>
///     A <see cref="IOverlayText" /> that implements basic text overlay functionality.
/// </summary>
public class BasicTextOverlay : IOverlayText
{
    /// <summary>
    ///     Initialize a new instance of <see cref="BasicTextOverlay" />.
    /// </summary>
    public BasicTextOverlay()
    {
    }

    /// <inheritdoc cref="IOverlay.Enabled" />
    public bool Enabled { get; set; } = true;

    /// <inheritdoc cref="IOverlayText.Text" />
    public string Text { get; set; } = "";

    /// <inheritdoc cref="IOverlayText.TextColor" />
    public Color TextColor { get; set; } = Color.White;

    /// <inheritdoc cref="IOverlay.BackgroundColor" />
    public Color BackgroundColor { get; set; } = Color.Black;

    /// <inheritdoc cref="IOverlayText.Font" />
    public Font Font { get; set; } = new("Segoe UI", 9);

    /// <inheritdoc cref="IOverlayText.TextFormat" />
    public StringFormat TextFormat { get; set; } = new(StringFormat.GenericDefault);

    /// <inheritdoc cref="IOverlay.Paint" />
    public void Paint(Rectangle clientRectangle, Graphics graphics)
    {
        graphics.FillRectangle(new SolidBrush(BackgroundColor), clientRectangle);
        graphics.DrawString(Text, Font, new SolidBrush(TextColor), clientRectangle, TextFormat);
    }
}