using Minesweeper.Enums;
using Minesweeper.Views.Base;
using Minesweeper.Views.Interfaces;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global

namespace Minesweeper.Views.Components;

/// <summary>
///     A basic button component.
/// </summary>
public class Button : IComponentText
{
    // Current button background color
    private Color _backColor;

    // Current button foreground (text) color
    private Color _foreColor;

    /// <summary>
    ///     Initialize a new instance of <see cref="Button" />.
    /// </summary>
    public Button()
    {
        _foreColor = ForeColor;
        _backColor = BackColor;
    }

    /// <inheritdoc cref="IComponent.Padding" />
    public Padding Padding { get; set; } = new(0);

    /// <inheritdoc cref="IComponent.Margin" />
    public Padding Margin { get; set; } = new(0);

    /// <inheritdoc cref="IComponent.MouseState" />
    public ComponentEnums.MouseState MouseState { get; set; } = ComponentEnums.MouseState.None;

    /// <inheritdoc cref="IComponentText.Text" />
    public string Text { get; set; } = "";

    /// <inheritdoc cref="IComponentText.Font" />
    public Font Font { get; set; } = new("Segoe UI", 9, GraphicsUnit.Point);

    /// <inheritdoc cref="IComponentText.TextFormat" />
    public StringFormat TextFormat { get; set; } = new(StringFormat.GenericDefault);

    /// <inheritdoc cref="IComponentText.ForeColor" />
    public Color ForeColor { get; set; } = Color.Black;

    /// <inheritdoc cref="IComponent.BackColor" />
    public Color BackColor { get; set; } = Color.White;

    /// <summary>
    ///     The mouse hovering color.
    /// </summary>
    public Color HoverColor { get; set; } = Color.LightGray;

    /// <summary>
    ///     The mouse pressed color.
    /// </summary>
    public Color PressedColor { get; set; } = Color.DarkGray;

    /// <inheritdoc cref="IComponent.Update" />
    public virtual void Update(RenderBase parent, Point location)
    {
        RevertColors();
    }

    /// <inheritdoc cref="IComponent.RevertColors" />
    public void RevertColors()
    {
        _foreColor = ForeColor;

        _backColor = BackColor;

        if ((MouseState & ComponentEnums.MouseState.Press) != 0)
            _backColor = PressedColor;
        else if ((MouseState & ComponentEnums.MouseState.Hover) != 0)
            _backColor = HoverColor;
    }

    /// <inheritdoc cref="IComponent.Paint" />
    public virtual void Paint(Rectangle clientRectangle, Graphics graphics)
    {
        Rectangle backgroundRectangle = new(clientRectangle.X + Margin.Left, clientRectangle.Y + Margin.Top,
            clientRectangle.Width - Margin.Left - Margin.Right, clientRectangle.Height - Margin.Top - Margin.Bottom);
        Rectangle foregroundRectangle = new(clientRectangle.X + Padding.Left, clientRectangle.Y + Padding.Top,
            clientRectangle.Width - Padding.Left - Padding.Right,
            clientRectangle.Height - Padding.Top - Padding.Bottom);

        graphics.FillRectangle(new SolidBrush(_backColor), backgroundRectangle);
        graphics.DrawString(Text, Font, new SolidBrush(_foreColor), foregroundRectangle, TextFormat);
    }
}