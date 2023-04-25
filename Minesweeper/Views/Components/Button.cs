using Minesweeper.Enums;
using Minesweeper.Views.Base;
using Minesweeper.Views.Interfaces;

// ReSharper disable MemberCanBePrivate.Global

namespace Minesweeper.Views.Components;

public class Button : IComponentText
{
    private Color _foreColor;
    private Color _backColor;

    public Button()
    {
        _foreColor = ForeColor;
        _backColor = BackColor;
    }

    public Padding Padding { get; set; } = new(0);
    public Padding Margin { get; set; } = new(0);

    public ComponentEnums.MouseState MouseState { get; set; } = ComponentEnums.MouseState.None;

    public string Text { get; set; } = "";
    public Font Font { get; set; } = new Font("Segoe UI", 9, GraphicsUnit.Point);
    public StringFormat TextFormat { get; set; } = new(StringFormat.GenericDefault);

    public Color ForeColor { get; set; } = Color.Black;
    public Color HoverColor { get; set; } = Color.LightGray;
    public Color PressedColor { get; set; } = Color.DarkGray;
    public Color BackColor { get; set; } = Color.White;

    public virtual void Update(RenderBase parent, Point location)
    {
        RevertColors();
    }

    public void RevertColors()
    {
        _foreColor = ForeColor;

        _backColor = BackColor;

        if ((MouseState & ComponentEnums.MouseState.Press) != 0)
            _backColor = PressedColor;
        else if ((MouseState & ComponentEnums.MouseState.Hover) != 0)
            _backColor = HoverColor;
    }

    public virtual void Paint(Rectangle clientRectangle, Graphics graphics)
    {
        Rectangle backgroundRectangle = new(clientRectangle.X + Margin.Left, clientRectangle.Y + Margin.Top, clientRectangle.Width - Margin.Left - Margin.Right, clientRectangle.Height - Margin.Top - Margin.Bottom);
        Rectangle foregroundRectangle = new(clientRectangle.X + Padding.Left, clientRectangle.Y + Padding.Top, clientRectangle.Width - Padding.Left - Padding.Right, clientRectangle.Height - Padding.Top - Padding.Bottom);

        graphics.FillRectangle(new SolidBrush(_backColor), backgroundRectangle);
        graphics.DrawString(Text, Font, new SolidBrush(_foreColor), foregroundRectangle, TextFormat);
    }
}